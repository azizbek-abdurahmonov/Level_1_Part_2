using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost"
};

var connection = await connectionFactory.CreateConnectionAsync();

using var channel = await connection.CreateChannelAsync();

await channel
    .QueueDeclareAsync(
        queue: "hello-world",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);

var message = "Hello bratishka :)";
var body = Encoding.UTF8.GetBytes(message);

await channel.BasicPublishAsync(
    exchange: string.Empty,
    routingKey:"hello-world",
    body: body);