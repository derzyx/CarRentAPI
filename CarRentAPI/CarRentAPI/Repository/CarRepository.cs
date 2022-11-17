using CarRentAPI.Data;
using CarRentAPI.Models;

namespace CarRentAPI.Repository
{
    public class CarRepository: ICarRepository
    {
        private CarRentDbContext context;

        public CarRepository()
        {
            context = new CarRentDbContext();
        }
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
            context.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(Car carId)
        {
            context.Cars.Remove(carId);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
