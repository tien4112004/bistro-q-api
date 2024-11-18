using BistroQ.Core.Entities;
namespace BistroQ.Core.Dtos.Orders;

public class OrderInDetailDto
{
    public string OrderId { get; set; } = null!;

    public decimal? TotalAmount { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? TableId { get; set; }
    public ICollection<OrderDetailWithProductDto> OrderDetails { get; set; } = new List<OrderDetailWithProductDto>();
}