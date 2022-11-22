using CarRentAPI.Models;
using System.Net;
using System.Net.Mail;

namespace CarRentAPI.Repository
{
    public class EmailRepository : IEmailRepository
    {
        public void SendEmail(string reciever, string subject, Reservation resInfo)
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
                       $"Model auta: {resInfo.ReservedCar.Name}<br>" +
                       $"Data wypożyczenia: {resInfo.DateFrom} - {resInfo.DateTo}",
                IsBodyHtml = true
            };

            mailMessage.To.Add(reciever);

            smtpClient.Send(mailMessage);
        }
    }
}
