using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Repositories;

public interface IOrderRepository : IGenericRepository<Order>
{
    public Task<Order?> GetByTableIdAsync(int tableId);
}