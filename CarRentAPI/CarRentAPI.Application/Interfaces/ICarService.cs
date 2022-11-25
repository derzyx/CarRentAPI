using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Entities.DTO;
using CarRentAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        RentDetailsDTO RentCost(Car car, UserInputDTO userInput);
    }
}
