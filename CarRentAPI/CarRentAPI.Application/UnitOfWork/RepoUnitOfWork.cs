using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.UnitOfWork
{
    public class RepoUnitOfWork
    {
        private ICarRepository carRepository;
        private IRentalPlaceRepository rentPlaceRepository;
        private IReservationRepository reservationRepository;

        public ICarRepository CarRepository
        {
            get
            {
                return carRepository;
            }
        }

        public IRentalPlaceRepository RentPlaceRepository
        {
            get
            {
                return rentPlaceRepository;
            }
        }

        public IReservationRepository RentReservationRepository
        {
            get
            {
                return reservationRepository;
            }
        }
    }
}
