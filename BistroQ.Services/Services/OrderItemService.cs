using AutoMapper;
using BistroQ.Core.Common.Builder;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;
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

    public async Task<IEnumerable<OrderItemDto>> UpdateOrderItemsStatusAsync(IEnumerable<string> orderItems, OrderItemStatus status)
    {
        var enumerable = orderItems as string[] ?? orderItems.ToArray();
        
        var updatedOrderItems = new List<OrderItem>();

        await _unitOfWork.BeginTransactionAsync();
        try
        {
            for (var i = 0; i < enumerable.Count(); i++)
            {
                var orderItem = await _unitOfWork.OrderItemRepository.GetByIdAsync(enumerable[i]);
                if (orderItem == null)
                {
                    throw new ResourceNotFoundException($"Order item with id {enumerable[i]} not found.");
                }

                if (orderItem.Status == status)
                {
                    // Skip if the status is the same
                }
                // Only allow the following status transitions
                else if (orderItem.Status == OrderItemStatus.Pending && status == OrderItemStatus.InProgress)
                {
                    orderItem.Status = status;
                    orderItem.UpdatedAt = DateTime.Now;
                }
                else if (orderItem.Status == OrderItemStatus.InProgress && status == OrderItemStatus.Pending)
                {
                    orderItem.Status = status;
                    orderItem.UpdatedAt = DateTime.Now;
                }
                else if (orderItem.Status == OrderItemStatus.Pending && status == OrderItemStatus.Cancelled)
                {
                    orderItem.Status = status;
                    orderItem.UpdatedAt = DateTime.Now;
                }
                else if (orderItem.Status == OrderItemStatus.InProgress && status == OrderItemStatus.Completed)
                {
                    orderItem.Status = status;
                    orderItem.UpdatedAt = DateTime.Now;
                }
                else
                {
                    throw new ConflictException($"Invalid status transition (from: {orderItem.Status}, to: {status}).");
                }

                updatedOrderItems.Add(orderItem);
            }
            
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
        }
        catch (Exception e)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }

        return _mapper.Map<IEnumerable<OrderItemDto>>(updatedOrderItems);
    }
}