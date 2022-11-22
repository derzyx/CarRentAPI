using CarRentAPI.Data;
using CarRentAPI.Models;
using CarRentAPI.Models.DTO;
using CarRentAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentAPI.Controllers
{
    [Route("api/rentcars")]
    [ApiController]
    public class RentCarsController : ControllerBase
    {
        private static readonly float[] priceMultipliers = new[] { 1.0f, 1.3f, 1.6f, 2.0f };
        private float fuelPrice = 7.21f;
        private float newDriverFee = 1.2f;
        private float smallCarNumberFee = 1.15f;

        private string canRentMsg = "You can rent this car";
        private string cantRentPremiumMsg = "You cant rent premiun cars yet";
        private string isReservedMsg = "This car is reserved, you cant rent it";

        private UnitOfWork unitOfWork = new UnitOfWork(new CarRentDbContext());

        //private ICarRepository carRepository;
        //private IRentPlaceRepository rentPlaceRepository;
        //public RentCarsController()
        //{
        //    carRepository = new CarRepository(new CarRentDbContext());
        //    rentPlaceRepository = new RentPlaceRepository(new CarRentDbContext());
        //}
        //public RentCarsController(ICarRepository _carRepository, IRentPlaceRepository _rentPlaceRepository)
        //{
        //    carRepository = _carRepository;
        //    rentPlaceRepository = _rentPlaceRepository;
        //}
        

        //user enters input data in form (date span, estimated range)
        //server returns CarsToRent
        //user selects car
        //client posts to AddReservation (it takes date span from form)


        [HttpGet("getlist")]
        public ActionResult<List<RentDetails>> CarsToRent([FromQuery] UserInput input)
        {
            string rentMsg = "";

            var cars = unitOfWork.CarRepository.GetAll().ToList();
            List<RentDetails> carsToRent = new List<RentDetails>();

            foreach (Car car in cars)
            {
                DateTime? reservedUntil = null;
                var rentPlace = unitOfWork.RentPlaceRepository.GetCarRentPlace(car.Id);

                var drivingExperiance = (DateTime.Today - input.DriverLicenseYear).Days/365;
                var rentDays = input.DateTo.Subtract(input.DateFrom).Days;
                var priceMultiplier = priceMultipliers[(int)car.PriceCategory];
                var isPremium = car.PriceCategory == PriceCategories.Premium ? true : false;

                var fuelCost = ((input.Range * car.AvgFuelConsumption) / 100) * fuelPrice;
                var totalPrice = (rentDays * rentPlace.BasePrice * priceMultiplier) + fuelCost;

                if (drivingExperiance < 5) totalPrice *= newDriverFee;
                if (rentPlace.Car.Count < 3) totalPrice *= smallCarNumberFee;
                if (car.IsReserved)
                {
                    reservedUntil = unitOfWork.ReservationRepository.GetByCarId(car.Id).DateTo;
                    rentMsg = isReservedMsg;
                }

                if (drivingExperiance < 3 && isPremium) rentMsg = cantRentPremiumMsg;
                if (!(drivingExperiance < 3 && isPremium) && !car.IsReserved) rentMsg = canRentMsg;

                RentDetails details = new RentDetails
                {
                    Car = car,
                    Location = rentPlace.City,
                    EndPrice = totalPrice,
                    FuelPrice = fuelCost,
                    CanRent = (drivingExperiance < 3 && isPremium) || car.IsReserved ? false : true,
                    CanRentMessage = rentMsg,
                    ReservedUntil = reservedUntil
                };

                carsToRent.Add(details);
            }

            return carsToRent;
        }

        [HttpPost("addreservation")]
        public ActionResult AddReservation([FromQuery] ReservationDTO reservation)
        {
            var isEmailValid = unitOfWork.ValidationRepository.IsEmailValid(reservation.Email);
            if (!isEmailValid) return BadRequest("Invalid email address");

            var isDateSpanValid = unitOfWork.ValidationRepository.IsDateSpanValid(reservation.DateFrom, reservation.DateTo);
            if (!isDateSpanValid.IsValid) return BadRequest(isDateSpanValid.Message);

            var car = unitOfWork.CarRepository.GetById(reservation.CarId);
            if (car == null) return BadRequest("Invalid car id");
            if (car.IsReserved) return BadRequest("This car is already reserved");

            car.IsReserved = true;

            var newReservation = new Reservation
            {
                Id = 0,
                ReservedCar = car,
                Email = reservation.Email,
                DateFrom = reservation.DateFrom,
                DateTo = reservation.DateTo
            };

            //unitOfWork.ReservationRepository.Insert(newReservation);
            //unitOfWork.CarRepository.Update(car);
            //unitOfWork.Save();

            var body = $"Dziękujemy za rezerwację auta. " +
                       $"Szczegóły:" +
                       $"Model: {newReservation.ReservedCar.Name}" +
                       $"Data wypożyczenia: {newReservation.DateFrom} - {newReservation.DateTo}";

            unitOfWork.EmailRepository.SendEmail(newReservation.Email, "Rezerwacja auta", newReservation);

            return Ok(newReservation);
        }
    }
}
