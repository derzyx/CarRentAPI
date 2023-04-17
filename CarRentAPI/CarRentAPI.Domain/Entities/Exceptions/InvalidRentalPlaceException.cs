using CarRentAPI.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Domain.Entities.Exceptions
{
    public class InvalidRentalPlaceException : BadRequestException
    {
        public InvalidRentalPlaceException() : base("Invalid rental place")
        {

        }
    }
}
