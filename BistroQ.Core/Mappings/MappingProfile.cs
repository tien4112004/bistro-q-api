using AutoMapper;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Dtos.Zones;
using BistroQ.Core.Entities;

namespace BistroQ.Core.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();

        CreateMap<CreateProductRequestDto, Product>()
            .ConstructUsing((src, context) => new Product());

        CreateMap<UpdateProductRequestDto, Product>()
            .ConstructUsing((src, context) => new Product());
        
        CreateMap<Zone, ZoneDto>().ReverseMap();

        CreateMap<CreateZoneRequestDto, Zone>().ConstructUsing((src, context) => new Zone());

        CreateMap<UpdateZoneRequestDto, Zone>().ConstructUsing((src, context) => new Zone());

        // CreateMap<CreateZoneRequestDto, Zone>()
        //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        //
        // CreateMap<UpdateZoneRequestDto, Zone>()
        //     .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}