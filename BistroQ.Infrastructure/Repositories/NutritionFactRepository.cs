using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class NutritionFactRepository : GenericRepository<NutritionFact>, INutritionFactRepository
{
    private readonly BistroQContext _context;
    
    public NutritionFactRepository(BistroQContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<Dictionary<int, NutritionFact>> GetByIdsAsync(IEnumerable<int> productIds)
    {
        var nutritionFacts = await _context.NutritionFacts
            .Include(nf => nf.Product)
            .Where(nf => productIds.Contains(nf.ProductId))
            .ToListAsync();

        return nutritionFacts.ToDictionary(nf => nf.ProductId);
    }
}