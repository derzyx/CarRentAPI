using CarRentAPI.Models;

namespace CarRentAPI.Repository
{
    public interface IGenericBasicRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int entityId);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
