using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    public ImageRepository(BistroQContext context) : base(context)
    {
    }

    public async Task<Image?> GetByProductIdAsync(int productId)
    {
        var image = await Context.Products
            .Include(p => p.Image)
            .FirstOrDefaultAsync(i => i.ProductId == productId)
            .ContinueWith(t => t.Result?.Image);

        return image;
    }
}