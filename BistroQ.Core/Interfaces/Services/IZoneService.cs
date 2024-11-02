using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Dtos.Zones;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;

namespace BistroQ.Core.Interfaces.Services;

/// <summary>
/// Service for managing zone and business logic handling
/// </summary>
public interface IZoneService
{
    /// <summary>
    /// Retrieves a zone by its identifier
    /// </summary>
    /// <param name="id">The zone identifier</param>
    /// <returns>The zone DTO if found</returns>
    /// <exception cref="ResourceNotFoundException">When zone with given id does not exist</exception>
    Task<ZoneDto> GetByIdAsync(int id);
    
    /// <summary>
    /// Retrieves a filtered, sorted, and paginated collection of zones
    /// </summary>
    /// <param name="queryParams">Parameters for filtering, sorting, and pagination</param>
    /// <returns>A tuple containing the collection of zones and total count</returns>
    Task<(IEnumerable<ZoneDto> Zones, int Count)> GetAllAsync(ZoneCollectionQueryParams queryParams);
    
    
    /// <summary>
    /// Creates a new zone
    /// </summary>
    /// <param name="zoneDto">The data for creating zone</param>
    /// <returns>The created zone DTO</returns>
    Task<ZoneDto> AddAsync(CreateZoneRequestDto zoneDto);
    
    /// <summary>
    /// Updates an existing zone
    /// </summary>
    /// <param name="zoneId">The identifier of the zone to update</param>
    /// <param name="zoneDto">The updated zone data</param>
    /// <returns>The updated zone DTO</returns>
    /// <exception cref="ResourceNotFoundException">When zone with given id doesn't exist</exception>

    Task<ZoneDto> UpdateAsync(int zoneId, UpdateZoneRequestDto zoneDto);

    /// <summary>
    /// Removes a zone
    /// </summary>
    /// <param name="id">The identifier of zone to remove</param>
    /// <exception cref="ResourceNotFoundException">When zone with given id doesn't exist</exception>
    Task DeleteAsync(int id);

    /// <summary>
    /// Adds tables to a zone
    /// </summary>
    /// <param name="zoneId">The identifier of the zone to add tables to</param>
    /// <param name="tableDtos">The collection of tables to add to the zone</param>
    /// <returns>A task representing the asynchronous operation</returns>
    Task<ZoneDetailDto> AddTablesToZoneAsync(int zoneId, List<CreateTableRequestDto> tableDtos);
}