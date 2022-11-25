using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Services
{
    public class RentalPlaceService : IRentalPlaceService
    {
        private readonly IRentalPlaceRepository rentalPlaceRepository;
        public RentalPlaceService(IRentalPlaceRepository _rentalPlaceRepository)
        {
            rentalPlaceRepository = _rentalPlaceRepository;
        }

        public void Delete(RentalPlace entity)
        {
            rentalPlaceRepository.Delete(entity);
        }

        public IEnumerable<RentalPlace> GetAll()
        {
            return rentalPlaceRepository.GetAll();
        }

        public RentalPlace GetById(int entityId)
        {
            return rentalPlaceRepository.GetById(entityId);
        }

        public RentalPlace GetCarRentPlace(int carId)
        {
            return rentalPlaceRepository.GetCarRentPlace(carId);
        }

        public void Insert(RentalPlace entity)
        {
            rentalPlaceRepository.Insert(entity);
        }

        public void Update(RentalPlace entity)
        {
            rentalPlaceRepository.Update(entity);
        }
    }
}
