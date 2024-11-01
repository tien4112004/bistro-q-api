using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;
public class TableRepository : GenericRepository<Table>, ITableRepository
{
	private readonly BistroQContext _context;
	
	public TableRepository(BistroQContext context) : base(context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Table>> GetTablesAsync(IQueryable<Table> queryable)
	{	
		var tables = await queryable.ToListAsync();
		
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
		var tableNumbers = await _context.Tables
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
