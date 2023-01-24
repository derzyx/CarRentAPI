using CarRentAPI.Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Validation
{
    public class UserInputValidator: AbstractValidator<RentRequestDTO>
    {
        public UserInputValidator()
        {
            RuleFor(input => input.Range).NotNull().NotEmpty();
            RuleFor(input => input.DriverLicenseYear).NotEmpty().LessThanOrEqualTo(DateTime.Now).LessThan(input => input.DateFrom);
            RuleFor(input => input.DateFrom).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(input => input.DateTo).NotEmpty().GreaterThan(input => input.DateFrom);
        }
    }
}
