using N90_HT1.Application.Common.Notifications.Models;

namespace N90_HT1.Application.Common.Notifications.Events;

public class SendNotificationEvent : NotificationEvent
{
    public NotificationMessage Message { get; set; } = default!;
}