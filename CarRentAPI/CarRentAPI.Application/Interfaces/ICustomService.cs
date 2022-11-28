using CarRentAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Interfaces
{
    public interface ICustomService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int entityId);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
