using CarRentAPI.Domain.Entities;
using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentAPI.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private DbContextOptions<CarRentDbContext> configuration;
        private UnitOfWork unitOfWork;
        public CarController(DbContextOptions<CarRentDbContext> _configuration)
        {
            configuration = _configuration;
            unitOfWork = new UnitOfWork(new CarRentDbContext(configuration));
        }

        //private UnitOfWork unitOfWork = new UnitOfWork(new CarRentDbContext(configuration));

        [HttpGet("all")]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            return unitOfWork.CarRepository.GetAll().ToList();
        }

        [HttpPost("add")]
        public ActionResult<Car> AddCar([FromQuery] Car car)
        {
            if (car == null) return BadRequest();

            unitOfWork.CarRepository.Insert(car);
            unitOfWork.Save();

            return Ok(car);
        }
    }
}
