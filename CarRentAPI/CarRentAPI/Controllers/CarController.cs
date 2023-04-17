using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Application.DTO;
using CarRentAPI.Infrastructure.DbData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentAPI.Infrastructure.Repositories;

namespace CarRentAPI.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        

        [HttpGet("all")]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            return unitOfWork.Cars.GetAll().ToList();
        }

        [HttpGet("id/{id}")]
        public ActionResult<Car?> GetCarById(int id)
        {
            return unitOfWork.Cars.GetById(id);
        }

        [HttpPost("add")]
        public ActionResult<Car> AddCar([FromQuery] Car car)
        {
            if (car == null) return BadRequest();

            unitOfWork.Cars.Insert(car);
            unitOfWork.Cars.Save();

            return Ok(car);
        }
    }
}
