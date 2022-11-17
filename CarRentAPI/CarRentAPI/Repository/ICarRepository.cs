using CarRentAPI.Models;

namespace CarRentAPI.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car GetById(int carId);
        void Insert(Car car);
        void Update(Car car);
        void Delete(Car carId);
        void Save();

        

    }
}
