using BistroQ.Core.Entities;
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
    
    
    
}