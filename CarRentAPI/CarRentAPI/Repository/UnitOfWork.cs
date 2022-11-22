using CarRentAPI.Data;

namespace CarRentAPI.Repository
{
    public class UnitOfWork
    {
        private CarRentDbContext context;
        private CarRepository carRepository;
        private RentPlaceRepository rentPlaceRepository;
        private ReservationRepozytory reservationRepository;

        private ValidationRepository validationRepository;
        private EmailRepository emailRepository;
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

        public ReservationRepozytory ReservationRepository
        {
            get
            {
                if(reservationRepository == null)
                {
                    reservationRepository = new ReservationRepozytory(context);
                }
                return reservationRepository;
            }
        }

        public ValidationRepository ValidationRepository
        {
            get
            {
                if(validationRepository == null)
                {
                    validationRepository = new ValidationRepository();
                }
                return validationRepository;
            }
        }

        public EmailRepository EmailRepository
        {
            get
            {
                if(emailRepository == null)
                {
                    emailRepository = new EmailRepository();
                }
                return emailRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
