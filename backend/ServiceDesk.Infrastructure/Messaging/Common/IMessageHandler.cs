namespace ServiceDesk.Infrastructure.Messaging.Common;

/// <summary>
///     Handler do wykonywania metod
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMessageHandler<T>
{
    /// <summary>
    ///     Asynchroniczna medoda handlera
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    Task HandleAsync(T message);
}