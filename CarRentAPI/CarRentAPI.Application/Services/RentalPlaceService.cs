using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Services
{
    public class RentalPlaceService :IRentalPlaceService,  ICustomService<RentalPlace>
    {
        private readonly IRentalPlaceService rentalPlaceService;
        private readonly ICustomService<RentalPlace> rentalPlaceBasicService;
        public RentalPlaceService(IRentalPlaceService _rentalPlaceService, ICustomService<RentalPlace> _rentalPlaceBasicService)
        {
            rentalPlaceService = _rentalPlaceService;
            rentalPlaceBasicService = _rentalPlaceBasicService;
        }

        public IEnumerable<RentalPlace> GetAll()
        {
            return rentalPlaceBasicService.GetAll();
        }

        public RentalPlace GetById(int entityId)
        {
            return rentalPlaceBasicService.GetById(entityId);
        }

        public void Insert(RentalPlace entity)
        {
            rentalPlaceBasicService.Insert(entity);
        }

        public void Update(RentalPlace entity)
        {
            rentalPlaceBasicService.Update(entity);
        }

        public void Delete(RentalPlace entity)
        {
            rentalPlaceBasicService.Delete(entity);
        }

        public RentalPlace GetCarRentPlace(int carId)
        {
            return rentalPlaceService.GetCarRentPlace(carId);
        }

    }
}
