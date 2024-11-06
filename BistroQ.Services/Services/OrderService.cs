using AutoMapper;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Services;

namespace BistroQ.Services.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OrderDto> CreateOrder(int tableId)
    {
        var order = new Order
        {
            OrderId = Guid.NewGuid().ToString(),
            TableId = tableId,
            TotalAmount = 0,
            StartTime = DateTime.Now,
            EndTime = null,
        };
        
        var table = await _unitOfWork.TableRepository.GetByIdAsync(tableId);
        if (table == null)
        {
            throw new ResourceNotFoundException("Table not found");
        }

        var existingOrder = await _unitOfWork.OrderRepository.GetByTableIdAsync(tableId);
        if (existingOrder != null)
        {
            throw new ConflictException("Order already exists");
        }
        
        var createdOrder = await _unitOfWork.OrderRepository.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<OrderDto>(createdOrder);
    }

    public async Task<OrderInDetailDto> GetOrder(int tableId)
    {
        var order =await _unitOfWork.OrderRepository.GetByTableIdAsync(tableId);
        if (order == null)
        {
            throw new ResourceNotFoundException("Order not found");
        }

        return _mapper.Map<OrderInDetailDto>(order);
    }
    
    public async Task DeleteOrder(int tableId)
    {
        var order = await _unitOfWork.OrderRepository.GetByTableIdAsync(tableId);
        if (order == null)
        {
            throw new ResourceNotFoundException("Order not found");
        }

        await _unitOfWork.OrderRepository.DeleteAsync(order);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task<OrderInDetailDto> AddProductToOrder(int tableId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task<OrderInDetailDto> RemoveProductFromOrder(int tableId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task<OrderInDetailDto> UpdateProductQuantity(int tableId, int productId)
    {
        throw new NotImplementedException();
    }
}