using N90_HT1.Application.Common.Notifications.Models;

namespace N90_HT1.Application.Common.Notifications.Brokers;

public interface IEmailSenderBroker
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}