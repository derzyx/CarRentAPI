using CarRentAPI.Data;
using CarRentAPI.Models;
using CarRentAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentAPI.Controllers
{
    [Route("api/rentalplaces")]
    [ApiController]
    public class RentalPlaceController : ControllerBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new CarRentDbContext());

        [HttpGet("all")]
        public ActionResult<IEnumerable<RentalPlace>> GetAllCars()
        {
            return unitOfWork.RentPlaceRepository.GetAll().ToList();
        }

        [HttpPost("add")]
        public ActionResult<RentalPlace> AddCar([FromQuery] RentalPlace rentalPlace)
        {
            if (rentalPlace == null) return BadRequest();

            unitOfWork.RentPlaceRepository.Insert(rentalPlace);
            unitOfWork.Save();

            return Ok(rentalPlace);
        }

        [HttpGet("carrentalplace")]
        public ActionResult<RentalPlace> GetCarRentalPlace(int carId)
        {
            if (carId <= 0) return BadRequest("Invalid car id");

            RentalPlace rentalPlace = unitOfWork.RentPlaceRepository.GetCarRentPlace(carId);
            return Ok(rentalPlace);
        }
    }
}
