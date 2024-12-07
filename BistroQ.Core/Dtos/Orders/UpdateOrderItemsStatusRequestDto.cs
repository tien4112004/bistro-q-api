using BistroQ.Core.Enums;

namespace BistroQ.Core.Dtos.Orders;

public class UpdateOrderItemsStatusRequestDto
{
    public IEnumerable<string> OrderItemIds { get; set; } = null!;
    
    public OrderItemStatus Status { get; set; }
}