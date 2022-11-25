using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Interfaces;
using CarRentAPI.Infrastructure.DbData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Infrastructure.Repositories
{
    public class RentalPlaceRepository : IRentalPlaceRepository
    {
        private readonly CarRentDbContext context;
        public RentalPlaceRepository(CarRentDbContext _context)
        {
            context = _context;
        }

        public void Delete(RentalPlace entity)
        {
            context.RentalPlaces.Remove(entity);
        }

        public IEnumerable<RentalPlace> GetAll()
        {
            return context.RentalPlaces.ToList();
        }

        public RentalPlace GetById(int entityId)
        {
            return context.RentalPlaces.Find(entityId);
        }

        public RentalPlace GetCarRentPlace(int carId)
        {
            int carRentPlaceId = context.Cars.Where(car => car.Id == carId).FirstOrDefault().RentalPlaceId;
            return context.RentalPlaces.Where(place => place.Id == carRentPlaceId).FirstOrDefault();
        }

        public void Insert(RentalPlace entity)
        {
            context.RentalPlaces.Add(entity);
        }

        public void Update(RentalPlace entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
