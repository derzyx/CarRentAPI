using CarRentAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Domain.Interfaces
{
    public interface IReservation
    {
        Reservation? GetByCarId(int carId);
    }
}
