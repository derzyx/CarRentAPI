using CarRentAPI.Domain.Entities.DTO;
using CarRentAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CarRentAPI.Application.Interfaces;

namespace CarRentAPI.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository emailRepository;
        public EmailService(IEmailRepository _emailRepository)
        {
            emailRepository = _emailRepository;
        }

        public void SendEmail(string reciever, string subject, RentDetailsDTO resDetails)
        {
            emailRepository.SendEmail(reciever, subject, resDetails);
        }
    }
}
