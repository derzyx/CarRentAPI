using CarRentAPI.Models;

namespace CarRentAPI.Repository
{
    public interface IEmailRepository
    {
        void SendEmail(string reciever, string subject, Reservation resInfo);
    }
}
