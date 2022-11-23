using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Entities.DTO;

namespace CarRentAPI.Domain.Interfaces
{
    public interface ICarRepository
    {
        RentDetailsDTO RentCost(Car car, RentalPlace rentalPlace, UserInputDTO userInput);
    }
}
