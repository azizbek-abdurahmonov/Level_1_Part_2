namespace N53_HT1.Api.Interfaces;

public interface INotificationService
{
    ValueTask SendAsync(Guid userId, string content);
}
