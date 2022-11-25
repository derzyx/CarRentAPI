
using CarRentAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Domain.Entities.DTO;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using CarRentAPI.Application.Interfaces;

namespace CarRentAPI.Controllers
{
    [Route("api/rentcars")]
    [ApiController]
    public class RentCarsController : ControllerBase
    {

        private readonly ICarService carService;
        private readonly IRentalPlaceService rentalPlaceService;
        private readonly IReservationService reservationService;

        private readonly IEmailService emailService;
        private readonly IValidationService validationService;
        public RentCarsController(
            ICarService _carService,
            IRentalPlaceService _rentalPlaceService,
            IReservationService _reservationService,
            IEmailService _emailService, 
            IValidationService _validationService)
        {
            carService = _carService;
            rentalPlaceService = _rentalPlaceService;
            reservationService = _reservationService;
            emailService = _emailService;
            validationService = _validationService;
        }

        


        //user enters input data in form (date span, estimated range)
        //server returns CarsToRent
        //user selects car
        //client posts to AddReservation (it takes date span from form)


        [HttpGet("getlist")]
        public ActionResult<List<RentDetailsDTO>> CarsToRent([FromQuery] UserInputDTO input)
        {

            var cars = carService.GetAll();
            List<RentDetailsDTO> carsToRent = new List<RentDetailsDTO>();

            foreach (Car car in cars)
            {
                var details = carService.RentCost(car, input);

                carsToRent.Add(details);
            }

            return carsToRent;
        }

        [HttpPost("addreservation/{email}")]
        public ActionResult AddReservation(string email, RentDetailsDTO resDetails)
        {
            var isEmailValid = validationService.IsEmailValid(email);
            if (!isEmailValid) return BadRequest("Invalid email address");

            var isDateSpanValid = validationService.IsDateSpanValid(resDetails.UserInput.DateFrom, resDetails.UserInput.DateTo);
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
                DateFrom = resDetails.UserInput.DateFrom,
                DateTo = resDetails.UserInput.DateTo
            };

            //unitOfWork.ReservationRepository.Insert(newReservation);
            //unitOfWork.CarRepository.Update(car);
            //unitOfWork.Save();

            emailService.SendEmail(newReservation.Email, "Rezerwacja auta", resDetails);

            return Ok(newReservation);
        }
    }
}
