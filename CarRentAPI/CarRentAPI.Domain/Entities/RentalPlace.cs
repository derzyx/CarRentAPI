using System.ComponentModel.DataAnnotations;

namespace CarRentAPI.Domain.Entities
{
    public class RentalPlace
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public virtual ICollection<Car>? Car { get; set; }
        public float BasePrice { get; set; }
    }
}
