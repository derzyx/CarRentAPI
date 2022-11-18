using CarRentAPI.Data;
using CarRentAPI.Models;
using CarRentAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new CarRentDbContext());

        [HttpGet("All")]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            return unitOfWork.CarRepository.GetAll().ToList();
        }

        [HttpPost("Add")]
        public ActionResult<Car> AddCar([FromQuery] Car car)
        {
            if (car == null) return BadRequest();

            unitOfWork.CarRepository.Insert(car);
            unitOfWork.Save();

            return Ok(car);
        }
    }
}
