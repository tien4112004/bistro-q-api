using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;
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
            .FirstOrDefaultAsync(o => o.TableId == tableId);
    }
    
    public async Task<IEnumerable<Order>> GetAllCurrentOrdersAsync()
    {
        return await _context.Orders
            .Include(o => o.Table)
            .Where(o => o.EndTime == null)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<OrderItem>> AddProductsToOrderAsync(string orderId, IEnumerable<CreateOrderItemRequestDto> orderItems)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
    
        if (order == null)
        {
            throw new ResourceNotFoundException("Order not found");
        }
    
        var addedItems = new List<OrderItem>();
    
        foreach (var item in orderItems)
        {
            var product = await _context.Products.FindAsync(item.ProductId);
            if (product == null)
            {
                throw new ResourceNotFoundException("Product not found");
            }
    
            var orderItem = new OrderItem
            {
                OrderId = order.OrderId,
                ProductId = product.ProductId,
                Quantity = item.Quantity,
                PriceAtPurchase = product.DiscountPrice ?? product.Price,
            };
    
            _context.OrderItems.Add(orderItem);
            addedItems.Add(orderItem);
        }
    
        await _context.SaveChangesAsync();
    
        return addedItems;
    }
}