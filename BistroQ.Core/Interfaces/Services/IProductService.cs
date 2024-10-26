using BistroQ.Core.Entities;
using BistroQ.Core.Dtos.Products;

namespace BistroQ.Core.Interfaces.Services;

public interface IProductService
{
    public Task<ProductDto> GetByIdAsync(int id);
    
    public Task<(IEnumerable<ProductDto> Products, int Count)> GetAllAsync(ProductCollectionQueryParams queryParams);
    
    public Task<ProductDto> AddAsync(CreateProductRequestDto productDto);
    
    public Task<ProductDto> UpdateAsync(ProductDto productDto);
    
    public Task DeleteAsync(int id);
}