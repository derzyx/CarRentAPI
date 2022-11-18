using CarRentAPI.Models;

namespace CarRentAPI.Repository
{
    public interface IRentPlaceRepository
    {
        RentalPlace GetCarRentPlace(int carId);
    }
}
