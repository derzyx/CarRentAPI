using CarRentAPI.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Domain.Entities.Exceptions
{
    public class PropertyNullException : BadRequestException
    {
        public PropertyNullException(string property) : base($"{property} can't be empty")
        {

        }
    }
}
