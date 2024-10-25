using System;
using System.Collections.Generic;

namespace BistroQ.Core.Entities;

public partial class Table
{
    public int TableId { get; set; }

    public int? ZoneId { get; set; }

    public int? Number { get; set; }

    public int? SeatsCount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Zone? Zone { get; set; }
}