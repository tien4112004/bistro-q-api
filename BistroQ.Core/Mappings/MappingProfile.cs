using AutoMapper;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Dtos.Tables;
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
        CreateMap<Zone, ZoneDetailDto>().ReverseMap();
        CreateMap<CreateZoneRequestDto, Zone>().ConstructUsing((src, context) => new Zone());
        CreateMap<UpdateZoneRequestDto, Zone>().ConstructUsing((src, context) => new Zone());
        // CreateMap<ZoneDetailDto, Zone>().ConstructUsing((src, context) => new Zone());
        
        CreateMap<Table, TableDto>().ReverseMap();
        CreateMap<CreateTableRequestDto, Table>().ConstructUsing((src, context) => new Table());
        CreateMap<UpdateTableRequestDto, Table>().ConstructUsing((src, context) => new Table());
    }
}