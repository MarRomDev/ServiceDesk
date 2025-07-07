using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceDesk.Infrastructure.Constants;
using ServiceDesk.Infrastructure.Messaging.Publisher;
using ServiceDesk.Infrastructure.Messaging.Settings;

namespace ServiceDesk.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RabbitMqSettings>(
            configuration.GetSection(ConfigurationSectionNames.RabbitMq)
        );
        services.AddSingleton<IRabbitMqPublisher, RabbitMqPublisher>();
        
        return services;
    }
}