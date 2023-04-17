

namespace CarRentAPI.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int entityId);
        void Insert(T entity);
        void Delete(T entity);
        void Save();
    }
}
