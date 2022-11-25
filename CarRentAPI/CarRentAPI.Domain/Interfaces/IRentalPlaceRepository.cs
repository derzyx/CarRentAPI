using CarRentAPI.Domain.Entities;

namespace CarRentAPI.Domain.Interfaces
{
    public interface IRentalPlaceRepository
    {
        IEnumerable<RentalPlace> GetAll();
        RentalPlace GetById(int entityId);
        void Insert(RentalPlace entity);
        void Update(RentalPlace entity);
        void Delete(RentalPlace entity);
        RentalPlace GetCarRentPlace(int carId);
    }
}
