using System.Net;
using System.Net.Mail;
using N41_HT2.Models;
using N41_HT2.Services.Interfaces;

namespace N41_HT2.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly object _locker = new();
    private SmtpClient? _smtp;

    public EmailSenderService()
    {
        _smtp = new SmtpClient("smtp.gmail.com", 587);
        _smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
        _smtp.EnableSsl = true;
    }

    public async Task SendEmailAsync(EmailTemplate template)
    {
        lock (_locker)
        {
            var fullName = $"{template.User.FirstName} {template.User.LastName}";
            var mail = new MailMessage(Constants.SenderEmailAddress, template.User.EmailAddress);
            mail.Subject = Constants.WelcomeSubject
                .Replace("{{User}}", fullName);
            mail.Body = Constants.WelcomeBody;

            _smtp.SendMailAsync(mail).Wait();
        }
    }
}