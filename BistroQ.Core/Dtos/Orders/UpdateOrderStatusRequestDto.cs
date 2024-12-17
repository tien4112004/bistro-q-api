using BistroQ.Core.Enums;

namespace BistroQ.Core.Dtos.Orders;

public class UpdateOrderStatusRequestDto
{
    public int OrderId { get; set; }
    
    public OrderStatus Status { get; set; }
}