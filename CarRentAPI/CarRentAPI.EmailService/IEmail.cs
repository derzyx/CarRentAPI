using CarRentAPI.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.EmailService
{
    public interface IEmail
    {
        Task SendReservationEmail(string reciever, RentDetailsDTO details, string? subject = "");
    }
}
