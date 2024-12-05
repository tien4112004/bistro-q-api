using BistroQ.Core.Enums;

namespace BistroQ.Core.Dtos.Orders;

public class OrderItemDto
{
    public string OrderItemId { get; set; } = null!;

    public string? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }
    
    public OrderItemStatus Status { get; set; } 
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }

    public decimal? PriceAtPurchase { get; set; }
}