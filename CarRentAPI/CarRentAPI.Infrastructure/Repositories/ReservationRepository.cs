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
    public class ReservationRepository : BasicDbOpsRepository<Reservation>, IReservation
    {
        private readonly CarRentDbContext context;

        public ReservationRepository(CarRentDbContext _context) : base(_context)
        {
            context = _context;
        }

        public Reservation? GetByCarId(int carId)
        {
            return context.Reservations.AsNoTracking().FirstOrDefault(res => res.ReservedCar.Id == carId);
        }
    }
}
