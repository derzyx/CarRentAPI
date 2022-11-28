using CarRentAPI.Domain.Entities;
using CarRentAPI.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Interfaces
{
    public interface ICarService
    {
        RentDetailsDTO RentCost(Car car, UserInputDTO userInput);
    }
}
