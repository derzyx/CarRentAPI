using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Services
{
    public class ReservationService : IReservationService, ICustomService<Reservation>
    {
        private readonly IReservationService reservationService;
        private readonly ICustomService<Reservation> reservationBasicService;
        public ReservationService(IReservationService _reservationService, ICustomService<Reservation> _reservationBasicService)
        {
            reservationService = _reservationService;
            reservationBasicService = _reservationBasicService;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return reservationBasicService.GetAll();
        }

        public Reservation GetById(int entityId)
        {
            return reservationBasicService.GetById(entityId);
        }

        public void Insert(Reservation entity)
        {
            reservationBasicService.Insert(entity);
        }

        public void Update(Reservation entity)
        {
            reservationBasicService.Update(entity);
        }

        public void Delete(Reservation entity)
        {
            reservationBasicService.Delete(entity);
        }

        public Reservation GetByCarId(int carId)
        {
            return reservationService.GetByCarId(carId);
        }
    }
}
