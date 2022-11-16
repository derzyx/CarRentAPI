namespace CarRentAPI.Models
{
    public class RentalPlace
    {
        public int Id { get; set; }
        public string City { get; set; }
        public List<Car>? Car { get; set; }
        public float BasePrice { get; set; }
        public int AvailableCars => Car.Count;
    }
}
