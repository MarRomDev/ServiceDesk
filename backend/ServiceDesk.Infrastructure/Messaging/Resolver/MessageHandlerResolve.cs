using ServiceDesk.Infrastructure.Messaging.Common;

namespace ServiceDesk.Infrastructure.Messaging.Resolver;

/// <summary>
///     Klasa do resolwowania wiadomości
/// </summary>
/// <param name="provider"></param>
public class MessageHandlerResolve(IServiceProvider provider) : IMessageHandlerResolve
{
    /// <summary>
    ///     Metoda resolwująca
    /// </summary>
    /// <param name="messageType"></param>
    /// <returns></returns>
    public object? Resolve(Type messageType)
    {
        var handlerType = typeof(IMessageHandler<>).MakeGenericType(messageType);
        return provider.GetService(handlerType);  
    }
}