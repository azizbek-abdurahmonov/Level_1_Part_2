namespace N64.Identity.Application.Common.Notification.Services;

public interface IEmailOrchestrationService
{
    ValueTask<bool> SendAsync(string emailAddress, string message);
}
