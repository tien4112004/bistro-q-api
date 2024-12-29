using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Entities;
using BistroQ.Core.Specifications;

namespace BistroQ.Core.Interfaces.Repositories;

/// <summary>
/// Repository interface specific to Product entity operations,
/// extending the generic repository pattern
/// </summary>
public interface IProductRepository : IGenericRepository<Product>
{
    /// <summary>
    /// Materializes the final filtered/sorted queryable into an enumerable result
    /// </summary>
    /// <param name="queryable">The prepared queryable after all filtering and sorting has been applied</param>
    /// <returns>The final materialized collection of products</returns>
    /// <remarks>
    /// This method is intended to be the final step in the query chain, executing 
    /// the prepared queryable and materializing the results
    /// </remarks>
    Task<IEnumerable<Product>> GetProductsAsync(IQueryable<Product> queryable);

    /// <summary>
    /// Executes a count operation on the final filtered queryable
    /// </summary>
    /// <param name="queryable">The prepared queryable after all filtering has been applied</param>
    /// <returns>The total count of products matching the filter criteria</returns>
    Task<int> GetProductsCountAsync(IQueryable<Product> queryable);
    
    Task<Product?> GetProductByIdAsync(int productId);
    
    Task<IEnumerable<Product>> GetRecommendedProductsAsync(string orderId);
}