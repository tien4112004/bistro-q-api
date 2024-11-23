﻿using System;
using System.Collections.Generic;
using BistroQ.Core.Enums;

namespace BistroQ.Core.Entities;

public class Order
{
    public string OrderId { get; set; } = null!;

    public decimal? TotalAmount { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }
    
    public string Status { get; set; } = OrderStatus.InProgress;

    public int PeopleCount { get; set; }
    
    public int? TableId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Table? Table { get; set; }
}