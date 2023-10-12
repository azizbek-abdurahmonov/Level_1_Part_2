using N53_HT1.Api.Interfaces;

namespace N53_HT1.Api.Services;

public class TelegramSenderService : INotificationService
{
    public ValueTask SendAsync(Guid userId, string content)
    {
        Console.WriteLine($"Sending notification with Telegram to {userId} with content: {content}");

        return new ValueTask();
    }
}
