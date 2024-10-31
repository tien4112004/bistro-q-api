using AutoMapper;
using BistroQ.Core.Common.Builder;
using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Services.Services;

public class TableService : ITableService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public TableService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<TableDto> GetByIdAsync(int id)
    {
        var table = await _unitOfWork.TableRepository.GetByIdAsync(id);
        if (table == null)
        {
            throw new ResourceNotFoundException("Table not found");
        }
        
        return _mapper.Map<TableDto>(table);
    }

    public async Task<(IEnumerable<TableDto> Tables, int Count)> GetAllAsync(TableCollectionQueryParams queryParams)
    {
        var builder =
            new TableQueryableBuilder(await _unitOfWork.TableRepository.GetQueryable())
                .WithZoneName(queryParams.ZoneName)
                .WithZoneId(queryParams.ZoneId)
                .WithSeatsCount(queryParams.SeatsCount);
        
        var count = await _unitOfWork.TableRepository.GetTablesCountAsync(builder.Build());
        builder
            .ApplySorting(queryParams.OrderBy, queryParams.OrderDirection)
            .ApplyPaging(queryParams.Page, queryParams.Size);
        
        var tables = await _unitOfWork.TableRepository.GetTablesAsync(builder.Build());
        await _unitOfWork.SaveChangesAsync();
        return (_mapper.Map<IEnumerable<TableDto>>(tables), count);
    }

    public async Task<TableDto> AddAsync(CreateTableRequestDto tableDto)
    {
        var table = _mapper.Map<Table>(tableDto);
        
        var tableNumber = await _unitOfWork.TableRepository.GetNextTableNumberAsync(table.ZoneId.Value);

        table.Number = tableNumber;
        var createdTable = await _unitOfWork.TableRepository.AddAsync(table);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<TableDto>(createdTable);
    }

    public async Task<TableDto> UpdateAsync(int tableId, UpdateTableRequestDto tableDto)
    {
        var existingTable = await _unitOfWork.TableRepository.GetByIdAsync(tableId);
        if (existingTable == null)
        {
            throw new ResourceNotFoundException("Table not found");
        }
        
        var newTable = _mapper.Map<Table>(tableDto);
        newTable.TableId = tableId;
        newTable.Number = existingTable.Number;
        newTable.ZoneId = newTable.ZoneId ?? existingTable.ZoneId;
        newTable.SeatsCount = newTable.SeatsCount ?? existingTable.SeatsCount; 
        
        await _unitOfWork.TableRepository.UpdateAsync(existingTable, newTable);
        await _unitOfWork.SaveChangesAsync();
        
        var updatedTable = await _unitOfWork.TableRepository.GetByIdAsync(tableId);
        
        return _mapper.Map<TableDto>(updatedTable);
    }

    public async Task DeleteAsync(int id)
    {
        var existingTable = await _unitOfWork.TableRepository.GetByIdAsync(id);
        if (existingTable == null)
        {
            throw new ResourceNotFoundException("Table not found");
        }
        
        await _unitOfWork.TableRepository.DeleteAsync(existingTable);
        await _unitOfWork.SaveChangesAsync();
    }
}