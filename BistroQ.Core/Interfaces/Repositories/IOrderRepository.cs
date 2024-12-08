using System.Collections;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Repositories;


/// <summary>
/// Repository interface for managing restaurant orders in the database.
/// Extends the generic repository pattern with order-specific operations.
/// </summary>
public interface IOrderRepository : IGenericRepository<Order>
{
    /// <summary>
    /// Retrieves the active order associated with a specific table.
    /// </summary>
    /// <param name="tableId">The unique identifier of the table.</param>
    /// <returns>
    /// Returns the current Order if found; otherwise, returns null.
    /// </returns>
    /// <remarks>
    /// This method assumes only one active order per table.
    /// Consider using GetOrdersByTableIdAsync if multiple orders per table are needed.
    /// </remarks>
    Task<Order?> GetByTableIdAsync(int tableId);
    
    /// <summary>
    /// Retrieves all current orders in the system.
    /// </summary>
    /// <returns>
    /// A collection of active orders.
    /// </returns>
    /// <remarks>
    /// The definition of "current" orders should be clearly specified in the implementation.
    /// Consider adding filters for specific order statuses.
    /// </remarks>
    Task<IEnumerable<Order>> GetAllCurrentOrdersAsync();
}