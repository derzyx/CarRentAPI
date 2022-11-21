using System.Text.RegularExpressions;

namespace CarRentAPI.Repository
{
    public class ValidationRepository : IValidate
    {
        private string emailRegEx = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, emailRegEx, RegexOptions.IgnoreCase);
        }

        public (bool IsValid, string Message) IsDateSpanValid(DateTime dateFrom, DateTime dateTo)
        {
            if(dateTo < DateTime.Now || dateFrom < DateTime.Now)
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
