using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Application.DTO;
using CarRentAPI.Infrastructure.DbData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentAPI.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICustomService<Car> basicCarService;
        public CarController(ICustomService<Car> _basicCarService)
        { 
            basicCarService = _basicCarService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            return basicCarService.GetAll().ToList();
        }

        [HttpGet("id/{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            return basicCarService.GetById(id);
        }

        [HttpPost("add")]
        public ActionResult<Car> AddCar([FromQuery] Car car)
        {
            if (car == null) return BadRequest();

            basicCarService.Insert(car);

            return Ok(car);
        }
    }
}
