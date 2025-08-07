namespace ServiceDesk.Infrastructure.Messaging.Common;

/// <summary>
///     Interfejs do resolwowania handlera
/// </summary>
public interface IMessageHandlerResolve
{
    /// <summary>
    ///     Metoda resolwująca
    /// </summary>
    /// <param name="messageType"></param>
    /// <returns></returns>
    object? Resolve(Type messageType);
}