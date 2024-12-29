using BistroQ.Core.Dtos.Image;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Exceptions;
using Microsoft.AspNetCore.Http;

namespace BistroQ.Core.Interfaces.Services;

/// <summary>
/// Service for managing product operations with DTO transformations
/// and business logic handling
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Retrieves a product by its identifier
    /// </summary>
    /// <param name="id">The product identifier</param>
    /// <returns>The product DTO if found</returns>
    /// <exception cref="ResourceNotFoundException">When product with given id doesn't exist</exception>
    Task<ProductResponseDto> GetByIdAsync(int id);
    
    /// <summary>
    /// Retrieves a filtered, sorted, and paginated collection of products
    /// </summary>
    /// <param name="queryParams">Parameters for filtering, sorting, and pagination</param>
    /// <returns>A tuple containing the collection of products and total count</returns>
    Task<(IEnumerable<ProductResponseDto> Products, int Count)> GetAllAsync(
        ProductCollectionQueryParams queryParams);
    
    /// <summary>
    /// Creates a new product
    /// </summary>
    /// <param name="productDto">The product creation data</param>
    /// <param name="image">The image file of the product</param>
    /// <returns>The newly created product DTO</returns>
    Task<ProductResponseDto> AddAsync(CreateProductRequestDto productDto, ImageRequestDto? image);
    
    /// <summary>
    /// Updates an existing product
    /// </summary>
    /// <param name="id">The identifier of the product to update</param>
    /// <param name="productDto">The updated product data</param>
    /// <returns>The updated product DTO</returns>
    /// <exception cref="ResourceNotFoundException">When product with given id doesn't exist</exception>
    Task<ProductDto> UpdateAsync(int id, UpdateProductRequestDto productDto);
    
    Task<ProductResponseDto> UpdateImageAsync(int id, ImageRequestDto image);
    
    /// <summary>
    /// Removes a product
    /// </summary>
    /// <param name="id">The identifier of the product to delete</param>
    /// <exception cref="ResourceNotFoundException">When product with given id doesn't exist</exception>
    Task DeleteAsync(int id);
    
    
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
    Task<IEnumerable<ProductResponseDto>> GetRecommendedProductsAsync(string orderId, int size);
}