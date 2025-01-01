using BistroQ.Core.Dtos.Tables;

namespace BistroQ.Core.Dtos.Zones;

public class ZoneCashierDto
{
    public int? ZoneId { get; set; }

    public string? Name { get; set; }
    
    public bool? HasCheckingOutTables { get; set; }
}