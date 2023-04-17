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

        private readonly ICarService carService;
        private readonly IEmail emailService;
        public RentCarsController(
            ICarService _carService,
            IEmail _emailService)
        {
            carService = _carService;
            emailService = _emailService;
        }

        //user enters input data in form (date span, estimated range)
        //server returns CarsToRent
        //user selects car
        //client posts to AddReservation (it takes date span from form)
        [HttpGet("getlist")]
        public ActionResult<List<RentDetailsDTO>> CarsToRent([FromQuery] RentRequestDTO input)
        {
            var userInput = new RentRequest(input.Range, input.DriverLicenseYear, input.DateFrom, input.DateTo);

            var cars = unitOfWork.Cars.GetAll();
            List<RentDetailsDTO> carsToRent = new List<RentDetailsDTO>();

            foreach (Car car in cars)
            {
                if (car.RentalPlace == null) continue;

                var details = carService.RentCost(car, userInput);
                carsToRent.Add(details);
            }
            return carsToRent;
        }


        [HttpPost("addreservation/{email}")]
        public async Task<ActionResult> AddReservationAsync(string email, RentDetailsDTO resDetails)
        {
            var car = unitOfWork.Cars.GetById(resDetails.Car.Id);

            var newReservation = new Reservation
            (
                car.Id,
                car,
                email,
                resDetails.UserInput.DateFrom,
                resDetails.UserInput.DateTo
            );

            car.IsReserved = true;

            unitOfWork.Reservations.Insert(newReservation);
            unitOfWork.Save();

            await emailService.SendReservationEmail(email, resDetails);
            return Ok("Wysłano email");
        }
    }
}
