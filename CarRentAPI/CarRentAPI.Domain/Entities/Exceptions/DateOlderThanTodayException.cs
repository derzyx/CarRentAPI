using CarRentAPI.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Domain.Entities.Exceptions
{
    public class DateOlderThanTodayException : BadRequestException
    {
        public DateOlderThanTodayException() : base("Date is older than today date")
        {

        }
    }
}
