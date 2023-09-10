using System.Net.Mail;
using System.Net;

namespace EmailApp.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string body)
        {

            var mail = "GurcuogluAutosender@gmail.com";
            var pw = "aykut234.";

                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(mail, pw)
                };

                return client.SendMailAsync(
                    new MailMessage(from: mail,
                                    to: email,
                                    subject,
                                    body
                                    ));
            
        }
    }
}
