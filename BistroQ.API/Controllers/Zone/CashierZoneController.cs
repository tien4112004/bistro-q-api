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
[Route("api/Cashier/Zones")]
[Tags("Cashier Table")]
[Authorize(Roles = BistroRoles.Cashier)]
public class CashierZoneController : ControllerBase
{
    private readonly IZoneService _zoneService;
    
    public CashierZoneController(IZoneService zoneService)
    {
        _zoneService = zoneService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetZones([FromQuery] ZoneCollectionQueryParams queryParams)
    {
        var (zones, count) = await _zoneService.GetAllByCashierAsync(queryParams);
        return Ok(new PaginationResponseDto<IEnumerable<ZoneCashierDto>>(zones, count, queryParams.Page, queryParams.Size));
    }
}