using N39_HT2.Models;

namespace N39_HT2.Services.Interfaces;

public interface IEmailSenderService
{
    Task<bool> SendEmail(string emailAddress, string fullName);
}
