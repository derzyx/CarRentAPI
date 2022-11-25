using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Entities.DTO;

namespace CarRentAPI.Domain.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car GetById(int entityId);
        void Insert(Car entity);
        void Update(Car entity);
        void Delete(Car entity);
        
    }
}
