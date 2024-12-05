using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Enums;

namespace BistroQ.Core.Interfaces.Services;

public interface IOrderItemService
{
    public Task<(IEnumerable<DetailOrderItemDto> Items, int Count)> GetOrderItemsAsync(OrderItemCollectionQueryParams queryParams);
    
    public Task<IEnumerable<OrderItemDto>> UpdateOrderItemsStatusAsync(IEnumerable<string> orderItemIds, OrderItemStatus status);
}