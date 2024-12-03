using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;

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
}