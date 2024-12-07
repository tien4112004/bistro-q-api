using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;

namespace BistroQ.Core.Interfaces.Services;

/// <summary>
/// Provides operations for managing order items in the restaurant POS system.
/// </summary>
public interface IOrderItemService
{
    /// <summary>
    /// Retrieves a paginated list of order items based on the specified query parameters.
    /// </summary>
    /// <param name="queryParams">Parameters for filtering, sorting, and pagination of order items.</param>
    /// <returns>
    /// A tuple containing:
    /// - Items: Collection of order items matching the query parameters
    /// - Count: Total number of items matching the query (before pagination)
    /// </returns>
    /// <remarks>
    /// The returned count represents the total number of items that match the filter criteria,
    /// not just the number of items in the current page.
    /// </remarks>
    public Task<(IEnumerable<DetailOrderItemDto> Items, int Count)> GetOrderItemsAsync(OrderItemCollectionQueryParams queryParams);
    
    /// <summary>
    /// Updates the status of multiple order items simultaneously.
    /// </summary>
    /// <param name="orderItemIds">Collection of order item IDs to update.</param>
    /// <param name="status">The new status to apply to all specified order items.</param>
    /// <returns>Collection of updated order items with their new status.</returns>
    /// <remarks>
    /// This operation:
    /// - Updates all specified order items atomically
    /// - Validates status transitions for each item
    /// - Returns the updated items in their new state
    /// </remarks>
    /// <exception cref="ConflictException">Thrown when any status transition is invalid.</exception>
    /// <exception cref="ResourceNotFoundException">Thrown when any of the specified order items cannot be found.</exception>
    public Task<IEnumerable<OrderItemDto>> UpdateOrderItemsStatusAsync(IEnumerable<string> orderItemIds, OrderItemStatus status);
}