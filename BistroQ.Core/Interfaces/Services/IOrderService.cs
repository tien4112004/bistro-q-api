using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.Core.Interfaces.Services;

/// <summary>
/// Service interface for managing restaurant orders and their operations.
/// Provides high-level business logic for order management.
/// </summary>
public interface IOrderService 
{
    /// <summary>
    /// Creates a new order for a specific table.
    /// </summary>
    /// <param name="tableId">The unique identifier of the table.</param>
    /// <returns>A DTO containing the basic order information.</returns>
    /// <remarks>
    /// Consider whether multiple active orders per table should be allowed.
    /// </remarks>
    Task<OrderDto> CreateOrder(int tableId);
    
    /// <summary>
    /// Retrieves detailed information about the current order for a specific table.
    /// </summary>
    /// <param name="tableId">The unique identifier of the table.</param>
    /// <returns>A detailed DTO containing the order and its items.</returns>
    /// <remarks>
    /// Assumes only one active order per table exists.
    /// Consider using orderId instead of tableId for more flexibility.
    /// </remarks>
    Task<DetailOrderDto> GetOrder(int tableId);
    
    /// <summary>
    /// Deletes an order associated with a specific table.
    /// </summary>
    /// <param name="tableId">The unique identifier of the table.</param>
    /// <remarks>
    /// Consider adding a soft delete option or archiving for historical tracking.
    /// Should validate if the order can be deleted (e.g., not already paid).
    /// </remarks>
    Task DeleteOrder(int tableId);
    
    /// <summary>
    /// Retrieves all current orders in the system along with their table information.
    /// </summary>
    /// <returns>A collection of orders with their associated table details.</returns>
    /// <remarks>
    /// The definition of "current" orders should be clearly specified.
    /// Consider adding filtering options (by status, server, time range, etc.).
    /// </remarks>
    Task<IEnumerable<OrderWithTableDto>> GetAllCurrentOrders();
    
    /// <summary>
    /// Adds a product to an existing order.
    /// </summary>
    /// <param name="tableId">The unique identifier of the table.</param>
    /// <param name="orderItems">The list of products that needs to add.</param>
    /// <returns>Updated order details including the new product.</returns>
    /// <remarks>
    /// Consider adding quantity parameter.
    /// Should validate product availability and pricing.
    /// </remarks>
    Task<IEnumerable<OrderItemDto>> AddProductsToOrder(int tableId, [FromBody] IEnumerable<CreateOrderItemRequestDto> orderItems);

    Task<IEnumerable<OrderItemDto>> CancelOrderItems(int tableId, [FromBody] IEnumerable<RemoveOrderItemRequestDto> orderItems);
    
    /// <summary>
    /// Updates the quantity of a product in an existing order.
    /// </summary>
    /// <param name="tableId">The unique identifier of the table.</param>
    /// <param name="productId">The unique identifier of the product to update.</param>
    /// <returns>Updated order details with the new quantity.</returns>
    /// <remarks>
    /// Missing quantity parameter - should be added.
    /// Should validate if quantity update is allowed (e.g., kitchen status).
    /// </remarks>
    Task<DetailOrderDto> UpdateProductQuantity(int tableId, int productId);
}