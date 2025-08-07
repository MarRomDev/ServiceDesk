using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceDesk.Application;
using ServiceDesk.Infrastructure.Constants;
using ServiceDesk.Infrastructure.Messaging.Publisher;
using ServiceDesk.Infrastructure.Messaging.Registry;
using ServiceDesk.Infrastructure.Messaging.Serialization;
using ServiceDesk.Infrastructure.Messaging.Settings;
using ServiceDesk.Persistence.DbContext;
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
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<IApplicationAssemblyMarker>();
        });
        services.AddAutoMapper(typeof(IApplicationAssemblyMarker));
        services.AddDbContext<ServiceDeskDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ServiceDeskDatabase"));
        });
        
        return services;
    }
}