using CarRentAPI.Data;

namespace CarRentAPI.Repository
{
    public class UnitOfWork
    {
        private CarRentDbContext context;
        private CarRepository carRepository;
        private RentPlaceRepository rentPlaceRepository;

        public UnitOfWork(CarRentDbContext _context)
        {
            context = _context;
        }

        public CarRepository CarRepository
        {
            get
            {
                if(carRepository == null)
                {
                    carRepository = new CarRepository(context);
                }
                return carRepository;
            }
        }

        public RentPlaceRepository RentPlaceRepository
        {
            get
            {
                if(rentPlaceRepository == null)
                {
                    rentPlaceRepository = new RentPlaceRepository(context);
                }
                return rentPlaceRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
