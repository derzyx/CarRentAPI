using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository reservationRepository;
        public ReservationService(IReservationRepository _reservationRepository)
        {
            reservationRepository = _reservationRepository;
        }

        public void Delete(Reservation entity)
        {
            reservationRepository.Delete(entity);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return reservationRepository.GetAll();
        }

        public Reservation GetByCarId(int carId)
        {
            return reservationRepository.GetByCarId(carId);
        }

        public Reservation GetById(int entityId)
        {
            return reservationRepository.GetById(entityId);
        }

        public void Insert(Reservation entity)
        {
            reservationRepository.Insert(entity);
        }

        public void Update(Reservation entity)
        {
            reservationRepository.Update(entity);
        }
    }
}
