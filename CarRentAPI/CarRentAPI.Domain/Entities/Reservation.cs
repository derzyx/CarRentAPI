
using CarRentAPI.Domain.Entities.Exceptions;

namespace CarRentAPI.Domain.Entities
{
    public class Reservation
    {
        public Reservation(int _reservedCarId, Car _reservedCar, string _email, DateTime _dateFrom, DateTime _dateTo, int _id = 0)
        {
            ValidateReservedCar(_reservedCar);
            this.ReservedCarId = _reservedCarId;
            this.ReservedCar = _reservedCar;
            this.Email = _email;
            ValidateReservationDate(_dateFrom, _dateTo);
            this.DateFrom = _dateFrom;
            this.DateTo = _dateTo;
            this.Id = _id;
        }


        public int Id { get; set; }
        public int ReservedCarId { get; set; }
        public virtual Car ReservedCar { get; set; }
        public string Email { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }



        private static void ValidateReservedCar(Car car)
        {
            if (car == null) throw new ReservedCarNullException();
            if (car.IsReserved) throw new CarIsAlreadyReservedException();
        }

        private static void ValidateReservationDate(DateTime dateFrom, DateTime dateTo)
        {
            if (dateFrom < DateTime.UtcNow || dateTo < DateTime.UtcNow) throw new DateOlderThanTodayException();
            if (dateFrom > dateTo) throw new DateFromOlderThanDateToException();
        }
    }
}
