using AutoMapper;
using BistroQ.Core.Dtos.Auth;
using BistroQ.Core.Dtos.Category;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Dtos.Image;
using BistroQ.Core.Dtos.NutritionFact;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Dtos.Zones;
using BistroQ.Core.Dtos.NutritionFact;
using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BistroQ.Core.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateProductRequestDto, Product>()
            .ConstructUsing((src, context) => new Product())
            .AfterMap((src, dest, context) => 
            {
                if (dest.NutritionFact == null)
                {
                    dest.NutritionFact = new NutritionFact();
                }
                dest.NutritionFact.Calories = src.Calories;
                dest.NutritionFact.Fat = src.Fat;
                dest.NutritionFact.Fiber = src.Fiber;
                dest.NutritionFact.Protein = src.Protein;
                dest.NutritionFact.Carbohydrates = src.Carbohydrates;
            });

        CreateMap<UpdateProductRequestDto, Product>()
            .ConstructUsing((src, context) => new Product())
            .AfterMap((src, dest, context) => 
            {
                if (dest.NutritionFact == null)
                {
                    dest.NutritionFact = new NutritionFact();
                }
                dest.NutritionFact.Calories = src.Calories;
                dest.NutritionFact.Fat = src.Fat;
                dest.NutritionFact.Fiber = src.Fiber;
                dest.NutritionFact.Protein = src.Protein;      
                dest.NutritionFact.Carbohydrates = src.Carbohydrates;
            });
        CreateMap<Product, ProductResponseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<ImageUrlResolver>());
        CreateMap<NutritionFact, NutritionFactDto>().ReverseMap();
            
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
        CreateMap<Zone, ZoneCashierDto>()
            .ForMember(dest => dest.HasCheckingOutTables, opt => opt.MapFrom(src => src.Tables.Any(t => t.Order != null && t.Order.Status == OrderStatus.Pending)));
        CreateMap<CreateZoneRequestDto, Zone>().ConstructUsing((src, context) => new Zone());
        CreateMap<UpdateZoneRequestDto, Zone>().ConstructUsing((src, context) => new Zone());

        CreateMap<Table, TableDto>().ReverseMap();
        CreateMap<CreateTableRequestDto, Table>().ConstructUsing((src, context) => new Table());
        CreateMap<UpdateTableRequestDto, Table>().ConstructUsing((src, context) => new Table());
        CreateMap<Table, TableDetailDto>().ForMember(dest => dest.ZoneName,
                opt => opt.MapFrom(src => src.Zone == null ? null : src.Zone.Name))
            .ForMember(dest => dest.IsOccupied, opt => opt.MapFrom(src => src.Order != null))
            .ForMember(dest => dest.IsCheckingOut,
                opt => opt.MapFrom(src => src.Order != null && src.Order.Status == OrderStatus.Pending));

        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, DetailOrderDto>().ForMember(v => v.OrderItems,
            opt => opt.MapFrom(src => src.OrderItems));
        CreateMap<Order, OrderWithTableDto>();
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        CreateMap<OrderItem, OrderItemWithProductDto>();
        CreateMap<OrderItem, DetailOrderItemDto>()
            .ForMember(dest => dest.Table, opt => opt.MapFrom(src => src.Order.Table));

        CreateMap<AccountDto, AccountResponseDto>()
            .ForMember(dest => dest.Table, opt => opt.MapFrom(src => src.Table));
    }
}