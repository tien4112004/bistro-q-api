using BistroQ.Core.Dtos.Tables;

namespace BistroQ.Core.Dtos.Orders;

public class OrderWithTableDto
{
    public string OrderId { get; set; } = null!;

    public decimal? TotalAmount { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? TableId { get; set; }

    public TableDetailDto Table { get; set; } = null!;
}