using System.Collections.Concurrent;
using System.Reflection;
using ServiceDesk.Infrastructure.Constants;

namespace ServiceDesk.Infrastructure.Messaging.Cache;

/// <summary>
///  Klasa do pobierania metody z cache
/// </summary>
public static class HandlerMethodCache
{
    private static readonly ConcurrentDictionary<Type, MethodInfo?> Cache = new();

    /// <summary>
    ///     Pobiera metodę na podstawie typu
    /// </summary>
    /// <param name="handlerType"></param>
    /// <returns></returns>
    public static MethodInfo? GetHandleAsyncMethod(Type handlerType)
    {
        return Cache.GetOrAdd(handlerType, type => 
            type.GetMethod(MethodsNames.HandleAsync)
        );
    }
}