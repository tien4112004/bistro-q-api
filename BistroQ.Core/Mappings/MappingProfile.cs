using AutoMapper;
using BistroQ.Core.Dtos.Category;
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

        CreateMap<Category, CategoryDto>().ReverseMap();

        CreateMap<Category, CategoryDetailDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

        CreateMap<CreateCategoryRequestDto, Category>()
            .ConstructUsing((src, context) => new Category());
        
        CreateMap<UpdateCategoryRequestDto, Category>()
            .ConstructUsing((src, context) => new Category());
    }
}