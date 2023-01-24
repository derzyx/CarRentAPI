using CarRentAPI.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Domain.Entities.Exceptions
{
    public class ReservedCarNullException : BadRequestException
    {
        public ReservedCarNullException() : base("Car is empty")
        {

        }
    }
}
