using N37_HT1.Models;

namespace N37_HT1.Services.Interfaces;

public interface IEmailSenderServiceService
{
    Task SendEmailsAsync(IEnumerable<EmailMessage> messages);
}