using CarRentAPI.Data;
using CarRentAPI.Models;
using CarRentAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalPlaceController : ControllerBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new CarRentDbContext());

        [HttpGet("All")]
        public ActionResult<IEnumerable<RentalPlace>> GetAllCars()
        {
            return unitOfWork.RentPlaceRepository.GetAll().ToList();
        }

        [HttpPost("Add")]
        public ActionResult<RentalPlace> AddCar([FromQuery] RentalPlace rentalPlace)
        {
            if (rentalPlace == null) return BadRequest();

            unitOfWork.RentPlaceRepository.Insert(rentalPlace);
            unitOfWork.Save();

            return Ok(rentalPlace);
        }

        [HttpGet("GetCarRentalPlace")]
        public ActionResult<RentalPlace> GetCarRentalPlace(int carId)
        {
            if (carId <= 0) return BadRequest("Invalid car id");

            RentalPlace rentalPlace = unitOfWork.RentPlaceRepository.GetCarRentPlace(carId);
            return Ok(rentalPlace);
        }
    }
}
