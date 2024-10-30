using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Category;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers.Category;

[ApiController]
[Route("api/Admin/[controller]")]
[Authorize(Roles = BistroRoles.Admin)]
[Tags("Admin Category")]
public class AdminCategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    
    public AdminCategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var (categories, count) = await _categoryService.GetCategoriesAsync();
        return Ok(new PaginationResponseDto<IEnumerable<CategoryDto>>(categories, count, 1, count));
    }
    
    [HttpGet("{categoryId:int}")]
    public async Task<IActionResult> GetCategory(int categoryId)
    {
        var category = await _categoryService.GetCategoryByIdAsync(categoryId);
        return Ok(new ResponseDto<CategoryDetailDto>(category));
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] CreateCategoryRequestDto request)
    {
        var category = await _categoryService.CreateCategoryAsync(request);
        return Ok(new ResponseDto<CategoryDto>(category));
    }
    
    [HttpPut("{categoryId:int}")]
    public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] UpdateCategoryRequestDto request)
    {
        var updatedCategory = await _categoryService.UpdateCategoryAsync(categoryId, request);
        return Ok(new ResponseDto<CategoryDto>(updatedCategory));
    }
    
    [HttpDelete("{categoryId:int}")]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        await _categoryService.DeleteCategoryAsync(categoryId);
        return Ok(new ResponseDto<string>("Category deleted successfully"));
    }
}