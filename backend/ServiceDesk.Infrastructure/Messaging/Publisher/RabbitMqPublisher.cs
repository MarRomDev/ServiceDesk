using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using ServiceDesk.Infrastructure.Messaging.Settings;

namespace ServiceDesk.Infrastructure.Messaging.Publisher;

public class RabbitMqPublisher : IRabbitMqPublisher
{

    private readonly RabbitMqSettings _settings;
    private readonly IConnection _connection;
    private readonly IModel _model;

    public RabbitMqPublisher(IOptions<RabbitMqSettings> options)
    {
        _settings = options.Value;

        var factory = new ConnectionFactory()
        {
            HostName = _settings.Host,
            Port = _settings.Port,
            UserName = _settings.Username,
            Password = _settings.Password,
        };

        _connection = factory.CreateConnection();
        _model = _connection.CreateModel();

        _model.ExchangeDeclare(
            exchange: _settings.Exchange,
            type: ExchangeType.Topic,
            durable: true,
            autoDelete: false
        );
    }

    
    public void Publish<T>(T message, string routingKey)
    {
        var body = JsonSerializer.SerializeToUtf8Bytes(message);
        
        _model.BasicPublish(exchange: _settings.Exchange, routingKey: routingKey, body: body, basicProperties: null);
    }
}