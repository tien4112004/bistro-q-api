using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(BistroQContext context) : base(context)
    {
    }


    public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(IQueryable<OrderItem> queryable)
    {
        var orderItems = await queryable.ToListAsync();
        
        return orderItems;
    }

    public async Task<int> GetOrderItemsCountAsync(IQueryable<OrderItem> queryable)
    {
        var count = await queryable.CountAsync();
        
        return count;
    }
}