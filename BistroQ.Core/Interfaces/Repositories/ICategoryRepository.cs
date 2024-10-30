using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    public Task<Category?> GetDetailCategoryByIdAsync(int id);
}