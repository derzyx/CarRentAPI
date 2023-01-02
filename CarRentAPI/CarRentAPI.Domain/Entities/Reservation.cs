using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentAPI.Domain.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ReservedCar")]
        public int ReservedCarId { get; set; }
        public virtual Car ReservedCar { get; set; }
        public string Email { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

    }
}
