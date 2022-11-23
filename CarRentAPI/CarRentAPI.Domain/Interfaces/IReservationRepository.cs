using CarRentAPI.Domain.Entities;

namespace CarRentAPI.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Reservation GetByCarId(int carId);
    }
}
