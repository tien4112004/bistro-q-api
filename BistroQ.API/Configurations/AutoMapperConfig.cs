using AutoMapper;
using BistroQ.Core.Mappings;

namespace BistroQ.API.Configurations;

public static class AutoMapperConfig
{
    public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        services.AddScoped<IMapper>(sp => new AutoMapper.Mapper(config));
        
        return services;
    }
}