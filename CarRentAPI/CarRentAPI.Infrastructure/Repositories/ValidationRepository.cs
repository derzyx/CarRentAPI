using CarRentAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRentAPI.Infrastructure.Repositories
{
    public class ValidationRepository: IValidationRepository
    {
        private string emailRegEx = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, emailRegEx, RegexOptions.IgnoreCase);
        }

        public (bool IsValid, string Message) IsDateSpanValid(DateTime dateFrom, DateTime dateTo)
        {
            if (dateTo < DateTime.Now)
            {
                return (false, "DateTo is a past date");
            }
            else
            {
                if (dateFrom > dateTo) return (false, "DateTo is older than DateFrom");
                else
                {
                    return (true, "");
                }
            }
        }
    }
}
