using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Repositories;

/// <summary>
/// Repository interface specific to Zone entity operations,
/// extending the generic repository pattern
/// </summary>
public interface IZoneRepository : IGenericRepository<Zone>
{
	/// <summary>
	/// Materializes the final filtered/sorted queryable into an enumerable result
	/// </summary>
	/// <param name="queryable">The prepared queryable after all filtering and sorting has been applied</param>
	/// <returns>The final materialized collection of zones</returns>
	/// <remarks>
	/// This method is intended to be the final step in the query chain, executing 
	/// the prepared queryable and materializing the results
	/// </remarks>
	Task<IEnumerable<Zone>> GetZonesAsync(IQueryable<Zone> queryable);
	
	/// <summary>
	/// Executes a count operation on the final filtered queryable
	/// </summary>
	/// <param name="queryable">The prepared queryable after all filtering has been applied</param>
	/// <returns>The total count of zones matching the filter criteria</returns>
	Task<int> GetZonesCountAsync(IQueryable<Zone> queryable);
	
	Task<Zone?> GetZoneWithTableAsync(int id);
}