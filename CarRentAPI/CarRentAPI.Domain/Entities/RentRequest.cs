using CarRentAPI.Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Domain.Entities
{
    public class RentRequest
    {
        public RentRequest(int _range, DateTime _licenseYear, DateTime _dateFrom, DateTime _dateTo)
        {
            ValidateRange(_range);
            this.Range = _range;
            ValidateReservationDate(_licenseYear, _dateFrom, _dateTo);
            this.DriverLicenseYear = _licenseYear;
            this.DateFrom = _dateFrom;
            this.DateTo = _dateTo;
        }


        public int Range { get; set; }
        public DateTime DriverLicenseYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }


        private static void ValidateRange(int range)
        {
            if (range <= 0) throw new RangeLessOrLessThanZeroException();
        }

        private static void ValidateReservationDate(DateTime licenseDate, DateTime dateFrom, DateTime dateTo)
        {
            if (licenseDate > DateTime.UtcNow) throw new LicenseYearYoungerThanTodayException();
            if (dateFrom < DateTime.UtcNow || dateTo < DateTime.UtcNow) throw new DateOlderThanTodayException();
            if (dateFrom > dateTo) throw new DateFromOlderThanDateToException();
        }
    }
}
