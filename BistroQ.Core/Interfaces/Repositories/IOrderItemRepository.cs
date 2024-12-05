using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Repositories;

public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    public Task<IEnumerable<OrderItem>> GetOrderItemsAsync(IQueryable<OrderItem> queryable);
    
    public Task<int> GetOrderItemsCountAsync(IQueryable<OrderItem> queryable);
}