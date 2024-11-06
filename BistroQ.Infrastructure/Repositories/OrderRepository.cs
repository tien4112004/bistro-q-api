using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly BistroQContext _context;
    
    public OrderRepository(BistroQContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Order?> GetByTableIdAsync(int tableId)
    {
        return await _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .FirstOrDefaultAsync(o => o.TableId == tableId);
    }
}