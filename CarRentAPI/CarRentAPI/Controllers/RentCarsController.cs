using Microsoft.AspNetCore.Mvc;
using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Application.DTO;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using CarRentAPI.Application.Interfaces;
using CarRentAPI.Infrastructure.Repositories;
using CarRentAPI.EmailService;
using CarRentAPI.Validation;

namespace CarRentAPI.Controllers
{
    [Route("api/rentcars")]
    [ApiController]
    public class RentCarsController : ControllerBase
    {
        // Db access
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        UserInputValidator inputValidator = new UserInputValidator();
        ReservationValidator reservationValidator = new ReservationValidator();

        private readonly ICarService carService;
        private readonly IEmail emailService;
        private readonly IValidationService validationService;
        public RentCarsController(
            ICarService _carService,
            IEmail _emailService, 
            IValidationService _validationService)
        {
            carService = _carService;
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
            var valResult = inputValidator.Validate(input);

            if (valResult.IsValid)
            {
                var cars = unitOfWork.Cars.GetAll();
                List<RentDetailsDTO> carsToRent = new List<RentDetailsDTO>();

                foreach (Car car in cars)
                {
                    var details = carService.RentCost(car, input);
                    carsToRent.Add(details);
                }
                return carsToRent;
            }
            else
            {
                string errors = "";
                foreach(var error in valResult.Errors)
                {
                    errors += " " + error + " ";
                }
                var details = new RentDetailsDTO { CanRentMessage = errors };
                return new List<RentDetailsDTO> { details };
            }
        }

        [HttpPost("addreservation/{email}")]
        public async Task<ActionResult> AddReservationAsync(string email, RentDetailsDTO resDetails)
        {
            if (!resDetails.CanRent) return BadRequest("This car is already reserved");

            var car = unitOfWork.Cars.GetById(resDetails.Car.Id);
            if (car == null) return BadRequest("Invalid car id");

            //var isEmailValid = validationService.IsEmailValid(email);
            //if (!isEmailValid) return BadRequest("Invalid email address");

            //var isDateSpanValid = validationService.IsDateSpanValid(resDetails.UserInput.DateFrom, resDetails.UserInput.DateTo);
            //if (!isDateSpanValid.IsValid) return BadRequest(isDateSpanValid.Message);

            car.IsReserved = true;

            var newReservation = new Reservation
            {
                ReservedCarId = car.Id,
                ReservedCar = car,
                Email = email,
                DateFrom = resDetails.UserInput.DateFrom,
                DateTo = resDetails.UserInput.DateTo
            };

            var valResult = reservationValidator.Validate(newReservation);

            if (valResult.IsValid)
            {
                //unitOfWork.Reservations.Insert(newReservation);
                //unitOfWork.Reservations.Save();

                await emailService.SendReservationEmail(email, resDetails);
                return Ok("Wysłano email");
            }
            else
            {
                var errors = "";
                foreach (var error in valResult.Errors)
                {
                    errors += " " + error + " ";
                }
                return BadRequest(errors);
            }

        }
    }
}
