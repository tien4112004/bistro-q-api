using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Repositories;

public interface IZoneRepository : IGenericRepository<Zone>
{
	Task<IEnumerable<Zone>> GetZonesAsync(IQueryable<Zone> queryable);
	Task<int> GetZonesCountAsync(IQueryable<Zone> queryable);
}