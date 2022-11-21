namespace CarRentAPI.Models.DTO
{
    public class ReservationDTO
    {
        public int CarId { get; set; }
        public string Email { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
