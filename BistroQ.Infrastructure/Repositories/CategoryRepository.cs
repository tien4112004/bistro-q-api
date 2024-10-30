using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository 
{
    private readonly BistroQContext _context;
    
    public CategoryRepository(BistroQContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Category?> GetDetailCategoryByIdAsync(int id)
    {
        var category = await _context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.CategoryId == id);
        
        return category;
    }
}