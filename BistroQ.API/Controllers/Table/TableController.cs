using System.Text.Json;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TableController : ControllerBase
{
    private readonly ITableService _tableService;
    
    public TableController(ITableService tableService)
    {
        _tableService = tableService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTables([FromQuery] TableCollectionQueryParams queryParams)
    {
        var (tables, count) = await _tableService.GetAllAsync(queryParams);
        return Ok(new PaginationResponseDto<IEnumerable<TableDetailDto>>(tables, count, queryParams.Page, queryParams.Size));
    }

    [HttpGet]
    [Route("{tableId:int}")]
    public async Task<IActionResult> GetTable([FromRoute] int tableId)
    {
        var table = await _tableService.GetByIdAsync(tableId);
        return Ok(new ResponseDto<TableDto>(table));
    }
}