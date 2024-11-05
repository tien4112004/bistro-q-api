using AutoMapper;
using BistroQ.Core.Dtos.Orders;
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

    public Task<OrderDto> CreateOrder(CreateOrderRequestDto request)
    {
        throw new NotImplementedException();
    }

    public Task<DetailOrderDto> GetOrder()
    {
        throw new NotImplementedException();
    }

    public Task<DetailOrderDto> AddProductToOrder(int productId)
    {
        throw new NotImplementedException();
    }

    public Task<DetailOrderDto> RemoveProductFromOrder(int productId)
    {
        throw new NotImplementedException();
    }

    public Task<DetailOrderDto> UpdateProductQuantity(int productId)
    {
        throw new NotImplementedException();
    }
}