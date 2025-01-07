using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderService _orderService;
    
    public TestController(IUnitOfWork unitOfWork, IOrderService orderService)
    {
        _unitOfWork = unitOfWork;
        _orderService = orderService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await _unitOfWork.OrderRepository.AddAsync(new Core.Entities.Order
        {
            TotalAmount = 0,
            StartTime = DateTime.Now,
            EndTime = null,
            PeopleCount = 2,
            TableId = 1,
        });
        await _unitOfWork.SaveChangesAsync();
        return Ok(orders);
    }
    
    [HttpGet("/item")]
    public async Task<IActionResult> GetItem()
    {
        await _orderService.UpdateStatus(1, OrderStatus.Completed);
        
        return Ok();
    }
}