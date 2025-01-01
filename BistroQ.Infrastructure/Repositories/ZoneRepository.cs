using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;
public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
{
	
	public ZoneRepository(BistroQContext context) : base(context)
	{
	}

	public async Task<IEnumerable<Zone>> GetZonesAsync(IQueryable<Zone> queryable)
	{	
		var zones = await queryable.ToListAsync();
		
		return zones;
	}

	public async Task<int> GetZonesCountAsync(IQueryable<Zone> queryable)
	{
		var count = await queryable.CountAsync();
		
		return count;
	}

	public Task<Zone?> GetZoneWithTableAsync(int id)
	{
		return Context.Zones
			.Include(z => z.Tables)
			.FirstOrDefaultAsync(z => z.ZoneId == id);
	}
}