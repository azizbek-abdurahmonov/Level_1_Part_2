using N37_HT1.Models;

namespace N37_HT1.Services.Interfaces;

public interface IEmailTemplateService
{
    IEnumerable<EmailTemplate> GetTemplates(IEnumerable<User> users);
}