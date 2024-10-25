using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.API.Configurations;

public static class DatabaseConfigExtension
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        services.AddDbContext<BistroQContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        return services;
    }
}