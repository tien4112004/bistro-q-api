using BistroQ.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Core.Common.Builder;

public class OrderItemQueryableBuilder : BaseQueryableBuilder<OrderItem>
{
    public OrderItemQueryableBuilder(IQueryable<OrderItem> queryable) : base(queryable)
    {
    }

    public OrderItemQueryableBuilder IncludeOrder()
    {
        Queryable = Queryable.Include(o => o.Order);
        return this;
    }
    
    public OrderItemQueryableBuilder IncludeProduct()
    {
        Queryable = Queryable.Include(o => o.Product)
            .ThenInclude(p => p.Image);
        return this;
    }
    
    public OrderItemQueryableBuilder IncludeAll()
    {
        Queryable = Queryable.Include(o => o.Order)
            .ThenInclude(or=> or.Table)
            .ThenInclude(t => t.Zone)
            .Include(o => o.Product)
            .ThenInclude(p => p.Image);
        return this;
    }
    
    public OrderItemQueryableBuilder WithStatus(string[]? status)
    {
        if (status == null || !status.Any()) return this;
        
        Queryable = Queryable.Where(o => o.Status != null && status.Contains(o.Status));
        return this;
    }

    public OrderItemQueryableBuilder WithCreatedDateRange(DateTime? from, DateTime? to)
    {
        if (from.HasValue)
        {
            Queryable = Queryable.Where(o => o.CreatedAt >= from.Value);
        }

        if (to.HasValue)
        {
            Queryable = Queryable.Where(o => o.CreatedAt <= to.Value);
        }

        return this;
    }

    public OrderItemQueryableBuilder WithUpdatedDateRange(DateTime? from, DateTime? to)
    {
        if (from.HasValue)
        {
            Queryable = Queryable.Where(o => o.UpdatedAt >= from.Value);
        }

        if (to.HasValue)
        {
            Queryable = Queryable.Where(o => o.UpdatedAt <= to.Value);
        }

        return this;
    }

    public OrderItemQueryableBuilder ApplyPaging(int page, int size)
    {
        Queryable = Queryable.Skip((page - 1) * size).Take(size);
        
        return this;
    }
    
    public OrderItemQueryableBuilder ApplySorting(string? orderBy, string? orderDirection)
    {
        var isDescending = orderDirection != "asc";
        Queryable = orderBy switch
        {
            nameof(OrderItem.Status) => isDescending
                ? Queryable.OrderByDescending(o => o.Status)
                : Queryable.OrderBy(o => o.Status),
            
            nameof(OrderItem.CreatedAt) => isDescending
                ? Queryable.OrderByDescending(o => o.CreatedAt)
                : Queryable.OrderBy(o => o.CreatedAt),
            
            nameof(OrderItem.UpdatedAt) => isDescending
                ? Queryable.OrderByDescending(o => o.UpdatedAt)
                : Queryable.OrderBy(o => o.UpdatedAt),
            
            _ => Queryable.OrderBy(o => o.OrderItemId)
        };
        return this;
    }
}