using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BistroQ.Infrastructure.Identity;

namespace BistroQ.Core.Entities;

public partial class Table
{
    public int TableId { get; set; }

    public int? ZoneId { get; set; }
    
    public int? Number { get; set; }

    [Range(1, int.MaxValue)]
    public int? SeatsCount { get; set; }

    public virtual AppUser? User { get; set; }
    public virtual Order? Order { get; set; }

    public Zone? Zone { get; set; }
}