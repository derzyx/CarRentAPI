using Microsoft.OpenApi.Extensions;

namespace CarRentAPI.Models
{
    public enum PriceCategories
    {
        Basic = 0,
        Standard = 1,
        Medium = 2,
        Premium = 3
    }

    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PriceCategories PriceCategory { get; set; }
        public string PriceCatName => PriceCategory.GetDisplayName();
        public float AvgFuelConsumption { get; set; }
        public int RentalPlaceId { get; set; }
        public bool IsReserved { get; set; }
    }
}
