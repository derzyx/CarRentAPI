using CarRentAPI.Models;

namespace CarRentAPI.Repository
{
    public interface IReservationRepository
    {
        Reservation GetByCarId(int carId);
    }
}
