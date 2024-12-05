using AutoMapper;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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

	public async Task<OrderDto> CreateOrder(int tableId, int peopleCount)
	{
		var order = new Order
		{
			OrderId = Guid.NewGuid().ToString(),
			TableId = tableId,
			TotalAmount = 0,
			StartTime = DateTime.Now,
			EndTime = null,
			PeopleCount = peopleCount,
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

	public async Task<DetailOrderDto> GetOrder(int tableId)
	{
		var order = await _unitOfWork.OrderRepository.GetByTableIdAsync(tableId);
		if (order == null)
		{
			throw new ResourceNotFoundException("Order not found");
		}

		order.OrderItems = _mapper.Map<List<OrderItem>>(order.OrderItems);

		return _mapper.Map<DetailOrderDto>(order);
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

	public async Task<IEnumerable<OrderWithTableDto>> GetAllCurrentOrders()
	{
		var orders = await _unitOfWork.OrderRepository.GetAllCurrentOrdersAsync();
		return _mapper.Map<IEnumerable<OrderWithTableDto>>(orders);
	}

	public async Task<IEnumerable<OrderItemDto>> AddProductsToOrder(
		int tableId,
		IEnumerable<CreateOrderItemRequestDto> orderItems)
	{
		var order = await _unitOfWork.OrderRepository.GetByTableIdAsync(tableId);
		if (order == null)
		{
			throw new ResourceNotFoundException("Order not found");
		}
		var updatedOrder = order;

		List<OrderItem> addedItems = new List<OrderItem>();

		foreach (var item in orderItems)
		{
			var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
			if (product == null)
			{
				throw new ResourceNotFoundException("Product not found");
			}

			var orderItem = new OrderItem
			{
				OrderId = order.OrderId,
				ProductId = item.ProductId,
				Quantity = item.Quantity,
				PriceAtPurchase = product.Price, // TODO: OR DiscountPrice
			};

			var addedItem = await _unitOfWork.OrderItemRepository.AddAsync(orderItem);
			addedItems.Add(addedItem);
			order.TotalAmount += (item.PriceAtPurchase * item.Quantity);
		}

		await _unitOfWork.OrderRepository.UpdateAsync(order, updatedOrder);
		await _unitOfWork.SaveChangesAsync();
		var addedItemsDto = _mapper.Map<IEnumerable<OrderItemDto>>(addedItems);

		return addedItemsDto;
	}

	public async Task<IEnumerable<OrderItemDto>> CancelOrderItems(int tableId, [FromBody] IEnumerable<RemoveOrderItemRequestDto> orderItems)
	{
		var order = await _unitOfWork.OrderRepository.GetByTableIdAsync(tableId);
		if (order == null)
		{
			throw new ResourceNotFoundException("Order not found");
		}

		List<OrderItem> removedItems = new List<OrderItem>();
		foreach (var item in orderItems)
		{
			var orderItem = order.OrderItems.FirstOrDefault(oi => oi.OrderItemId == item.OrderItemId);
			if (orderItem == null)
			{
				throw new ResourceNotFoundException("OrderItem not found");
			}

			await _unitOfWork.OrderItemRepository.DeleteAsync(orderItem);
			removedItems.Add(orderItem);
		}
		await _unitOfWork.SaveChangesAsync();

		return _mapper.Map<IEnumerable<OrderItemDto>>(removedItems);
	}

	public async Task<OrderDto> UpdatePeopleCount(int tableId, int peopleCount)
	{
		var order = await _unitOfWork.OrderRepository.GetByTableIdAsync(tableId);
		if (order == null)
		{
			throw new ResourceNotFoundException("Order not found");
		}

		var updatedOrder = order;
		updatedOrder.PeopleCount = peopleCount;
		await _unitOfWork.OrderRepository.UpdateAsync(order, updatedOrder);
		await _unitOfWork.SaveChangesAsync();

		return _mapper.Map<OrderDto>(updatedOrder);
	}
}