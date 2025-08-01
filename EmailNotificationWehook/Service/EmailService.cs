using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Shared.DTOs;

namespace EmailNotificationWehook.Service
{
    public class EmailService : IEmailService
    {
        public string SendEmail(EmailDTO email)
        {
            var _email = new MimeMessage();
            _email.From.Add(MailboxAddress.Parse("abbigail.frami@ethereal.email"));
            _email.To.Add(MailboxAddress.Parse("ngotranxuanhoa09062004@gmail.com"));
            _email.Subject = email.Title;
            _email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = email.Content };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("abbigail.frami@ethereal.email", "svxFUvCPjU4Wvx9vQt", CancellationToken.None);
            smtp.Send(_email);
            smtp.Disconnect(true);
            return "Email sent";
        }
    }
}
