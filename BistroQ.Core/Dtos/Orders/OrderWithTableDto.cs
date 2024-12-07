using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Enums;

namespace BistroQ.Core.Dtos.Orders;

public class OrderWithTableDto
{
    public string OrderId { get; set; } = null!;

    public decimal? TotalAmount { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }
    
    public OrderStatus Status { get; set; }
    
    public int PeopleCount { get; set; }
    
    public int? TableId { get; set; }

    public TableDetailDto Table { get; set; } = null!;
}