using N41_HT2.Models;

namespace N41_HT2.Services.Interfaces;

public interface IEmailSenderService
{
    Task SendEmailAsync(EmailTemplate template);
}