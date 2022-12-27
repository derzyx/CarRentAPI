using CarRentAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentAPI.Domain.Entities
{

    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public PriceCategories PriceCategory { get; set; }
        public string PriceCatName => PriceCategory.ToString();
        public float AvgFuelConsumption { get; set; }

        [ForeignKey("RentalPlace")]
        public int RentalPlaceId { get; set; }
        public virtual RentalPlace? RentalPlace { get; set; }
        public Reservation? Reservation { get; set; }

        public bool IsReserved { get; set; }
    }
}
