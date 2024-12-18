using BistroQ.Core.Entities;
using BistroQ.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace BistroQ.API.Configurations;

public static class IdentityConfig
{
    public static IServiceCollection AddIdentityConfig(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
    
                options.Password.RequiredLength = 5;
            })
            .AddEntityFrameworkStores<BistroQContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}