
namespace CarRentAPI.Domain.Interfaces
{
    public interface IValidationRepository
    {
        bool IsEmailValid(string email);
        (bool IsValid, string Message) IsDateSpanValid(DateTime dateFrom, DateTime dateTo);
    }
}
