using System;
using System.Collections.Generic;

namespace bistro_q_api.Models;

public partial class Zone
{
    public int ZoneId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
}
