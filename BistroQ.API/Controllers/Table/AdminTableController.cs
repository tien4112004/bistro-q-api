﻿using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers;

[ApiController]
[Route("api/Admin/Table")]
[Authorize(Roles = BistroRoles.Admin)]
[Tags("Admin Table")]
public class AdminTableController : ControllerBase
{
	private readonly ITableService _tableService;

	public AdminTableController(ITableService tableService)
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
		return Ok(new ResponseDto<TableDetailDto>(table));
	}

	[HttpPost]
	public async Task<IActionResult> AddTable([FromBody] CreateTableRequestDto request)
	{
		if (request.SeatsCount <= 0)
		{
			throw new ArgumentException("Seats count must be greater than 0");
		}

		var table = await _tableService.AddAsync(request);
		return Ok(new ResponseDto<TableDto>(table));
	}

	[HttpPut]
	[Route("{tableId:int}")]
	public async Task<IActionResult> UpdateTable([FromRoute] int tableId, [FromBody] UpdateTableRequestDto tableDto)
	{
		if (tableDto.SeatsCount < 0)
		{
			throw new ArgumentException("Number of seats must be greater than 0");
		}

		var updatedTable = await _tableService.UpdateAsync(tableId, tableDto);
		return Ok(new ResponseDto<TableDto>(updatedTable));
	}

	[HttpDelete]
	[Route("{tableId:int}")]
	public async Task<IActionResult> DeleteTable([FromRoute] int tableId)
	{
		await _tableService.DeleteAsync(tableId);
		return Ok(new ResponseDto<string>("Table deleted successfully"));
	}
}