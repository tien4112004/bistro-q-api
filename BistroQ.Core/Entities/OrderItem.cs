using System;
using System.Collections.Generic;
using BistroQ.Core.Enums;

namespace BistroQ.Core.Entities;

public class OrderItem
{
    public string OrderItemId { get; set; } = null!;

    public string? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }
    
    public string Status { get; set; } = OrderItemStatus.InProgress;

    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public decimal? PriceAtPurchase { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}