using ServiceDesk.Infrastructure.Messaging.Events;
using ServiceDesk.Shared.Constants;
using ServiceDesk.Shared.Messaging.Interfaces;

namespace ServiceDesk.Infrastructure.Messaging.Registry;
/// <summary>
///     Klasa do rejestracji zdarzeń
/// </summary>
public abstract class MessageRegistry : IMessageRegistry
{
    private readonly IDictionary<string, Type> _map = new Dictionary<string, Type>()
    {
        {RoutingKeys.TicketCreated, typeof(TicketCreatedEvent)},
        {RoutingKeys.TicketClosed, typeof(TicketClosedEvent)}
    };

    /// <summary>
    ///     Pobiera typ zdarzenia
    /// </summary>
    /// <param name="routingKey"></param>
    /// <returns></returns>
    public Type? GetMessageType(string routingKey)
    {
        _map.TryGetValue(routingKey, out var type);
        return type;
    }

    /// <summary>
    ///     Pobieranie wszystkich kluczy routingu
    /// </summary>
    /// <returns></returns>
    public List<string> GetRoutingKeys()
    {
        return _map.Keys.ToList();
    }
}