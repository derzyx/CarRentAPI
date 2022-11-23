using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Interfaces;

namespace CarRentAPI.Repository
{
    public class ReservationRepozytory : IGenericBasicRepository<Reservation>
    {
        private CarRentDbContext context;


        public ReservationRepozytory(CarRentDbContext _context)
        {
            context = _context;
        }

        public void Delete(Reservation reservationId)
        {
            context.Reservations.Remove(reservationId);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return context.Reservations.ToList();
        }

        public Reservation GetById(int reservationId)
        {
            return context.Reservations.Find(reservationId);
        }

        public void Insert(Reservation reservation)
        {
            context.Reservations.Add(reservation);
        }

        public void Update(Reservation reservation)
        {
            context.Reservations.Update(reservation);
            //context.Entry(reservation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public Reservation GetByCarId(int carId)
        {
            return context.Reservations.Where(res => res.ReservedCar.Id == carId).FirstOrDefault();
        }
    }
}
