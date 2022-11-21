namespace CarRentAPI.Repository
{
    public interface IValidate
    {
        bool IsEmailValid(string email);
        (bool IsValid, string Message) IsDateSpanValid(DateTime dateFrom, DateTime dateTo);
    }
}
