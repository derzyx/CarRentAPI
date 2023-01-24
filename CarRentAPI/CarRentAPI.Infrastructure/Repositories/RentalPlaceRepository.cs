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

        public int GetCarRentPlace(int carId)
        {
            var carRentPlace = context.Cars.AsNoTracking().Where(car => car.Id == carId).FirstOrDefault();
            if (carRentPlace == null)
            {
                return 0;
            }
            return carRentPlace.RentalPlaceId;


        }

        public ICollection<Car> GetCarsInRentalPlace(int rentalPlaceId)
        {
            return context.Cars.Where(car => car.RentalPlaceId == rentalPlaceId).ToList();
        }
    }
}
