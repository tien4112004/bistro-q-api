using AutoMapper;
using BistroQ.Core.Dtos.Category;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Dtos.Image;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Dtos.Zones;
using BistroQ.Core.Entities;
using BistroQ.Services.Services;
using Microsoft.Extensions.DependencyInjection;

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
        CreateMap<Product, ProductResponseDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<ImageUrlResolver>());

        CreateMap<ImageDto, Image>();
        CreateMap<ImageRequestDto, Image>()
            .ConstructUsing((src, context) => new Image());
        CreateMap<ImageRequestDto, ImageDto>();
        
        
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryDetailDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
        CreateMap<CreateCategoryRequestDto, Category>()
            .ConstructUsing((src, context) => new Category());
        CreateMap<UpdateCategoryRequestDto, Category>()
            .ConstructUsing((src, context) => new Category());
        
        CreateMap<Zone, ZoneDto>().ReverseMap();
        CreateMap<Zone, ZoneDetailDto>().ReverseMap();
        CreateMap<CreateZoneRequestDto, Zone>().ConstructUsing((src, context) => new Zone());
        CreateMap<UpdateZoneRequestDto, Zone>().ConstructUsing((src, context) => new Zone());
        
        CreateMap<Table, TableDto>().ReverseMap();
        CreateMap<CreateTableRequestDto, Table>().ConstructUsing((src, context) => new Table());
        CreateMap<UpdateTableRequestDto, Table>().ConstructUsing((src, context) => new Table());
        CreateMap<Table, TableDetailDto>().ForMember(dest => dest.ZoneName,
            opt => opt.MapFrom(src => src.Zone == null ? null : src.Zone.Name));
        
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, OrderInDetailDto>().ForMember(v => v.OrderDetails, 
            opt => opt.MapFrom(src => src.OrderDetails));
        CreateMap<Order, OrderWithTableDto>();
        CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        CreateMap<OrderDetail, OrderDetailWithProductDto>();
    }
}