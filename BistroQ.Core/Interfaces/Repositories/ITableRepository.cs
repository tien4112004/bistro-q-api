using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Repositories;

public interface ITableRepository : IGenericRepository<Table>
{
	Task<IEnumerable<Table>> GetTablesAsync(IQueryable<Table> queryable);
	Task<int> GetTablesCountAsync(IQueryable<Table> queryable);
}