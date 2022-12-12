using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Interfaces;
using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Infrastructure.Repositories
{
    public class RentalPlaceRepository : BasicDbOpsRepository<RentalPlace>, IRentalPlace
    {
        private readonly CarRentDbContext context;
        public RentalPlaceRepository(CarRentDbContext _context) : base(_context)
        {
            context = _context;
        }

        public RentalPlace? GetCarRentPlace(int carId)
        {
            int carRentPlaceId = 0;
            var carRentPlace = context.Cars.AsNoTracking().Where(car => car.Id == carId).FirstOrDefault();
            if (carRentPlace != null)
            {
                carRentPlaceId = carRentPlace.RentalPlaceId;
            }
            return context.RentalPlaces.AsNoTracking().FirstOrDefault(place => place.Id == carRentPlaceId);
        }
    }
}
