using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Repositories;

public interface INutritionFactRepository : IGenericRepository<NutritionFact>
{
    Task<Dictionary<int, NutritionFact>> GetByIdsAsync(IEnumerable<int> productIds);
}