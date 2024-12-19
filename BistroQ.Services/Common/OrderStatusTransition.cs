using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;

namespace BistroQ.Services.Common;

/// <summary>
/// Manages the status transitions for orders in the restaurant POS system.
/// This class enforces valid state transitions and prevents invalid status updates.
/// </summary>
/// <remarks>
/// The class maintains a predefined set of valid status transitions.
/// Current valid transitions are:
/// - Pending → InProgress, Cancelled
/// - InProgress → Pending, Completed
/// Any other transitions will result in a ConflictException.
/// </remarks>
public class OrderStatusTransition
{
    private static readonly Dictionary<OrderStatus, HashSet<OrderStatus>> AllowedTransitions = new()
    {
        [OrderStatus.Pending] = new HashSet<OrderStatus> 
        { 
            OrderStatus.Completed, 
        },
        [OrderStatus.InProgress] = new HashSet<OrderStatus> 
        { 
            OrderStatus.Pending 
        },
        [OrderStatus.Completed] = new HashSet<OrderStatus>()
    };

    /// <summary>
    /// Updates the status of an order while enforcing valid state transitions.
    /// </summary>
    /// <param name="order">The order to update. Must not be null.</param>
    /// <param name="newStatus">The new status to apply to the order.</param>
    /// <exception cref="ArgumentNullException">Thrown when order is null.</exception>
    /// <exception cref="ConflictException">Thrown when attempting an invalid status transition.</exception>
    /// <remarks>
    /// The method will:
    /// 1. Skip update if the new status is the same as current status
    /// 2. Validate if the transition is allowed
    /// 3. Update the status and timestamp if valid
    /// </remarks>
    public static void UpdateStatus(Order order, OrderStatus newStatus)
    {
        if (order.Status == newStatus)
            return;

        if (!IsValidTransition(order.Status, newStatus))
        {
            throw new ConflictException(
                $"Invalid status transition (from: {order.Status}, to: {newStatus}).");
        }

        ApplyStatusUpdate(order, newStatus);
    }

    private static bool IsValidTransition(OrderStatus currentStatus, OrderStatus newStatus)
    {
        return AllowedTransitions.ContainsKey(currentStatus) && 
               AllowedTransitions[currentStatus].Contains(newStatus);
    }

    private static void ApplyStatusUpdate(Order order, OrderStatus newStatus)
    {
        order.Status = newStatus;
        if (newStatus == OrderStatus.Completed)
        {
            order.EndTime = DateTime.Now;
        }
    }
}