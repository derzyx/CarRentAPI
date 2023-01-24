using CarRentAPI.Domain.Entities.Exceptions;
using CarRentAPI.Domain.Enums;

namespace CarRentAPI.Domain.Entities
{

    public class Car
    {
        public Car(string _name, PriceCategories _priceCategories, float _avgFuelConsumption, int _rentalPlaceId, bool _isReserved, int _id = 0)
        {
            
            ValidateIfPropertyIsEmpty<string>(ref _name);
            this.Name = _name;
            ValidateIfPropertyIsEmpty<PriceCategories>(ref _priceCategories);
            this.PriceCategory = _priceCategories;
            ValidateIfPropertyIsEmpty<float>(ref _avgFuelConsumption);
            ValidateIfConsumptionGreaterThanZero(_avgFuelConsumption);
            this.AvgFuelConsumption = _avgFuelConsumption;
            ValidateIfPropertyIsEmpty<int>(ref _rentalPlaceId);
            this.RentalPlaceId = _rentalPlaceId;
            ValidateIfPropertyIsEmpty<bool>(ref _isReserved);
            this.IsReserved = _isReserved;
            this.Id = _id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public PriceCategories PriceCategory { get; set; }
        public string PriceCatName => PriceCategory.ToString();
        public float AvgFuelConsumption { get; set; }

        public int RentalPlaceId { get; set; }
        public virtual RentalPlace? RentalPlace { get; set; }

        public Reservation? Reservation { get; set; }

        public bool IsReserved { get; set; }

        private static void ValidateIfPropertyIsEmpty<T>(ref T property)
        {
            if (property == null) throw new PropertyNullException(nameof(property));
        }

        private static void ValidateIfConsumptionGreaterThanZero(float value)
        {
            if (value < 0.0) throw new FuelConsumptionIsLowerThanZeroException();
        }

        private static void ValidateRentalPlace(int rentalPlaceId)
        {
            if (rentalPlaceId <= 0) throw new InvalidRentalPlaceException();
        }
    }
}
