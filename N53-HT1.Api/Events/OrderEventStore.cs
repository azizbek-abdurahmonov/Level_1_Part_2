using N53_HT1.Api.Models;

namespace N53_HT1.Api.Events;

public class OrderEventStore
{
    public event Func<Order, ValueTask>? OrderCreatedEvent;

    public async ValueTask CreateOrderAddedEventAsync(Order order)
    {
        if (OrderCreatedEvent != null)
            OrderCreatedEvent?.Invoke(order);
    }
}
