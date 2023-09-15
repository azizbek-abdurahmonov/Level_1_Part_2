using N39_HT2.Services.Interfaces;
using System.Net.Mail;
using System.Net;
using N39_HT2.Models;

namespace N39_HT2.Services;

public class EmailSenderService : IEmailSenderService
{
    public async Task<bool> SendEmail(string emailAddress, string fullName)
    {
        try
        {

            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("sultonbek.rakhimov.recovery@gmail.com", "szabguksrhwsbtie");
            smtp.EnableSsl = true;

            var mail = new MailMessage(MessageConstants.SenderEmail, emailAddress);
            mail.Subject = MessageConstants.Subject
                .Replace("{{User}}", fullName);
            mail.Body = MessageConstants.Body;

            await smtp.SendMailAsync(mail);
            return true;
        }
        catch { return false; }
    }
}
