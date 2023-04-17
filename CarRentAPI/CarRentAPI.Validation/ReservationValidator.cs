using CarRentAPI.Application.DTO;
using CarRentAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Validation
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        private string emailRegEx = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public ReservationValidator()
        {
            RuleFor(x => x.ReservedCarId).NotEmpty();
            RuleFor(x => x.ReservedCar).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().Matches(emailRegEx);
            RuleFor(input => input.DateFrom).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(input => input.DateTo).NotEmpty().GreaterThan(input => input.DateFrom);
        }
    }
}
