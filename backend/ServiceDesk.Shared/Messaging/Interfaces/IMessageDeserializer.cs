using System.Text.Json;

namespace ServiceDesk.Shared.Messaging.Interfaces;
/// <summary>
///     Interfejs do deserializacji
/// </summary>
public interface IMessageDeserializer
{
    /// <summary>
    ///     Deserializuje ze stringa
    /// </summary>
    /// <param name="json"></param>
    /// <param name="type"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    object?  Deserialize(string json, Type type, JsonSerializerOptions? options = null);
}