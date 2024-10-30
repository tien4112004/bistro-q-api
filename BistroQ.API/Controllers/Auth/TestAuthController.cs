using BistroQ.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers.Auth;

[Route("api/[controller]")]
public class TestAuthController : ControllerBase
{
    [HttpGet]
    [Authorize]
    [Route("test-token")]
    public IActionResult Test()
    {
        return Ok("Test");
    }
    
    [HttpGet]
    [Authorize(Roles = BistroRoles.Admin)]
    [Route("test-admin")]
    public IActionResult TestAdmin()
    {
        return Ok("Test Admin");
    }
    
    [HttpGet]
    [Authorize(Roles = BistroRoles.Kitchen)]
    [Route("test-kitchen")]
    public IActionResult TestKitchen()
    {
        return Ok("Test Kitchen");
    }
    
    [HttpGet]
    [Authorize(Roles = BistroRoles.Cashier)]
    [Route("test-cashier")]
    public IActionResult TestCashier()
    {
        return Ok("Test Cashier");
    }
}