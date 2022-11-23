using CarRentAPI.Domain.Enums;

namespace CarRentAPI.Domain.Entities
{

    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PriceCategories PriceCategory { get; set; }
        public string PriceCatName => PriceCategory.ToString();
        public float AvgFuelConsumption { get; set; }
        public int RentalPlaceId { get; set; }
        public bool IsReserved { get; set; }
    }
}
