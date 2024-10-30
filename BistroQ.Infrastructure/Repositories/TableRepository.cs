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
		Console.WriteLine("B");
		Console.WriteLine(queryable.Expression);
		var tables = await queryable.ToListAsync();
		
		return tables;
	}

	public async Task<int> GetTablesCountAsync(IQueryable<Table> queryable)
	{
		var count = await queryable.CountAsync();
		
		return count;
	}
}
