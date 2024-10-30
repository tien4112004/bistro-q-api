using System.Text.Json.Serialization;

namespace BistroQ.API.Configurations;

public static class ApiConfiguration
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddEndpointsApiExplorer();
        return services;
    }
}