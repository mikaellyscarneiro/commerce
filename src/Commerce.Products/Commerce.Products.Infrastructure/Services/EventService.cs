using Commerce.Products.Application.V1.Dtos.External.EventContext.Common;
using Commerce.Products.Application.V1.Dtos.External.EventContext.Request;
using Commerce.Products.Application.V1.Interfaces.External.Services;
using Commerce.Products.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Commerce.Products.Infrastructure.Services
{
    public class EventService : IEventService
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly string _productsExchange;
        public EventService(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            _connectionFactory = CreateRabbitMqConnectionFactory(rabbitMqConfiguration);
            _productsExchange = rabbitMqConfiguration.Value.Exchanges?.ProductEvents ?? throw new ArgumentException("RabbitMQ ProductEvents exchange not provided.", nameof(rabbitMqConfiguration));
        }

        private static ConnectionFactory CreateRabbitMqConnectionFactory(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            var hostName = rabbitMqConfiguration.Value.HostName ?? throw new ArgumentException("RabbitMQ HostName not provided.", nameof(rabbitMqConfiguration));
            var userName = rabbitMqConfiguration.Value.UserName ?? throw new ArgumentException("RabbitMQ UserName not provided.", nameof(rabbitMqConfiguration));
            var port = rabbitMqConfiguration.Value.Port ?? throw new ArgumentException("RabbitMQ Port not provided.", nameof(rabbitMqConfiguration));
            var password = rabbitMqConfiguration.Value.Password ?? throw new ArgumentException("RabbitMQ Password not provided.", nameof(rabbitMqConfiguration));

            var factory = new ConnectionFactory
            {
                HostName = hostName,
                UserName = userName,
                Port = port,
                Password = password
            };

            return factory;
        }

        //TODO: Implementar declaração de exchanges ao iniciar a API.
        public static void DeclareExchanges(IOptions<RabbitMqConfiguration> rabbitMqConfiguration)
        {
            throw new NotImplementedException();
        }

        public async Task PublishAsync<T>(PublishEventDto<T> request)
        {
            var notifiableEvent = CreateNotifiableEvent(request);

            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            var message = JsonConvert.SerializeObject(notifiableEvent);
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(_productsExchange, request.Type, basicProperties: null, body);

            await Task.CompletedTask;
        }

        private static NotifiableEventDto CreateNotifiableEvent<T>(PublishEventDto<T> request)
        {
            var serializedValue = JsonConvert.SerializeObject(request.Value);
            var notifiableEvent = new NotifiableEventDto(request.Type, serializedValue);

            return notifiableEvent;
        }
    }
}
