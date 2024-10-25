using BistroQ.Infrastructure.Data;
using BistroQ.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace BistroQ.API.Configurations;

public static class IdentityConfig
{
    public static IServiceCollection AddIdentityConfig(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<BistroQContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}