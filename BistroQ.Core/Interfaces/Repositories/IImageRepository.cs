using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Repositories;

public interface IImageRepository : IGenericRepository<Image>
{
    public Task<Image?> GetByProductIdAsync(int productId);
}