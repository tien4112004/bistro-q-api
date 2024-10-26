using System;
using System.Collections.Generic;

namespace BistroQ.Core.Entities;

public class Zone
{
    public int ZoneId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
}