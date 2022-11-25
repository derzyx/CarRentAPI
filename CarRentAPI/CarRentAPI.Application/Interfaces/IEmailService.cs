using CarRentAPI.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Application.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string reciever, string subject, RentDetailsDTO resDetails);
    }
}
