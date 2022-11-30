using CarRentAPI.Application.Interfaces;
using CarRentAPI.Infrastructure.DbData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentDbContext context = new CarRentDbContext();

        public CarRepository cars;
        public RentalPlaceRepository rentalPlaces;
        public ReservationRepository reservations;

        public CarRepository Cars
        {
            get
            {
                if(cars == null)
                {
                    cars = new CarRepository(context);
                }
                return cars;
            }
        }
        public RentalPlaceRepository RentalPlaces
        {
            get
            {
                if (rentalPlaces == null)
                {
                    rentalPlaces = new RentalPlaceRepository(context);
                }
                return rentalPlaces;
            }
        }
        public ReservationRepository Reservations
        {
            get
            {
                if (reservations == null)
                {
                    reservations = new ReservationRepository(context);
                }
                return reservations;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
