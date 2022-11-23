using CarRentAPI.Domain.Entities;

namespace CarRentAPI.Domain.Interfaces
{
    public interface IRentPlaceRepository
    {
        RentalPlace GetCarRentPlace(int carId);
    }
}
