using Core.Abstractions;
using Core.Extensions;
using RabbitMQ.Client;

namespace Gateway.RabbitMQ
{
    public class Publisher : IBrokerPublisher<object>
    {
        private readonly Connection _connection;
        public Publisher(Connection connection) => _connection = connection;

        public void Publish(string topic, object message)
        {
            using (var channel = _connection.CreateChannel())
            {
                channel.QueueDeclare(
                    queue: topic, durable: false, exclusive: false, autoDelete: false,
                    arguments: null);

                var props = channel.CreateBasicProperties();

                props.ContentType = "application/json";
                props.DeliveryMode = 2;

                channel.BasicPublish(exchange: "", routingKey: topic,
                    basicProperties: props, body: message.ToByte());
            }
        }
    }
}