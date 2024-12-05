using AutoMapper;
using BistroQ.Core.Common.Builder;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Services;

namespace BistroQ.Services.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public OrderItemService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<(IEnumerable<DetailOrderItemDto> Items, int Count)> GetOrderItemsAsync(OrderItemCollectionQueryParams queryParams)
    {
        var builder =
            new OrderItemQueryableBuilder(_unitOfWork.OrderItemRepository.GetQueryable())
                .WithStatus(queryParams.Status)
                .WithCreatedDateRange(queryParams.CreatedFrom, queryParams.CreatedTo)
                .WithUpdatedDateRange(queryParams.UpdatedFrom, queryParams.UpdatedTo);
        
        var count = await _unitOfWork.OrderItemRepository.GetOrderItemsCountAsync(builder.Build());
        
        builder
            .IncludeAll()
            .ApplySorting(queryParams.OrderBy, queryParams.OrderDirection)
            .ApplyPaging(queryParams.Page, queryParams.Size);
        
        var orderItems = await _unitOfWork.OrderItemRepository.GetOrderItemsAsync(builder.Build());
        
        return (_mapper.Map<IEnumerable<DetailOrderItemDto>>(orderItems), count);
    }

    public Task<IEnumerable<OrderItemDto>> UpdateOrderItemsStatusAsync(IEnumerable<OrderItemDto> orderItems, string status)
    {
        throw new NotImplementedException();
    }
}