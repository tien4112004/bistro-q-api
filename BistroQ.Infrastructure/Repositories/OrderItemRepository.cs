using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    private readonly BistroQContext _context;
    
    public OrderItemRepository(BistroQContext context) : base(context)
    {
        _context = context;
    }

    public async Task DeleteAsync(OrderItem entity)
    {
        entity.Status = OrderItemStatus.Cancelled;
        _context.OrderItems.Update(entity);
        await _context.SaveChangesAsync();
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