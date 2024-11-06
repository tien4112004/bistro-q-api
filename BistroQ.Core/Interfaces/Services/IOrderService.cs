using BistroQ.Core.Dtos.Orders;

namespace BistroQ.Core.Interfaces.Services;

public interface IOrderService 
{
    Task<OrderDto> CreateOrder(int tableId);
    
    Task<OrderInDetailDto> GetOrder(int tableId);
    
    Task DeleteOrder(int tableId);
    
    Task<OrderInDetailDto> AddProductToOrder(int tableId, int productId);
    
    Task<OrderInDetailDto> RemoveProductFromOrder(int tableId, int productId);
    
    Task<OrderInDetailDto> UpdateProductQuantity(int tableId, int productId);
}