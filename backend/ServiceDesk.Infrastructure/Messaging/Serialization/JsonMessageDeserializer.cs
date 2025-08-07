using System.Text.Json;
using ServiceDesk.Shared.Messaging.Interfaces;

namespace ServiceDesk.Infrastructure.Messaging.Serialization;

/// <summary>
///     Serwis do deserializacji danych json
/// </summary>
public class JsonMessageDeserializer : IMessageDeserializer
{
    public object? Deserialize(string json, Type type, JsonSerializerOptions? options = null)
    {
        return  JsonSerializer.Deserialize(json, type, options);
    }
}