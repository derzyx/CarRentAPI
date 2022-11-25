using CarRentAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Domain.Entities.DTO
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
