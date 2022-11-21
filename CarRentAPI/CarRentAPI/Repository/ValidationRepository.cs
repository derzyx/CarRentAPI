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
    }
}
