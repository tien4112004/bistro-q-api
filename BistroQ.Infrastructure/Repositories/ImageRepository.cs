using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;

namespace BistroQ.Infrastructure.Repositories;

public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    public ImageRepository(BistroQContext context) : base(context)
    {
    }

    public Task<Image?> GetByProductIdAsync(int productId)
    {
        throw new NotImplementedException();
    }
}