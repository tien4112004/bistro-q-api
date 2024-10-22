using System;
using System.Collections.Generic;

namespace bistro_q_api.Models;

public partial class Table
{
    public int TableId { get; set; }

    public int? ZoneId { get; set; }

    public int? Number { get; set; }

    public int? SeatsCount { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Zone? Zone { get; set; }
}
