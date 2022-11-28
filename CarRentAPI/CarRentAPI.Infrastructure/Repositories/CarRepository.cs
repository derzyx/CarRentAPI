using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Infrastructure.DbData;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Infrastructure.Repositories
{
    public class CarRepository : ICustomService<Car>
    {
        private readonly CarRentDbContext context;

        public CarRepository(CarRentDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<Car> GetAll()
        {
            return context.Cars.ToList();
        }

        public Car GetById(int carId)
        {
            return context.Cars.Find(carId);
        }

        public void Insert(Car car)
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }

        public void Update(Car car)
        {
            context.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Car carId)
        {
            context.Cars.Remove(carId);
            context.SaveChanges();
        }
    }
}
