using CarRentAPI.Application.DTO;
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
        public void SendEmail(string reciever, string subject, RentDetailsDTO resDetails)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("carrentalproject7@gmail.com", "dpdebrkbyorefpvf"),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("carrentalproject7@gmail.com"),
                Subject = subject,
                Body = $"<h1>Dokonałeś rezerwacji auta</h1><br>" +
                       $"Szczegóły rezerwacji:<br>" +
                       $"Marka: <b>{resDetails.Car.Name}</b><br>" +
                       $"Klasa: <b>{resDetails.Car.PriceCategory}</b><br>" +
                       $"Data wypożyczenia: <b>{resDetails.UserInput.DateFrom} - {resDetails.UserInput.DateTo}</b><br>" +
                       $"<br>" +
                       $"Cena końcowa: <b>{resDetails.EndPrice}</b><br>" +
                       $"W tym:<br>" +
                       $"- cena netto: <b>{resDetails.NetPrice}</b><br>" +
                       $"- cena paliwa: <b>{resDetails.FuelPrice}</b>",
                IsBodyHtml = true
            };

            mailMessage.To.Add(reciever);

            smtpClient.Send(mailMessage);
        }
    }
}
