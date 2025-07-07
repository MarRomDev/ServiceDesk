namespace ServiceDesk.Infrastructure.Messaging.Publisher;

/// <summary>
///     Interfejs do publikacji RabbitMq
/// </summary>
public interface IRabbitMqPublisher
{
    /// <summary>
    ///     Metoda przekazywania do servisu RabbitMq
    /// </summary>
    /// <param name="message"></param>
    /// <param name="routingKey"></param>
    /// <typeparam name="T"></typeparam>
    void Publish<T>(T message, string routingKey);
}