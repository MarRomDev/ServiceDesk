using MediatR;
using ServiceDesk.Infrastructure.Messaging.Consumer.Interfaces;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ServiceDesk.Infrastructure.Messaging.Common;
using ServiceDesk.Infrastructure.Messaging.Settings;
using ServiceDesk.Shared.Extensions;
using ServiceDesk.Shared.Messaging.Interfaces;

namespace ServiceDesk.Infrastructure.Messaging.Consumer.Services;

/// <summary>
///     Serwis do obsługi konsumenta
/// </summary>
public class RabbitMqConsumerService : IRabbitMqConsumer
{
    private readonly ILogger<RabbitMqConsumerService> _logger;
    private readonly IModel _channel;
    private readonly IMessageHandlerResolve _handlerResolve;
    private readonly IMessageRegistry _registry;
    private readonly RabbitMqSettings _settings;
    private readonly IMessageDeserializer _deserializer;
    private readonly IMediator _mediator;

    public RabbitMqConsumerService(ILogger<RabbitMqConsumerService> logger, IMessageHandlerResolve handlerResolve,
        IMessageRegistry registry, RabbitMqSettings settings, IMessageDeserializer deserializer, IMediator mediator)
    {
        _logger = logger;
        _handlerResolve = handlerResolve;
        _registry = registry;
        _settings = settings;
        _deserializer = deserializer;
        _mediator = mediator;

        var factory = new ConnectionFactory()
        {
            HostName = settings.Host,
            Port = settings.Port,
            UserName = settings.Username,
            Password = settings.Password,
        };

        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
    }

    public void StartConsume(CancellationToken cancellationToken = default)
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.Received += async (_, ea) => { await ProcessMessage(ea, cancellationToken); };

        foreach (var routingKey in _registry.GetRoutingKeys())
        {
            _channel.QueueDeclare(routingKey, true, false, false, null);
            _channel.QueueBind(routingKey, _settings.Exchange, routingKey);

            _channel.BasicConsume(routingKey, false, consumer);
        }
    }

    private async Task ProcessMessage(BasicDeliverEventArgs ea, CancellationToken cancellationToken)
    {
        var routingKey = ea.RoutingKey;
        var messageType = _registry.GetMessageType(routingKey);

        if (messageType == null)
        {
            _logger.LogError($"Message type {routingKey} not found");
            return;
        }

        var json = ea.Body.ToArray().ToUtf8String();

        try
        {
            var message = _deserializer.Deserialize(json, messageType);
            if (message == null)
            {
                _channel.BasicAck(ea.DeliveryTag, false);
                return;
            }

            if (typeof(IRequest).IsAssignableFrom(messageType) || messageType.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>)))
            {
                var response = await _mediator.Send(message, cancellationToken);

                if (!string.IsNullOrWhiteSpace(ea.BasicProperties.ReplyTo))
                {
                    var props = _channel.CreateBasicProperties();
                    props.CorrelationId = ea.BasicProperties.CorrelationId;

                    var responseBytes = response.SerializeToUtf8Bytes();
                    _channel.BasicPublish(exchange: "", routingKey: ea.BasicProperties.ReplyTo, basicProperties: props,
                        body: responseBytes);
                }
                _channel.BasicAck(ea.DeliveryTag, false);
            }
            else
            {
                RejectMessage("Wiadomość nie implementuje IRequest ani IRequest<T>", ea);
            }

        }
        catch (Exception e)
        {
            _logger.LogError(e, "Błąd w trakcie procesownia wiadomości");
        }
    }

    /// <summary>
    ///     Metoda do zamykania połączenia
    /// </summary>
    /// <param name="message"></param>
    /// <param name="ea"></param>
    private void RejectMessage(string message, BasicDeliverEventArgs ea)
    {
        _logger.LogError(message);
        _channel.BasicNack(ea.DeliveryTag, false, true);
    }
}