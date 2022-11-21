namespace CarRentAPI.Models.DTO
{
    public class RentDetails
    {
        public Car Car { get; set; }
        public string Location { get; set; }
        public float EndPrice { get; set; }
        public float FuelPrice { get; set; }
        public float NetPrice => EndPrice * (1 - 0.23f);
        public bool CanRent { get; set; }
        public string CanRentMessage { get; set; }
        public DateTime? ReservedUntil { get; set; }
    }
}
