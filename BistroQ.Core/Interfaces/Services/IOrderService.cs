using BistroQ.Core.Dtos.Orders;

namespace BistroQ.Core.Interfaces.Services;

public interface IOrderService 
{
    Task<OrderDto> CreateOrder(CreateOrderRequestDto request);
    
    Task<DetailOrderDto> GetOrder();
    
    Task<DetailOrderDto> AddProductToOrder(int productId);
    
    Task<DetailOrderDto> RemoveProductFromOrder(int productId);
    
    Task<DetailOrderDto> UpdateProductQuantity(int productId);
}