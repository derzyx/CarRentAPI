namespace CarRentAPI.Models
{
    public class RentDetails
    {
        public Car Car { get; set; }
        public string Location { get; set; }
        public float EndPrice { get; set; }
        public float FuelPrice { get; set; }
        public float NetPrice => EndPrice * (1 - 0.23f);
        public string CanRent { get; set; }
    }
}
