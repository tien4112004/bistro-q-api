using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers.Order;

[ApiController]
[Route("api/Cashier/Order")]
[Authorize(Roles = BistroRoles.Cashier)]
public class CashierOrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    
    public CashierOrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderService.GetAllCurrentOrders();
        return Ok(new ResponseDto<IEnumerable<OrderWithTableDto>>(orders));
    }
    
    [HttpGet]
    [Route("{tableId:int}")]
    public async Task<IActionResult> GetOrder([FromRoute] int tableId)
    {
        var order = await _orderService.GetOrder(tableId);
        return Ok(new ResponseDto<DetailOrderDto>(order));
    }

    [HttpPatch]
    [Route("Status")]
    public async Task<IActionResult> UpdateStatus([FromBody] UpdateOrderStatusRequestDto updateOrderStatusDto)
    {
        var order = await _orderService.UpdateStatus(updateOrderStatusDto.OrderId, updateOrderStatusDto.Status);
        return Ok(new ResponseDto<OrderDto>(order));
    }
}