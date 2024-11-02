using BistroQ.Core.Dtos.Tables;

namespace BistroQ.Core.Dtos.Zones;

public class ZoneDetailDto
{
    public int? ZoneId { get; set; }

    public string? Name { get; set; }
    public ICollection<TableDto> Tables { get; set; }
}