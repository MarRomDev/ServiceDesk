using ServiceDesk.Infrastructure.Messaging.Events;
using ServiceDesk.Shared.Constants;

namespace ServiceDesk.Infrastructure.Messaging.Registry;
/// <summary>
///     Klasa do rejestracji zdarzeń
/// </summary>
public abstract class MessageClassRegistry
{
    private readonly IDictionary<string, Type> _map = new Dictionary<string, Type>()
    {
        {RoutingKeys.TicketCreated, typeof(TickedCreatedEvent)},
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