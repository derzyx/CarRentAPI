
namespace CarRentAPI.Domain.Entities
{
    public class RentalPlace
    {
        public int Id { get; set; }
        public string City { get; set; }
        public virtual ICollection<Car>? Car { get; set; }
        public float BasePrice { get; set; }
    }
}
