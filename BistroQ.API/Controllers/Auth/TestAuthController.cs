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
}