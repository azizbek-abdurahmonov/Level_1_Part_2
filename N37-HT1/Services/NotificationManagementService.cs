using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N37_HT1.Services
{
    public class NotificationManagementService
    {
        private UserService _userService;
        private EmailService _emailService;
        private EmailTemplateService _emailTemplateService;
        private EmailSenderService _emailSenderService;

        public NotificationManagementService(UserService userService, EmailService emailService, EmailTemplateService emailTemplateService, EmailSenderService emailSenderService)
        {
            _userService = userService;
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
            _emailSenderService = emailSenderService;
        }

        public async Task NotifyUsers()
        {
            var users = _userService.GetUsers();
            var templates = _emailTemplateService.GetTemplates(users);
            var messages = _emailService.GetMessages(templates, users);
            await _emailSenderService.SendEmailsAsync(messages);
        }
    }
}
