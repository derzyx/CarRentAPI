using CarRentAPI.Models;

namespace CarRentAPI.Repository
{
    public interface IGenericBasicRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int carId);
        void Insert(T car);
        void Update(T car);
        void Delete(T carId);
    }
}
