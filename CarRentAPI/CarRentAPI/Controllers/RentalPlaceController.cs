using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentAPI.Controllers
{
    [Route("api/rentalplaces")]
    [ApiController]
    public class RentalPlaceController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();


        [HttpGet("all")]
        public ActionResult<IEnumerable<RentalPlace>> GetAllRentalPlaces()
        {
            return unitOfWork.RentalPlaces.GetAll().ToList();
        }

        [HttpPost("add")]
        public ActionResult<RentalPlace> AddRentalPlace([FromQuery] RentalPlace rentalPlace)
        {
            if (rentalPlace == null) return BadRequest();

            unitOfWork.RentalPlaces.Insert(rentalPlace);

            return Ok(rentalPlace);
        }

        [HttpGet("carrentalplace")]
        public ActionResult<RentalPlace> GetCarRentalPlace(int carId)
        {
            if (carId <= 0) return BadRequest("Invalid car id");

            var rentalPlaceId = unitOfWork.RentalPlaces.GetCarRentPlace(carId);
            RentalPlace? rentalPlace = unitOfWork.RentalPlaces.GetById(rentalPlaceId);

            if (rentalPlace == null) return NotFound("Rental place not found");

            return Ok(rentalPlace);
        }
    }
}
