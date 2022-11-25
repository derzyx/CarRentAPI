using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Interfaces;

namespace CarRentAPI.Repository
{
    public class RentPlaceRepository : IGenericBasicRepository<RentalPlace>, IRentalPlaceRepository
    {
        private CarRentDbContext context;

        public RentPlaceRepository(CarRentDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<RentalPlace> GetAll()
        {
            return context.RentalPlaces.ToList();
        }

        public RentalPlace GetById(int rentalPlaceId)
        {
            return context.RentalPlaces.Find(rentalPlaceId);
        }

        public void Insert(RentalPlace rentalPlace)
        {
            context.RentalPlaces.Add(rentalPlace);
        }

        public void Update(RentalPlace rentalPlace)
        {
            context.RentalPlaces.Update(rentalPlace);
            //context.Entry(rentalPlace).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(RentalPlace rentalPlaceId)
        {
            context.RentalPlaces.Remove(rentalPlaceId);
        }

        public RentalPlace GetCarRentPlace(int carId)
        {
            int carRentPlaceId = context.Cars.Where(car => car.Id == carId).FirstOrDefault().RentalPlaceId;
            return context.RentalPlaces.Where(place => place.Id == carRentPlaceId).FirstOrDefault();
        }
    }
}
