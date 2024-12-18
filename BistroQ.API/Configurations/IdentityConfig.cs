using BistroQ.Core.Entities;
using BistroQ.Infrastructure.Data;
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