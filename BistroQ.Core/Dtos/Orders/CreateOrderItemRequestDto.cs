namespace BistroQ.Core.Dtos.Orders;

public class CreateOrderItemRequestDto
{
	public int ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal PriceAtPurchase { get; set; }
}