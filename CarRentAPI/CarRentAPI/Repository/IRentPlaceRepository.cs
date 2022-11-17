using CarRentAPI.Models;

namespace CarRentAPI.Repository
{
    public interface IRentPlaceRepository
    {
        IEnumerable<RentalPlace> GetAll();
        RentalPlace GetById(int carId);
        void Insert(RentalPlace car);
        void Update(RentalPlace car);
        void Delete(RentalPlace carId);
        void Save();

        RentalPlace GetCarRentPlace(int carId);
    }
}
