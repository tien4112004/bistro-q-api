using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;
public class TableRepository : GenericRepository<Table>, ITableRepository
{
	public TableRepository(BistroQContext context) : base(context)
	{
	}
	
	public async Task<Table?> GetByIdAsync(int id)
	{
		var table = await DbSet
			.Include(t => t.Zone)
			.FirstOrDefaultAsync(t => t.TableId == id);
		
		return table;
	}

	public async Task<IEnumerable<Table>> GetTablesAsync(IQueryable<Table> queryable)
	{	
		var tables = await queryable.Include(x => x.Zone)
			.ToListAsync();
		
		return tables;
	}

	public async Task<int> GetTablesCountAsync(IQueryable<Table> queryable)
	{
		var count = await queryable.CountAsync();
		
		return count;
	}
	
	// TODO: Change the implementation of this method
	public async Task<int> GetNextTableNumberAsync(int zoneId)
	{
		var tableNumbers = await DbSet
			.Where(t => t.ZoneId == zoneId)
			.OrderBy(t => t.Number)
			.Select(t => t.Number)
			.ToListAsync();
		
		if (tableNumbers.Count == tableNumbers.Max())
		{
			return tableNumbers.Max().Value + 1;
		}
		
		for (int i = 1; i <= tableNumbers.Count; i++)
		{
			if (tableNumbers[i - 1] != i)
			{
				return i;
			}
		}
		
		return tableNumbers.Count + 1;
	}
}