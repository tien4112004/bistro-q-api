using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ICloudStorageService _cloudStorageService;
    
    public TestController(ICloudStorageService cloudStorageService)
    {
        _cloudStorageService = cloudStorageService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _cloudStorageService.GeneratePresignedUrlAsync("3a8886a5-ff98-43e6-8d50-baef26bafb41.jpg", new TimeSpan(0, 5, 0));
        return Ok(result);
    }
}