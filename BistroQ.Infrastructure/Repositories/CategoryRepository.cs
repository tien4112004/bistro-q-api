using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository 
{
    
    public CategoryRepository(BistroQContext context) : base(context)
    {
    }

    public async Task<Category?> GetDetailCategoryByIdAsync(int id)
    {
        var category = await DbSet
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.CategoryId == id);
        
        return category;
    }

    public Task AddProductsToCategoryAsync(Category category, List<Product> products)
    {
        foreach (var product in products)
        {
            category.Products.Add(product);
        }
        return Task.CompletedTask;
    }
}