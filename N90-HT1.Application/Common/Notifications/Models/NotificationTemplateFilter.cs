using N90_HT1.Domain.Common.Query;
using N90_HT1.Domain.Enums;

namespace N90_HT1.Application.Common.Notifications.Models;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}