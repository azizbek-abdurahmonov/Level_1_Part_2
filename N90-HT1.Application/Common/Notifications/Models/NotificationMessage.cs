using N90_HT1.Domain.Entities;

namespace N90_HT1.Application.Common.Notifications.Models;

public abstract class NotificationMessage
{
    public string Body { get; set; } = default!;

    public NotificationTemplate Template { get; set; } = default!;

    public Dictionary<string, string> Variables { get; set; } = default!;

    public bool IsSuccessful { get; set; }

    public string? ErrorMessage { get; set; }
}