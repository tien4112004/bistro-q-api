using AutoMapper;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Entities;
using BistroQ.Core.Mappings;

namespace BistroQ.API.Configurations;

public static class AutoMapperConfig
{
    public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper((serviceProvider, cfg) =>
        {
            cfg.AddProfile<MappingProfile>();
            cfg.ConstructServicesUsing(type => 
                ActivatorUtilities.CreateInstance(serviceProvider, type));
        }, typeof(MappingProfile).Assembly);

        services.AddScoped<IValueResolver<Product, ProductResponseDto, string>, ImageUrlResolver>();

        return services;
    }
}