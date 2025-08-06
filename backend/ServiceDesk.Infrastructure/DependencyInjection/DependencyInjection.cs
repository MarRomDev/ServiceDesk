using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceDesk.Infrastructure.Constants;
using ServiceDesk.Infrastructure.Messaging.Publisher;
using ServiceDesk.Infrastructure.Messaging.Registry;
using ServiceDesk.Infrastructure.Messaging.Serialization;
using ServiceDesk.Infrastructure.Messaging.Settings;
using ServiceDesk.Shared.Messaging.Interfaces;

namespace ServiceDesk.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqSettings>(
            configuration.GetSection(ConfigurationSectionNames.RabbitMq)
        );
        services.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();
        services.AddSingleton<IMessageDeserializer, JsonMessageDeserializer>();
        services.AddSingleton<IMessageRegistry, MessageRegistry>();
        
        return services;
    }
}