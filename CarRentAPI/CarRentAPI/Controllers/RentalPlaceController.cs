using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Infrastructure.DbData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentAPI.Controllers
{
    [Route("api/rentalplaces")]
    [ApiController]
    public class RentalPlaceController : ControllerBase
    {
        private readonly IRentalPlaceService rentalPlaceService;
        private readonly ICustomService<RentalPlace> rentalPlaceBasicService;

        public RentalPlaceController(IRentalPlaceService _rentalPlaceService, ICustomService<RentalPlace> _rentalPlaceBasicService)
        {
            rentalPlaceService = _rentalPlaceService;
            rentalPlaceBasicService = _rentalPlaceBasicService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<RentalPlace>> GetAllCars()
        {
            return rentalPlaceBasicService.GetAll().ToList();
        }

        [HttpPost("add")]
        public ActionResult<RentalPlace> AddCar([FromQuery] RentalPlace rentalPlace)
        {
            if (rentalPlace == null) return BadRequest();

            rentalPlaceBasicService.Insert(rentalPlace);

            return Ok(rentalPlace);
        }

        [HttpGet("carrentalplace")]
        public ActionResult<RentalPlace> GetCarRentalPlace(int carId)
        {
            if (carId <= 0) return BadRequest("Invalid car id");

            RentalPlace rentalPlace = rentalPlaceService.GetCarRentPlace(carId);
            return Ok(rentalPlace);
        }
    }
}
