using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Entities;
using BistroQ.Core.Specifications;

namespace BistroQ.Core.Interfaces.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsAsync(IQueryable<Product> queryable);

    Task<int> GetProductsCountAsync(IQueryable<Product> queryable);
}