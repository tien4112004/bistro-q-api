using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
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
    
    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="productId">The unique identifier of the product to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the product if found, otherwise null.
    /// </returns>
    /// <exception cref="ResourceNotFoundException">
    /// Thrown when the product specified by the productId is not found.
    /// </exception>
    Task<Product?> GetProductByIdAsync(int productId);

    /// <summary>
    /// Retrieves a list of recommended products based on the specified order ID and size.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order to base recommendations on.</param>
    /// <param name="size">The number of recommended products to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an enumerable collection of recommended product DTOs.
    /// </returns>
    /// <exception cref="ResourceNotFoundException">
    /// Thrown when the order specified by the order ID is not found.
    /// </exception>
    /// <remarks>
    /// This method uses the order ID to generate product recommendations, which can be used to suggest additional products to the user.
    /// </remarks>
    Task<IEnumerable<Product>> GetRecommendedProductsAsync(string orderId, int size);
}