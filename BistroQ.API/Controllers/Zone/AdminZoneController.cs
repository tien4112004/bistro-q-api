using System.Text.Json;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Dtos.Zones;
using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers;

[ApiController]
[Route("api/Admin/Zone")]
[Authorize(Roles = BistroRoles.Admin)]
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
        return Ok(new ResponseDto<ZoneDto>(zone));
    }

    [HttpPost]
    public async Task<IActionResult> AddZone([FromBody] CreateZoneRequestDto request)
    {
        var zone = await _zoneService.AddAsync(request);
        return Ok(new ResponseDto<ZoneDto>(zone));
    }
    
    [HttpPost("{zoneId:int}")]
    public async Task<IActionResult> AddTables([FromRoute] int zoneId ,[FromBody] List<CreateTableRequestDto> requests)
    {
        var zone = await _zoneService.AddTablesToZoneAsync(zoneId, requests);
        return Ok(new ResponseDto<ZoneDetailDto>(zone));
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