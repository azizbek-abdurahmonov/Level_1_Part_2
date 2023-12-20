using N90_HT1.Domain.Common.Entities;
using N90_HT1.Domain.Enums;

namespace N90_HT1.Domain.Entities;

public class UserSettings : IEntity
{
    public NotificationType? PreferredNotificationType { get; set; }

    /// <summary>
    ///     Gets or sets the user Id
    /// </summary>
    public Guid Id { get; set; }
}