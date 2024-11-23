using BistroQ.Core.Dtos.Products;

namespace BistroQ.Core.Dtos.Orders;

public class OrderItemWithProductDto
{
    public string OrderDetailId { get; set; } = null!;

    public string? OrderId { get; set; }

    public int? ProductId { get; set; }
    
    public int? Quantity { get; set; }

    public decimal? PriceAtPurchase { get; set; }
    
    public ProductResponseDto? Product { get; set; }
}