using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Repositories;

/// <summary>
/// Repository interface specific to Table entity operations,
/// extending the generic repository pattern
/// </summary>
public interface ITableRepository : IGenericRepository<Table>
{
	/// <summary>
	/// Materializes the final filtered/sorted queryable into an enumerable result
	/// </summary>
	/// <param name="queryable">The prepared queryable after all filtering and sorting has been applied</param>
	/// <returns>The final materialized collection of tables</returns>
	/// <remarks>
	/// This method is intended to be the final step in the query chain, executing 
	/// the prepared queryable and materializing the results
	/// </remarks>
	Task<IEnumerable<Table>> GetTablesAsync(IQueryable<Table> queryable);

	/// <summary>
	/// Executes a count operation on the final filtered queryable
	/// </summary>
	/// <param name="queryable">The prepared queryable after all filtering and sorting has been applied</param>
	/// <returns>The count of tables matching the filter criteria</returns>
	Task<int> GetTablesCountAsync(IQueryable<Table> queryable);
}