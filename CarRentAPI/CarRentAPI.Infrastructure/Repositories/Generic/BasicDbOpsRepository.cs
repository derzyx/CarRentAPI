using CarRentAPI.Domain.Interfaces;
using CarRentAPI.Infrastructure.DbData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Infrastructure.Repositories.Generic
{
    public abstract class BasicDbOpsRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CarRentDbContext context;
        private readonly DbSet<T> dbSet;

        public BasicDbOpsRepository(CarRentDbContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T? GetById(int entityId)
        {
            return dbSet.Find(entityId);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
