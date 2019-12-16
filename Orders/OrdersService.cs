using Core.Constants;
using Core.Entities;
using Gateway.RabbitMQ;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCase.Commands;

namespace Orders
{
    public class OrdersService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Connection _connection;
        private readonly IModel _channel;

        public OrdersService(IServiceProvider serviceProvider, Connection connection)
        {
            _serviceProvider = serviceProvider;
            _connection = connection;
            _channel = _connection.CreateChannel();
            _channel.QueueDeclare(
                queue: BrokerEvents.ORDER, durable: true, exclusive: false, autoDelete: false,
                arguments: null
            );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (ch, ea) =>
            {
                var body = Encoding.UTF8.GetString(ea.Body);
                var order = JsonConvert.DeserializeObject<Order>(body);
                
                using (var scope = _serviceProvider.CreateScope())
                {
                    var createOrder = scope.ServiceProvider.GetService<CreateOrder>();
                    var result = await createOrder.Execute(order);

                    if (result.Error == null)
                    {
                        _channel.BasicAck(ea.DeliveryTag, false);
                    }
                    else
                    {
                        _channel.BasicNack(ea.DeliveryTag, false, true);
                    }
                }
            };

            _channel.BasicConsume(BrokerEvents.ORDER, false, consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            base.Dispose();
        }
    }
}