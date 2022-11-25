using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IValidationRepository validationRepository;
        public ValidationService(IValidationRepository _validationRepository)
        {
            validationRepository = _validationRepository;
        }

        public (bool IsValid, string Message) IsDateSpanValid(DateTime dateFrom, DateTime dateTo)
        {
            return validationRepository.IsDateSpanValid(dateFrom, dateTo);
        }

        public bool IsEmailValid(string email)
        {
            return validationRepository.IsEmailValid(email);
        }
    }
}
