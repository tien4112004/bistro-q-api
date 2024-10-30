using BistroQ.Core.Common.Settings;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Infrastructure.Repositories;
using BistroQ.Infrastructure.UnitOfWork;
using BistroQ.Services.Services;

namespace BistroQ.API.Configurations;

public static class AppServiceConfigExtension
{
    public static IServiceCollection AddAppServiceConfig(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddSingleton(new JwtSettings().ReadFromEnvironment());
        
        return services;
    }
}