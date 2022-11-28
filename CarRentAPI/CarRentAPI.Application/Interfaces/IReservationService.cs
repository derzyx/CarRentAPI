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
        Reservation GetByCarId(int carId);
    }
}
