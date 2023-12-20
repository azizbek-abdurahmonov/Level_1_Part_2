using N90_HT1.Domain.Enums;

namespace N90_HT1.Application.Common.Notifications.Events;

public class ProcessNotificationEvent : NotificationEvent
{
    public NotificationTemplateType TemplateType { get; init; }

    public NotificationType? Type { get; set; }

    public Dictionary<string, string>? Variables { get; set; }
}