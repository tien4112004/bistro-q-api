using BistroQ.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Core.Common.Builder;

public class ProductQueryableBuilder : BaseQueryableBuilder<Product>
{
    public ProductQueryableBuilder(IQueryable<Product> queryable) : base(queryable)
    {
    }
    
    public ProductQueryableBuilder IncludeCategory()
    {
        Queryable = Queryable.Include(p => p.Category);
        return this;
    }

    public ProductQueryableBuilder IncludeImage()
    {
        Queryable = Queryable.Include(p => p.Image);
        return this;
    }
    
    public ProductQueryableBuilder IncludeNutritionFact()
    {
        Queryable = Queryable.Include(p => p.NutritionFact);
        return this;
    }

    public ProductQueryableBuilder WithName(string? name)
    {
        if (name == null) return this;
        
        Queryable = Queryable.Where(p => p.Name != null && p.Name.Contains(name));
        return this;
    }
    
    public ProductQueryableBuilder WithCategoryId(int? categoryId)
    {
        if (categoryId == null) return this;
        
        Queryable = Queryable.Where(p => p.CategoryId == categoryId);
        return this;
    }
    
    public ProductQueryableBuilder WithPrice(decimal? price)
    {
        if (price == null) return this;
        
        Queryable = Queryable.Where(p => p.Price < price || p.DiscountPrice < price);
        return this;
    }
    
    public ProductQueryableBuilder WithUnit(string? unit)
    {
        if (unit == null) return this;
        
        Queryable = Queryable.Where(p => p.Unit != null && p.Unit.Contains(unit));
        return this;
    }

    public ProductQueryableBuilder ApplyPaging(int page, int size)
    {
        Queryable = Queryable.Skip((page - 1) * size).Take(size);
        
        return this;
    }
    
    public ProductQueryableBuilder ApplySorting(string? orderBy, string? orderDirection)
    {
        var isDescending = orderDirection != "asc";
        Queryable = orderBy switch
        {
            nameof(Product.Name) => isDescending
                ? Queryable.OrderByDescending(p => p.Name)
                : Queryable.OrderBy(p => p.Name),
            
            nameof(Product.Price) => isDescending
                ? Queryable.OrderByDescending(p => p.Price)
                : Queryable.OrderBy(p => p.Price),
            
            nameof(Product.Unit) => isDescending
                ? Queryable.OrderByDescending(p => p.Unit)
                : Queryable.OrderBy(p => p.Unit),
            
            nameof(Product.DiscountPrice) => isDescending
                ? Queryable.OrderByDescending(p => p.DiscountPrice)
                : Queryable.OrderBy(p => p.DiscountPrice),
            
            _ => Queryable.OrderBy(p => p.ProductId)
        };
        return this;
    }
}