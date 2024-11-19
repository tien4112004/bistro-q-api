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
    
}