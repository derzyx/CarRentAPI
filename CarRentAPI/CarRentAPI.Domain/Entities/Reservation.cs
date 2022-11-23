namespace CarRentAPI.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public Car ReservedCar { get; set; }
        public string Email { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }
}
