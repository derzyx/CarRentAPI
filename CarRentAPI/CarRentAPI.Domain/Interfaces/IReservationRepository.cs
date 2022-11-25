using CarRentAPI.Domain.Entities;

namespace CarRentAPI.Domain.Interfaces
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
        Reservation GetById(int entityId);
        void Insert(Reservation entity);
        void Update(Reservation entity);
        void Delete(Reservation entity);
        Reservation GetByCarId(int carId);
    }
}
