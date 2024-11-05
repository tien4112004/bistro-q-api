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
[Route("api/[controller]")]
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
    public async Task<IActionResult> CreateOrder()
    {
        var tableId = await GetTableId();
        
        var order = await _orderService.CreateOrder(tableId);
        return Ok(new ResponseDto<OrderDto>(order));
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrder()
    {
        var tableId = await GetTableId();
        
        var order = await _orderService.GetOrder(tableId);
        return Ok(new ResponseDto<OrderInDetailDto>(order));
    }
        
    [HttpPost("Items/{productId:int}")]
    public async Task<IActionResult> AddProductToOrder([FromRoute] int productId)
    {
        var tableId = await GetTableId();
        
        var order = await _orderService.AddProductToOrder(tableId, productId);
        return Ok();
    }
    
    [HttpDelete]
    [Route("Items/{productId:int}")]
    public async Task<IActionResult> RemoveProductFromOrder([FromRoute] int productId)
    {
        var tableId = await GetTableId();
        
        var order = await _orderService.RemoveProductFromOrder(tableId, productId);
        return Ok();
    }
    
    [HttpPatch("Items/{productId:int}")]
    public async Task<IActionResult> UpdateProductQuantity([FromRoute] int productId)
    {
        var tableId = await GetTableId();
        
        var order = await _orderService.UpdateProductQuantity(tableId, productId);
        return Ok();
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