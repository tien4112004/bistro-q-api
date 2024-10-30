using AutoMapper;
using BistroQ.Core.Dtos.Category;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Services;

namespace BistroQ.Services.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<CategoryDto> Categories, int Count)> GetCategoriesAsync()
    {
        var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
        var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        return (categoryDtos, categories.Count());
    }

    public async Task<CategoryDetailDto> GetCategoryByIdAsync(int id)
    {
        var category = await _unitOfWork.CategoryRepository.GetDetailCategoryByIdAsync(id);
        if (category == null)
        {
            throw new ResourceNotFoundException("Category not found");
        }
        
        var res = _mapper.Map<CategoryDetailDto>(category);
        return res;
    }

    public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryRequestDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _unitOfWork.CategoryRepository.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();
        
        var res = _mapper.Map<CategoryDto>(category);
        return res;
    }

    public async Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryRequestDto categoryDto)
    {
        var existingCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
        if (existingCategory == null)
        {
            throw new ResourceNotFoundException("Category not found");
        }
        
        var category = _mapper.Map<Category>(categoryDto);
        category.CategoryId = id;
        await _unitOfWork.CategoryRepository.UpdateAsync(existingCategory, category);
        await _unitOfWork.SaveChangesAsync();
        
        var res = _mapper.Map<CategoryDto>(category);
        return res;
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new ResourceNotFoundException("Category not found");
        }
        
        await _unitOfWork.CategoryRepository.DeleteAsync(category);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<CategoryDetailDto> AddProductsToCategoryAsync(int categoryId, List<int> productIds)
    {
        var category = await _unitOfWork.CategoryRepository.GetDetailCategoryByIdAsync(categoryId);
        if (category == null)
        {
            throw new ResourceNotFoundException("Category not found");
        }

        var products = await _unitOfWork.ProductRepository.GetProductsAsync(
            _unitOfWork.ProductRepository.GetQueryable()
                .Where(p => productIds.Contains(p.ProductId))
                .Where(p => p.CategoryId == null));
        
        await _unitOfWork.CategoryRepository.AddProductsToCategoryAsync(category, products.ToList());
        await _unitOfWork.SaveChangesAsync();
        
        var res = _mapper.Map<CategoryDetailDto>(category);
        return res;
    }
}