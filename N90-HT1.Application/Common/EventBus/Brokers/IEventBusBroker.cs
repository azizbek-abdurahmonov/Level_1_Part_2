using N90_HT1.Domain.Common.Events;

namespace N90_HT1.Application.Common.EventBus.Brokers;

public interface IEventBusBroker
{
    ValueTask PublishAsync<TEvent>(TEvent @event, string exchange, string routingKey, CancellationToken cancellationToken = default) where TEvent : Event;
}