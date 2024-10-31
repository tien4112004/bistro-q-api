using BistroQ.Core.Dtos.Category;

namespace BistroQ.Core.Interfaces.Services;

public interface ICategoryService
{
    public Task<(IEnumerable<CategoryDto> Categories, int Count)> GetCategoriesAsync();
    
    public Task<CategoryDetailDto> GetCategoryByIdAsync(int id);
    
    public Task<CategoryDto> CreateCategoryAsync(CreateCategoryRequestDto categoryDto);
    
    public Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryRequestDto categoryDto);
    
    public Task DeleteCategoryAsync(int id);
    
    public Task<CategoryDetailDto> AddProductsToCategoryAsync(int categoryId, List<int> productIds);
}