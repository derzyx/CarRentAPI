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
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using CarRentAPI.EmailService.Exceptions;

namespace CarRentAPI.EmailService
{
    public class EmailService : IEmail
    {
        private const string emailRegEx = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        private readonly IRenderRazorView renderRazorView;
        private readonly IConfiguration configuration;
        public EmailService(IRenderRazorView _renderRazorView, IConfiguration _configuration)
        {
            renderRazorView = _renderRazorView;
            configuration = _configuration;
        }

        public async Task SendReservationEmail(string reciever, RentDetailsDTO details, string? subject = "")
        {
            ValidateRecieverEmail(reciever);

            var smtpClient = new SmtpClient(configuration.GetSection("MailService").GetValue<String>("Server"), 587)
            {
                Credentials = new NetworkCredential(
                    configuration.GetSection("MailService").GetValue<String>("Sender"), 
                    configuration.GetSection("MailService").GetValue<String>("Pass")
                ),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            var emailBody = await renderRazorView.RenderViewToStringAsync("ReservationEmail", details);

            subject = (subject == "") ? "Dziękujemy za rezerwację auta" : subject;

            var message = new MailMessage();

            message.From = new MailAddress(configuration.GetSection("MailService").GetValue<String>("Sender"));
            message.To.Add(reciever);
            message.Subject = subject;
            message.Body = emailBody;
            message.IsBodyHtml = true;         

            smtpClient.Send(message);

        }

        private static void ValidateRecieverEmail(string reciever)
        {
            if (!Regex.IsMatch(reciever, emailRegEx, RegexOptions.IgnoreCase))
            {
                throw new EmailAddressIsInvalidException(reciever);
            }
        }
    }
}


//As no tracking
//Eager vs lazy loading
//paginacja w bazie
//transaction
//