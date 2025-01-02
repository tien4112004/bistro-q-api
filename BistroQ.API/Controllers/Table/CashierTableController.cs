using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers;

[ApiController]
[Route("api/Cashier/Zones/{zoneId:int}/Table")]
[Authorize(Roles = BistroRoles.Cashier)]
[Tags("Cashier Table")]
public class CashierTableController : ControllerBase
{
    private readonly ITableService _tableService;
    
    public CashierTableController(ITableService tableService)
    {
        _tableService = tableService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTables([FromQuery] bool isOccupied, [FromRoute] int zoneId)
    {
        if (isOccupied)
        {
            var tables = await _tableService.GetOccupiedTablesAsync(zoneId);
            return Ok(new ResponseDto<IEnumerable<TableDetailDto>>(tables));
        }
        else
        {
            var (tables, count) = await _tableService.GetAllAsync(new TableCollectionQueryParams { ZoneId = zoneId });
            return Ok(new ResponseDto<IEnumerable<TableDetailDto>>(tables));
        }
    }

    [HttpGet]
    [Route("{tableId:int}")]
    public async Task<IActionResult> GetTable([FromRoute] int tableId, [FromRoute] int zoneId)
    {
        var table = await _tableService.GetByIdAsync(tableId);
        return Ok(new ResponseDto<TableDetailDto>(table));
    }
}