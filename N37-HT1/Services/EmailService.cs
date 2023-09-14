using N37_HT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_HT1.Services
{
    public class EmailService
    {
        public IEnumerable<EmailMessage> GetMessages(IEnumerable<EmailTemplate> templates, IEnumerable<User> users)
        {
            foreach (var item in users.Zip(templates))
            {
                yield return new EmailMessage(item.Second.Subject, item.Second.Body,
                    MessageConstants.SenderEmailAddress, item.First.EmailAddress);
            }
        }
    }
}
