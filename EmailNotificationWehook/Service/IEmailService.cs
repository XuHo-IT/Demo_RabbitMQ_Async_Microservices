using Shared.DTOs;

namespace EmailNotificationWehook.Service
{
    public interface IEmailService
    {
        string SendEmail(EmailDTO email);
    }
}
