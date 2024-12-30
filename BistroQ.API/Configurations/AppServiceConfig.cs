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
        services.AddScoped<IZoneRepository, ZoneRepository>();
        services.AddScoped<IZoneService, ZoneService>();
        services.AddScoped<ITableRepository, TableRepository>();
        services.AddScoped<ITableService, TableService>();
        services.AddScoped<IImageRepository, ImageRepository>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<INutritionFactRepository, NutritionFactRepository>();
        services.AddScoped<IPaymentService, PaymentService>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITokenService, TokenService>();
                        
        services.AddSingleton(new JwtSettings().ReadFromEnvironment());
        
        return services;
    }
}