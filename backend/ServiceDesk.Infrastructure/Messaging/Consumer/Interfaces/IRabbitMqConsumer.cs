namespace ServiceDesk.Infrastructure.Messaging.Consumer.Interfaces;

/// <summary>
///     Interfejs do odbierania komunikatów
/// </summary>
public interface IRabbitMqConsumer
{
    /// <summary>
    /// Metoda do obsługi komunikatów
    /// </summary>
    void StartConsume();
}