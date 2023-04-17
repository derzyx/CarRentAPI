using CarRentAPI.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.EmailService.Exceptions
{
    public class EmailAddressIsInvalidException : BadRequestException
    {
        public EmailAddressIsInvalidException(string email) : base($"{email} is invalid email address")
        {
        }
    }
}
