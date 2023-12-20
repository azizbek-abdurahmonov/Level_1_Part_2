using N90_HT1.Application.Common.Notifications.Events;
using N90_HT1.Domain.Enums;

namespace N90_HT1.Application.Common.Notifications.Models;

public class EmailProcessNotificationEvent : ProcessNotificationEvent
{
    public EmailProcessNotificationEvent()
    {
        Type = NotificationType.Email;
    }
}