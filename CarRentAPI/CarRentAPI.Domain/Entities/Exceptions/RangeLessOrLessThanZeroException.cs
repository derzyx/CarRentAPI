using CarRentAPI.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Domain.Entities.Exceptions
{
    public class RangeLessOrLessThanZeroException : BadRequestException
    {
        public RangeLessOrLessThanZeroException() : base("Range must be higher than 0")
        {

        }
    }
}
