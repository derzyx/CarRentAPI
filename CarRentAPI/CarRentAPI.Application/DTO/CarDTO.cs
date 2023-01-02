using CarRentAPI.Domain.Enums;

namespace CarRentAPI.Application.DTO
{
    public class CarDTO
    {
        public string Name { get; set; }
        public PriceCategories PriceCategory { get; set; }
        public string? PriceCatName { get; set; }
        public float? AvgFuelConsumption { get; set; }
        public int? RentalPlaceId { get; set; }
        public string? RentalPlaceName { get; set; }
        public bool? IsReserved { get; set; }
    }
}
