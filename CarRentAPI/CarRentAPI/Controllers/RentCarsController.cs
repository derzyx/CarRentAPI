
using CarRentAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Domain.Entities.DTO;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;

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

        private DbContextOptions<CarRentDbContext> configuration;
        private UnitOfWork unitOfWork;
        public RentCarsController(DbContextOptions<CarRentDbContext> _configuration)
        {
            configuration = _configuration;
            unitOfWork = new UnitOfWork(new CarRentDbContext(configuration));
        }

        //private UnitOfWork unitOfWork = new UnitOfWork(new CarRentDbContext());

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
        public ActionResult<List<RentDetailsDTO>> CarsToRent([FromQuery] UserInputDTO input)
        {

            var cars = unitOfWork.CarRepository.GetAll().ToList();
            List<RentDetailsDTO> carsToRent = new List<RentDetailsDTO>();

            foreach (Car car in cars)
            {
                DateTime? reservedUntil = null;

                string rentMsg = "";
                var rentPlace = unitOfWork.RentPlaceRepository.GetCarRentPlace(car.Id);

                var drivingExperiance = (DateTime.Today - input.DriverLicenseYear).Days / 365;
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

                RentDetailsDTO details = new RentDetailsDTO
                {
                    Car = car,
                    Location = rentPlace.City,
                    EndPrice = totalPrice,
                    FuelPrice = fuelCost,
                    CanRent = (drivingExperiance < 3 && isPremium) || car.IsReserved ? false : true,
                    CanRentMessage = rentMsg,
                    ReservedUntil = reservedUntil,
                    UserDateFrom = input.DateFrom,
                    UserDateTo = input.DateTo
                };

                carsToRent.Add(details);
            }

            return carsToRent;
        }

        [HttpPost("addreservation/{email}")]
        public ActionResult AddReservation(string email, RentDetailsDTO resDetails)
        {
            var isEmailValid = unitOfWork.ValidationRepository.IsEmailValid(email);
            if (!isEmailValid) return BadRequest("Invalid email address");

            var isDateSpanValid = unitOfWork.ValidationRepository.IsDateSpanValid(resDetails.UserDateFrom, resDetails.UserDateTo);
            if (!isDateSpanValid.IsValid) return BadRequest(isDateSpanValid.Message);

            var car = resDetails.Car;
            if (car == null) return BadRequest("Invalid car id");
            if (!resDetails.CanRent) return BadRequest("This car is already reserved");

            car.IsReserved = true;

            var newReservation = new Reservation
            {
                Id = 0,
                ReservedCar = car,
                Email = email,
                DateFrom = resDetails.UserDateFrom,
                DateTo = resDetails.UserDateTo
            };

            //unitOfWork.ReservationRepository.Insert(newReservation);
            //unitOfWork.CarRepository.Update(car);
            //unitOfWork.Save();

            unitOfWork.EmailRepository.SendEmail(newReservation.Email, "Rezerwacja auta", resDetails);

            return Ok(newReservation);
        }
    }
}
