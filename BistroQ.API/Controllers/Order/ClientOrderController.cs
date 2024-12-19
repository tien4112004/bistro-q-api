using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers.Order;

[ApiController]
[Route("api/Client/Order")]
[Authorize(Roles = BistroRoles.Client)]
[Tags("Client Order")]
public class ClientOrderController : ControllerBase
{
	private readonly IOrderService _orderService;
	private readonly UserManager<AppUser> _userManager;

	public ClientOrderController(IOrderService orderService, UserManager<AppUser> userManager)
	{
		_orderService = orderService;
		_userManager = userManager;
	}

	[HttpPost]
	public async Task<IActionResult> CreateOrder(int peopleCount)
	{
		var tableId = await GetTableId();

		var order = await _orderService.CreateOrder(tableId, peopleCount);
		return Ok(new ResponseDto<OrderDto>(order));
	}

	[HttpGet]
	public async Task<IActionResult> GetOrder()
	{
		var tableId = await GetTableId();

		var order = await _orderService.GetOrder(tableId);
		return Ok(new ResponseDto<DetailOrderDto>(order));
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteOrder()
	{
		var tableId = await GetTableId();

		await _orderService.DeleteOrder(tableId);
		return Ok(new ResponseDto<string>("Order deleted"));
	}

	[HttpPatch("PeopleCount")]
	public async Task<IActionResult> UpdatePeopleCount([FromQuery] int peopleCount)
	{
		if (peopleCount <= 0)
		{
			throw new ArgumentOutOfRangeException(nameof(peopleCount));
		}

		var tableId = await GetTableId();

		var order = await _orderService.UpdatePeopleCount(tableId, peopleCount);
		return Ok(new ResponseDto<OrderDto>(order));
	}

	[HttpPost("Items")]
	public async Task<IActionResult> AddProductsToOrder([FromBody] IEnumerable<CreateOrderItemRequestDto> orderItems)
	{
		var tableId = await GetTableId();

		var addedItems = await _orderService.AddProductsToOrder(tableId, orderItems);

		return Ok(new ResponseDto<IEnumerable<OrderItemDto>>(addedItems));
	}

	[HttpDelete]
	[Route("Items")]
	public async Task<IActionResult> RemoveProductsFromOrder([FromBody] IEnumerable<RemoveOrderItemRequestDto> orderItems)
	{
		var tableId = await GetTableId();

		var cancelledItems = await _orderService.CancelOrderItems(tableId, orderItems);
		return Ok(new ResponseDto<IEnumerable<OrderItemDto>>(cancelledItems));
	}

	private async Task<int> GetTableId()
	{
		var user = await _userManager.GetUserAsync(User);
		if (user?.TableId == null)
		{
			throw new UnauthorizedException("User not found");
		}

		return user.TableId.Value;
	}
}