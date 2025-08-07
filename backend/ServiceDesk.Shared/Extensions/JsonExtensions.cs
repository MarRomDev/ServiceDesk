using System.Text;
using System.Text.Json;

namespace ServiceDesk.Shared.Extensions;

/// <summary>
///     Rozszerzenie do metod Json
/// </summary>
public static class JsonExtensions
{
    /// <summary>
    ///     Serializacja do Jsona
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string ToJson<T>(this T obj, JsonSerializerOptions? options = null) =>
        JsonSerializer.Serialize(obj, options);

    /// <summary>
    ///     Deserializacja z Jsona
    /// </summary>
    /// <param name="json"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? FromJson<T>(this string json, JsonSerializerOptions? options = null) =>
        JsonSerializer.Deserialize<T>(json, options);
    
    /// <summary>
    ///     Deserializacja względem typu
    /// </summary>
    /// <param name="json"></param>
    /// <param name="messageType"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static object? FromJson(this string json, Type messageType, JsonSerializerOptions? options = null) =>
        JsonSerializer.Deserialize(json, messageType, options);

    /// <summary>
    ///     Deserializacja byte
    /// </summary>
    /// <param name="data"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? Deserialize<T>(this byte[] data, JsonSerializerOptions? options = null) =>
        JsonSerializer.Deserialize<T>(data, options);

    /// <summary>
    ///     Serializacja do byte
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static byte[] SerializeToUtf8Bytes<T>(this T obj, JsonSerializerOptions? options = null)
        => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(obj, options));
}