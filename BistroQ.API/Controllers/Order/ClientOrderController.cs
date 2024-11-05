using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers.Order;

[ApiController]
[Route("api/[controller]")]
[Tags("Client Order")]
public class ClientOrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    
    public ClientOrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto request)
    {
        var order = await _orderService.CreateOrder(request);
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrder()
    {
        var order = await _orderService.GetOrder();
        return Ok(order);
    }
    
    [HttpPost("/Items/{productId:int}")]
    public async Task<IActionResult> AddProductToOrder([FromRoute] int productId)
    {
        var order = await _orderService.AddProductToOrder(productId);
        return Ok();
    }
    
    [HttpDelete("/Items/{productId:int}")]
    public async Task<IActionResult> RemoveProductFromOrder([FromRoute] int productId)
    {
        var order = await _orderService.RemoveProductFromOrder(productId);
        return Ok();
    }
    
    [HttpPatch("/Items/{productId:int}")]
    public async Task<IActionResult> UpdateProductQuantity([FromRoute] int productId)
    {
        var order = await _orderService.UpdateProductQuantity(productId);
        return Ok();
    }
}