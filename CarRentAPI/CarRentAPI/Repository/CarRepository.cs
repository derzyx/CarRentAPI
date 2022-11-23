using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Interfaces;

namespace CarRentAPI.Repository
{
    public class CarRepository: IGenericBasicRepository<Car>
    {

        private CarRentDbContext context;

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
            context.Cars.Update(car);
            //context.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(Car carId)
        {
            context.Cars.Remove(carId);
        }

    }
}
