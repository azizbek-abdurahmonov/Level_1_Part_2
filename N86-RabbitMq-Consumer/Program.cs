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

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine(message);
};

await channel.BasicConsumeAsync(
    queue:"hello-world",
    autoAck:true,
    consumer:consumer);

Console.ReadLine();