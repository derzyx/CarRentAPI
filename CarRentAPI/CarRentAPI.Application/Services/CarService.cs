using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Application.DTO;
using CarRentAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Services
{
    public class CarService : ICarService, ICustomService<Car>
    {
        private readonly ICustomService<Car> basicCarService;
        private readonly IRentalPlaceService rentalPlaceBasicService;
        private readonly IReservationService reservationBasicService;
        public CarService(
            ICustomService<Car> _basicCarService,
            IRentalPlaceService _rentalPlaceBasicService,
            IReservationService _reservationBasicService)
        {
            basicCarService = _basicCarService;
            rentalPlaceBasicService = _rentalPlaceBasicService;
            reservationBasicService = _reservationBasicService;
        }


        private static readonly float[] priceMultipliers = new[] { 1.0f, 1.3f, 1.6f, 2.0f };
        private float fuelPrice = 7.21f;
        private float newDriverFee = 1.2f;
        private float smallCarNumberFee = 1.15f;

        private string canRentMsg = "You can rent this car";
        private string cantRentPremiumMsg = "You cant rent premiun cars yet";
        private string isReservedMsg = "This car is reserved, you cant rent it";



        public IEnumerable<Car> GetAll()
        {
            return basicCarService.GetAll();
        }

        public Car GetById(int entityId)
        {
            return basicCarService.GetById(entityId);
        }

        public void Insert(Car entity)
        {
            basicCarService.Insert(entity);
        }

        public void Update(Car entity)
        {
            basicCarService.Update(entity);
        }

        public void Delete(Car entity)
        {
            basicCarService.Delete(entity);
        }

        public RentDetailsDTO RentCost(Car car, UserInputDTO userInput)
        {
            DateTime? reservedUntil = null;
            string rentMsg = "";

            var rentalPlace = rentalPlaceBasicService.GetCarRentPlace(car.Id);
            var drivingExperiance = (DateTime.Today - userInput.DriverLicenseYear).Days / 365;
            var rentDays = userInput.DateTo.Subtract(userInput.DateFrom).Days;
            var priceMultiplier = priceMultipliers[(int)car.PriceCategory];
            var isPremium = car.PriceCategory == PriceCategories.Premium ? true : false;

            var fuelCost = ((userInput.Range * car.AvgFuelConsumption) / 100) * fuelPrice;
            var totalPrice = (rentDays * rentalPlace.BasePrice * priceMultiplier) + fuelCost;

            if (drivingExperiance < 5) totalPrice *= newDriverFee;
            if (rentalPlace.Car.Count < 3) totalPrice *= smallCarNumberFee;
            if (car.IsReserved)
            {
                reservedUntil = reservationBasicService.GetByCarId(car.Id).DateTo;
                rentMsg = isReservedMsg;
            }

            if (drivingExperiance < 3 && isPremium) rentMsg = cantRentPremiumMsg;
            if (!(drivingExperiance < 3 && isPremium) && !car.IsReserved) rentMsg = canRentMsg;

            RentDetailsDTO details = new RentDetailsDTO
            {
                Car = car,
                UserInput = userInput,
                Location = rentalPlace.City,
                EndPrice = totalPrice,
                FuelPrice = fuelCost,
                CanRent = (drivingExperiance < 3 && isPremium) || car.IsReserved ? false : true,
                CanRentMessage = rentMsg,
                ReservedUntil = reservedUntil
            };

            return details;
        }

    }
}
