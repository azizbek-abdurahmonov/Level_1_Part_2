using Microsoft.Extensions.Hosting;
using N90_HT1.Application.Common.EventBus.Brokers;

namespace LocalIdentity.SimpleInfra.Infrastructure.Common.EventBus.Services;

public class EventBusBackgroundService(IEnumerable<IEventSubscriber> eventSubscribers) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.WhenAll(eventSubscribers.Select(eventSubscriber => eventSubscriber.StartAsync(stoppingToken).AsTask()));
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.WhenAll(eventSubscribers.Select(eventSubscriber => eventSubscriber.StopAsync(cancellationToken).AsTask()));
    }
}