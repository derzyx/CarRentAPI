using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Entities.DTO;
using CarRentAPI.Domain.Interfaces;
using CarRentAPI.Infrastructure.DbData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
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
        }

        public void Update(Car car)
        {
            //context.Cars.Update(car);
            context.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(Car carId)
        {
            context.Cars.Remove(carId);
        }

        public RentDetailsDTO RentCost(Car car, RentalPlace rentalPlace, UserInputDTO userInput)
        {
            throw new NotImplementedException();
        }
    }
}
