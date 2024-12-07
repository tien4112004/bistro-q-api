using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;

namespace BistroQ.Services.Common;

/// <summary>
/// Manages the status transitions for order items in the restaurant POS system.
/// This class enforces valid state transitions and prevents invalid status updates.
/// </summary>
/// <remarks>
/// The class maintains a predefined set of valid status transitions.
/// Current valid transitions are:
/// - Pending → InProgress, Cancelled
/// - InProgress → Pending, Completed
/// Any other transitions will result in a ConflictException.
/// </remarks>
public class OrderItemStatusTransition
{
    private static readonly Dictionary<OrderItemStatus, HashSet<OrderItemStatus>> AllowedTransitions = new()
    {
        [OrderItemStatus.Pending] = new HashSet<OrderItemStatus> 
        { 
            OrderItemStatus.InProgress, 
            OrderItemStatus.Cancelled 
        },
        [OrderItemStatus.InProgress] = new HashSet<OrderItemStatus> 
        { 
            OrderItemStatus.Pending, 
            OrderItemStatus.Completed 
        }
    };

    /// <summary>
    /// Updates the status of an order item while enforcing valid state transitions.
    /// </summary>
    /// <param name="orderItem">The order item to update. Must not be null.</param>
    /// <param name="newStatus">The new status to apply to the order item.</param>
    /// <exception cref="ArgumentNullException">Thrown when orderItem is null.</exception>
    /// <exception cref="ConflictException">Thrown when attempting an invalid status transition.</exception>
    /// <remarks>
    /// The method will:
    /// 1. Skip update if the new status is the same as current status
    /// 2. Validate if the transition is allowed
    /// 3. Update the status and timestamp if valid
    /// </remarks>
    public static void UpdateStatus(OrderItem orderItem, OrderItemStatus newStatus)
    {
        if (orderItem.Status == newStatus)
            return;

        if (!IsValidTransition(orderItem.Status, newStatus))
        {
            throw new ConflictException(
                $"Invalid status transition (from: {orderItem.Status}, to: {newStatus}).");
        }

        ApplyStatusUpdate(orderItem, newStatus);
    }

    private static bool IsValidTransition(OrderItemStatus currentStatus, OrderItemStatus newStatus)
    {
        return AllowedTransitions.ContainsKey(currentStatus) && 
               AllowedTransitions[currentStatus].Contains(newStatus);
    }

    private static void ApplyStatusUpdate(OrderItem orderItem, OrderItemStatus newStatus)
    {
        orderItem.Status = newStatus;
        orderItem.UpdatedAt = DateTime.Now;
    }
}