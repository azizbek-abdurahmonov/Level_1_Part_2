using N90_HT1.Domain.Common.Entities;
using N90_HT1.Domain.Enums;

namespace N90_HT1.Domain.Entities;

public abstract class NotificationTemplate : IEntity
{
    public NotificationType Type { get; set; }

    public NotificationTemplateType TemplateType { get; set; }

    public string Content { get; set; } = default!;

    public IList<NotificationHistory> Histories { get; set; } = new List<NotificationHistory>();
    public Guid Id { get; set; }
}