using N90_HT1.Application.Common.Notifications.Models;
using N90_HT1.Domain.Common.Exceptions;

namespace N90_HT1.Application.Common.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(EmailProcessNotificationEvent @event, CancellationToken cancellationToken = default);
}