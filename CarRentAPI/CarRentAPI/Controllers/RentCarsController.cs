using CarRentAPI.Data;
using CarRentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentCarsController : ControllerBase
    {
        private static readonly float[] priceMultipliers = new[] { 1.0f, 1.3f, 1.6f, 2.0f };
        private float fuelPrice = 7.21f;
        private float newDriverFee = 1.2f;
        private float smallCarNumberFee = 1.15f;

        private readonly CarRentDbContext context;
        public RentCarsController(CarRentDbContext _context)
        {
            context = _context;
        }

        [HttpGet("AllCars")]
        public ActionResult<List<Car>> GetAllCars()
        {
            return context.Cars.ToList();
        }

        [HttpGet("Rent")]
        public ActionResult<List<RentDetails>> CarsToRent([FromQuery] UserInput input)
        {
            var cars = context.Cars.ToList();
            List<RentDetails> carsToRent = new List<RentDetails>();

            foreach (Car car in cars)
            {
                var rentPlace = context.RentalPlaces.Where(place => place.Id == car.RentalPlaceId).First();

                var drivingExperiance = DateTime.Today.Year - input.DriverLicenseYear;
                var rentDays = input.DateTo.Subtract(input.DateFrom).Days;
                var priceMultiplier = priceMultipliers[(int)car.PriceCategory];
                var isPremium = car.PriceCategory == PriceCategories.Premium ? true : false;

                var fuelCost = ((input.Range * car.AvgFuelConsumption) / 100) * fuelPrice;
                var totalPrice = (rentDays * rentPlace.BasePrice * priceMultiplier) + fuelCost;

                if (drivingExperiance < 5) totalPrice *= newDriverFee;
                if (rentPlace.Car.Count < 3) totalPrice *= smallCarNumberFee;

                RentDetails details = new RentDetails
                {
                    Car = car,
                    Location = rentPlace.City,
                    EndPrice = totalPrice,
                    FuelPrice = fuelCost,
                    CanRent = (drivingExperiance < 3 && isPremium) ? "You cant rent premium cars yet" : "You can rent this car"
                };

                carsToRent.Add(details);
            }

            return carsToRent;
        }
    }
}
