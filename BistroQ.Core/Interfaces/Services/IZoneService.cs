using BistroQ.Core.Dtos.Zones;

namespace BistroQ.Core.Interfaces.Services;

public interface IZoneService
{
    Task<ZoneDto> GetByIdAsync(int id);
    Task<(IEnumerable<ZoneDto> Zones, int Count)> GetAllAsync(ZoneCollectionQueryParams queryParams);
    Task<ZoneDto> AddAsync(CreateZoneRequestDto zoneDto);
    Task<ZoneDto> UpdateAsync(int zoneId, UpdateZoneRequestDto zoneDto);
    Task DeleteAsync(int id);
}