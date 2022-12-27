using CarRentAPI.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CarRentAPI.RazorTemplates.RazorRenderer;
using MimeKit;

namespace CarRentAPI.EmailService
{
    public class EmailService : IEmail
    {
        private const string SENDER_EMAIL = "carrentalproject7@gmail.com";
        private readonly IRenderRazorView renderRazorView;
        public EmailService(IRenderRazorView _renderRazorView)
        {
            renderRazorView = _renderRazorView;
        }

        public async Task SendReservationEmail(string reciever, RentDetailsDTO details, string? subject = "")
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(SENDER_EMAIL, "dpdebrkbyorefpvf"),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            var emailBody = await renderRazorView.RenderViewToStringAsync("ReservationEmail", details);

            subject = (subject == "") ? "Dziękujemy za rezerwację auta" : subject;

            var message = new MailMessage();

            message.From = new MailAddress(SENDER_EMAIL);
            message.To.Add(reciever);
            message.Subject = subject;
            message.Body = emailBody;
            message.IsBodyHtml = true;         

            smtpClient.Send(message);

        }
    }
}


//As no tracking
//Eager vs lazy loading
//paginacja w bazie
//transaction
//