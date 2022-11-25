using CarRentAPI.Application.Interfaces;
using CarRentAPI.Application.UnitOfWork;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Entities.DTO;
using CarRentAPI.Domain.Enums;
using CarRentAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;
        private readonly IRentalPlaceRepository rentalPlaceRepository;
        private readonly IReservationRepository reservationRepository;
        public CarService(
            ICarRepository _carRepository, 
            IRentalPlaceRepository _rentalPlaceRepository,
            IReservationRepository _reservationRepository)
        {
            carRepository = _carRepository;
            rentalPlaceRepository = _rentalPlaceRepository;
            reservationRepository = _reservationRepository;
        }


        private static readonly float[] priceMultipliers = new[] { 1.0f, 1.3f, 1.6f, 2.0f };
        private float fuelPrice = 7.21f;
        private float newDriverFee = 1.2f;
        private float smallCarNumberFee = 1.15f;

        private string canRentMsg = "You can rent this car";
        private string cantRentPremiumMsg = "You cant rent premiun cars yet";
        private string isReservedMsg = "This car is reserved, you cant rent it";

        public void Delete(Car entity)
        {
            carRepository.Delete(entity);
        }

        public IEnumerable<Car> GetAll()
        {
            //List<CarDTO> carsList = new List<CarDTO>();
            //var cars = carRepository.GetAll();
            //foreach(Car car in cars)
            //{
            //    carsList.Add(new CarDTO
            //    {
            //        Name = car.Name,
            //        PriceCatName = car.PriceCatName,
            //        RentalPlaceName = rentPlaceRepository.GetCarRentPlace(car.Id).City,
            //        IsReserved = car.IsReserved
            //    });
            //}
            //return carsList;
            return carRepository.GetAll();
        }

        public Car GetById(int entityId)
        {
            return carRepository.GetById(entityId);
        }

        public void Insert(Car entity)
        {
            carRepository.Insert(entity);
        }

        public RentDetailsDTO RentCost(Car car, UserInputDTO userInput)
        {
            DateTime? reservedUntil = null;
            string rentMsg = "";

            var rentalPlace = rentalPlaceRepository.GetCarRentPlace(car.Id);
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
                reservedUntil = reservationRepository.GetByCarId(car.Id).DateTo;
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

        public void Update(Car entity)
        {
            carRepository.Update(entity);
        }
    }
}
