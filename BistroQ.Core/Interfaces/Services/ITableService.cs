using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Dtos.Zones;
using BistroQ.Core.Exceptions;

namespace BistroQ.Core.Interfaces.Services;

/// <summary>
/// Service for managing table and business logic handling
/// </summary>
public interface ITableService
{
    /// <summary>
    /// Retrieves a table by its identifier
    /// </summary>
    /// <param name="id">The table identifier</param>
    /// <returns>The table DTO if found</returns>
    /// <exception cref="ResourceNotFoundException">When table with given id does not exist</exception>
    Task<TableDetailDto> GetByIdAsync(int id);
    
    /// <summary>
    /// Retrieves a filtered, sorted, and paginated collection of tables
    /// </summary>
    /// <param name="queryParams">Parameters for filtering, sorting, and pagination</param>
    /// <returns>A tuple containing the collection of tables and total count</returns>
    Task<(IEnumerable<TableDetailDto> Tables, int Count)> GetAllAsync(TableCollectionQueryParams queryParams);
    
    /// <summary>
    /// Retrieves all currently occupied tables in a specific zone.
    /// </summary>
    /// <param name="zoneId">The ID of the zone to check for occupied tables.</param>
    /// <returns>A collection of detailed information about occupied tables in the specified zone.</returns>
    /// <exception cref="ResourceNotFoundException">Thrown when the specified zone cannot be found.</exception>
    Task<IEnumerable<TableDetailDto>> GetOccupiedTablesAsync(int zoneId);
    
    /// <summary>
    /// Creates a new table
    /// </summary>
    /// <param name="tableDto">The data for creating table</param>
    /// <returns>The created table DTO</returns>
    Task<TableDto> AddAsync(CreateTableRequestDto tableDto);
    
    /// <summary>
    /// Updates an existing table
    /// </summary>
    /// <param name="tableId">The identifier of the table to update</param>
    /// <param name="tableDto">The updated table data</param>
    /// <returns>The updated table DTO</returns>
    /// <exception cref="ResourceNotFoundException">When table with given id doesn't exist</exception>
    Task<TableDto> UpdateAsync(int tableId, UpdateTableRequestDto tableDto);

    /// <summary>
    /// Removes a table
    /// </summary>
    /// <param name="id">The identifier of the table to delete</param>
    /// <exception cref="ResourceNotFoundException">When table with given id doesn't exist</exception>
    Task DeleteAsync(int id);
}