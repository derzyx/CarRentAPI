namespace CarRentAPI.Models
{
    public class UserInput
    {
        public int Range { get; set; }
        public DateTime DriverLicenseYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
