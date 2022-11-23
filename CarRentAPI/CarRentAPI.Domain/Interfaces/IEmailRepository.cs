using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Entities.DTO;

namespace CarRentAPI.Domain.Interfaces
{
    public interface IEmailRepository
    {
        void SendEmail(string reciever, string subject, RentDetailsDTO resDetails);
    }
}
