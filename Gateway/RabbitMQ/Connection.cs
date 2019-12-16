using Core.Abstractions;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;

namespace Gateway.RabbitMQ
{
    public class Connection : IBrokerConnection<IModel>, IDisposable
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connection;
        public Connection(IConfiguration config)
        {
            var rabbitmq = config.GetSection("RabbitMQ").Get<Config>();
            _factory = new ConnectionFactory()
            {
                HostName = rabbitmq.Host,
                Port = rabbitmq.Port,
                UserName = rabbitmq.Username,
                Password = rabbitmq.Password
            };
        }

        private IConnection Get()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                _connection = _factory.CreateConnection();
            }
            return _connection;
        }
        
        public IModel CreateChannel()
        {
            return this.Get().CreateModel();
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
            }
            _connection = null;
        }
    }
}