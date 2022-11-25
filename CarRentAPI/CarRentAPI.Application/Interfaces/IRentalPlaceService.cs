using CarRentAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Interfaces
{
    public interface IRentalPlaceService
    {
        IEnumerable<RentalPlace> GetAll();
        RentalPlace GetById(int entityId);
        void Insert(RentalPlace entity);
        void Update(RentalPlace entity);
        void Delete(RentalPlace entity);
        RentalPlace GetCarRentPlace(int carId);
    }
}
