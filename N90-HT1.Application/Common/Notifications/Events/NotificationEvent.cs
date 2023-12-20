using N90_HT1.Domain.Common.Events;

namespace N90_HT1.Application.Common.Notifications.Events;

public class NotificationEvent : Event
{
    public Guid SenderUserId { get; init; }

    public Guid ReceiverUserId { get; init; }
}