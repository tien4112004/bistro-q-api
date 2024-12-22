using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;
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
            .Include(o => o.OrderItems)
                .ThenInclude(od => od.Product)
                .ThenInclude(p => p.Image)
            .Select(o => new Order
            {
                OrderId = o.OrderId,
                TableId = o.TableId,
                OrderItems = o.OrderItems.OrderByDescending(oi => oi.CreatedAt).ToList(),
                TotalAmount = o.TotalAmount,
                StartTime = o.StartTime,
                EndTime = o.EndTime,
                PeopleCount = o.PeopleCount,
                Status = o.Status
            })
            .FirstOrDefaultAsync(o => o.TableId == tableId);
    }
    
    public async Task<IEnumerable<Order>> GetAllCurrentOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.Table)
            .Where(o => o.EndTime == null)
            .ToListAsync();
    }
}