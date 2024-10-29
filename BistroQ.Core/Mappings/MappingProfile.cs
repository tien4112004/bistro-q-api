using AutoMapper;
using BistroQ.Core.Dtos.Products;
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
    }
}