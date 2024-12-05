using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;

namespace BistroQ.Services.Common;

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