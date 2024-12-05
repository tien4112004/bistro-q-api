using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Dtos.Tables;

namespace BistroQ.Core.Dtos.Orders;

public class DetailOrderItemDto
{
    public string OrderItemId { get; set; } = null!;

    public string? OrderId { get; set; }

    public int? ProductId { get; set; }
    
    public int? Quantity { get; set; }
    
    public string Status { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }

    public decimal? PriceAtPurchase { get; set; }
    
    public TableDetailDto Table { get; set; } = null!;
    
    public OrderDto Order { get; set; } = null!;
    
    public ProductResponseDto? Product { get; set; }
}