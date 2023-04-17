using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Interfaces
{
    public interface IValidationService
    {
        bool IsEmailValid(string email);
        (bool IsValid, string Message) IsDateSpanValid(DateTime dateFrom, DateTime dateTo);
    }
}
