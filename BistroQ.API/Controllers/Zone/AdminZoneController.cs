using System.Text.Json;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Zones;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers;

[ApiController]
[Route("api/Admin/[controller]")]
// [Authorize(Roles = BistroRoles.Admin)]
[Tags("Admin Zone")]
public class AdminZoneController : ControllerBase
{
    private readonly IZoneService _zoneService;
    
    public AdminZoneController(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetZones([FromQuery] ZoneCollectionQueryParams queryParams)
    {
        var (zones, count) = await _zoneService.GetAllAsync(queryParams);

        return Ok(new PaginationResponseDto<IEnumerable<ZoneDto>>(zones, count, queryParams.Page, queryParams.Size));
    }
    
    [HttpGet]
    [Route("{zoneId:int}")]
    public async Task<IActionResult> GetZone([FromRoute] int zoneId)
    {
        var zone = await _zoneService.GetByIdAsync(zoneId);
        if (zone == null)
        {
            throw new ResourceNotFoundException("Zone not found");
        }
        
        return Ok(new ResponseDto<ZoneDto>(zone));
    }
    
    [HttpPost]
    public async Task<IActionResult> AddZone([FromBody] CreateZoneRequestDto request)
    {
        Console.WriteLine(JsonSerializer.Serialize(request));
        var zone = await _zoneService.AddAsync(request);
        
        return Ok(new ResponseDto<ZoneDto>(zone));
    }
    
    [HttpPut]
    [Route("{zoneId:int}")]
    public async Task<IActionResult> UpdateZone([FromRoute] int zoneId, [FromBody] UpdateZoneRequestDto zoneDto)
    {
        var updatedZone = await _zoneService.UpdateAsync(zoneId, zoneDto);
        return Ok(new ResponseDto<ZoneDto>(updatedZone));
    }
    
    [HttpDelete]
    [Route("{zoneId:int}")]
    public async Task<IActionResult> DeleteZone([FromRoute] int zoneId)
    {
        await _zoneService.DeleteAsync(zoneId);
        return Ok(new ResponseDto<string>("Zone deleted successfully"));
    }
}