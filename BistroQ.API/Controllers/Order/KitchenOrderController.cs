using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers.Order;

[ApiController]
[Route("api/Kitchen/Order")]
[Authorize(Roles = BistroRoles.Kitchen)]
[Tags("Kitchen Order")]
public class KitchenOrderController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;
    private readonly UserManager<AppUser> _userManager;

    public KitchenOrderController(IOrderItemService orderItemService, UserManager<AppUser> userManager)
    {
        _orderItemService = orderItemService;
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrderItems([FromQuery] OrderItemCollectionQueryParams queryParams)
    {
        var (items, count) = await _orderItemService.GetOrderItemsAsync(queryParams);
        return Ok(new PaginationResponseDto<IEnumerable<DetailOrderItemDto>>(
            items, count, queryParams.Page, queryParams.Size));
    }
    
    [HttpPatch("Status")]
    public async Task<IActionResult> UpdateOrderItemsStatus([FromBody] UpdateOrderItemsStatusRequestDto updateOrderItemsStatusDto)
    {
        var orderItems = 
            await _orderItemService.UpdateOrderItemsStatusAsync(updateOrderItemsStatusDto.OrderItemIds, updateOrderItemsStatusDto.Status);
        return Ok(new ResponseDto<IEnumerable<OrderItemDto>>(orderItems));
    }
}