using BistroQ.Core.Entities;
namespace BistroQ.Core.Dtos.Orders;

public class DetailOrderDto
{
    public string OrderId { get; set; } = null!;

    public decimal? TotalAmount { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? TableId { get; set; }
    public ICollection<OrderItemWithProductDto> OrderItems { get; set; } = new List<OrderItemWithProductDto>();
}