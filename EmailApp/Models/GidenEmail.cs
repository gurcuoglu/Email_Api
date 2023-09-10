using System.Net.Mail;

namespace EmailApp.Models
{
    public class GidenEmail
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string Body { get; set; }
        public int EmailAddressId { get; set; }
        public EmailAdres Recipient { get; set; }

    }
}
