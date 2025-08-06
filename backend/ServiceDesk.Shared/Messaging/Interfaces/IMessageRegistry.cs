namespace ServiceDesk.Shared.Messaging.Interfaces;

/// <summary>
///     Interfejs registry
/// </summary>
public interface IMessageRegistry
{
    /// <summary>
    ///     Pobieranie typu na podstawie klucza
    /// </summary>
    /// <param name="routingKey"></param>
    /// <returns></returns>
    Type? GetMessageType(string routingKey);
    
    /// <summary>
    ///     Pobiera wszystkie klucze
    /// </summary>
    /// <returns></returns>
    List<string> GetRoutingKeys();
}