using EcommerceWebApi.Dtos.Request;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace EcommerceWebApi.Services.Email
{
    public class EmailService(IConfiguration config) : IEmailService
    {
        private readonly IConfiguration _config = config;

        public void SendEmail(EmailReqDto emailRequest)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("Email")["Username"]));
            email.To.Add(MailboxAddress.Parse(emailRequest.To));
            email.Subject = emailRequest.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailRequest.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("Email")["Host"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("Email")["Username"], _config.GetSection("Email")["Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
