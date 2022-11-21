using CarRentAPI.Data;
using CarRentAPI.Models;

namespace CarRentAPI.Repository
{
    public class ReservationRepozytory : IGenericBasicRepository<Reservation>
    {
        private CarRentDbContext context;

        public ReservationRepozytory()
        {
            context = new CarRentDbContext();
        }

        public ReservationRepozytory(CarRentDbContext _context)
        {
            context = _context;
        }

        public void Delete(Reservation reservationId)
        {
            context.Remove(reservationId);
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
            context.Entry(reservation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
