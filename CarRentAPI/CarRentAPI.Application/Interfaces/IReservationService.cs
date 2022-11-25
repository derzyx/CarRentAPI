using CarRentAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Interfaces
{
    public interface IReservationService
    {
        IEnumerable<Reservation> GetAll();
        Reservation GetById(int entityId);
        void Insert(Reservation entity);
        void Update(Reservation entity);
        void Delete(Reservation entity);
        Reservation GetByCarId(int carId);
    }
}
