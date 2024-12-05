using BistroQ.Core.Dtos.Orders;

namespace BistroQ.Core.Interfaces.Services;

public interface IOrderItemService
{
    public Task<(IEnumerable<DetailOrderItemDto> Items, int Count)> GetOrderItemsAsync(OrderItemCollectionQueryParams queryParams);
    
    public Task<IEnumerable<OrderItemDto>> UpdateOrderItemsStatusAsync(IEnumerable<OrderItemDto> orderItems, string status);
}