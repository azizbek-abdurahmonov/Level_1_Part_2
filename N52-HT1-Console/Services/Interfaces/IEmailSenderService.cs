using N52_HT1_Console.Models;

namespace N52_HT1_Console.Services.Interfaces;

public interface IEmailSenderService
{
    Task SendEmailAsync(User user);
}