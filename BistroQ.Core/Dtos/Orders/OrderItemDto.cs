namespace BistroQ.Core.Dtos.Orders;

public class OrderItemDto
{
    public string OrderDetailId { get; set; } = null!;

    public string? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }
    
    public string Status { get; set; } 

    public decimal? PriceAtPurchase { get; set; }
}