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
}