using N90_HT1.Application.Common.EventBus.Brokers;
using N90_HT1.Application.Common.Serializers;
using N90_HT1.Domain.Common.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using System.Text;

namespace N90_HT1.Infrastructure.Common.EventBus.Brokers;

public class RabbitMqEventBusBroker(
    IRabbitMqConnectionProvider rabbitMqConnectionProvider,
    IJsonSerializationSettingsProvider jsonSerializationSettingsProvider    
    ) : IEventBusBroker
{
    public async ValueTask PublishAsync<TEvent>(TEvent @event, string exchange, string routingKey, CancellationToken cancellationToken = default) where TEvent : Event
    {
        var channel = await rabbitMqConnectionProvider.CreateChannelAsync(cancellationToken);

        var properties = new BasicProperties
        {
            Persistent = true
        };

        var serializerSettings = jsonSerializationSettingsProvider.Get(true);
        serializerSettings.ContractResolver = new DefaultContractResolver();
        serializerSettings.TypeNameHandling = TypeNameHandling.All;

        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event, serializerSettings));
        await channel.BasicPublishAsync(exchange, routingKey, properties, body);
    }
}
    