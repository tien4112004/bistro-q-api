using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    
    public TestController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
        var orderItems = await _unitOfWork.OrderItemRepository.AddAsync(new Core.Entities.OrderItem
        {
            OrderId = "1",
            ProductId = 1,
            Quantity = 2,
            PriceAtPurchase = 0,
        });
        await _unitOfWork.SaveChangesAsync();

        return Ok(orderItems);
    }
    
}