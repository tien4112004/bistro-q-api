using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Dtos.Zones;

namespace BistroQ.Core.Interfaces.Services;

public interface ITableService
{
    Task<TableDto> GetByIdAsync(int id);
    Task<(IEnumerable<TableDto> Tables, int Count)> GetAllAsync(TableCollectionQueryParams queryParams);
    Task<TableDto> AddAsync(CreateTableRequestDto zoneDto);
    Task<TableDto> UpdateAsync(int zoneId, UpdateTableRequestDto zoneDto);
    Task DeleteAsync(int id);
}