using N37_HT1.Models;

namespace N37_HT1.Services.Interfaces;

public interface IEmailSenderService
{
    Task SendEmailsAsync(IEnumerable<EmailMessage> messages);
}