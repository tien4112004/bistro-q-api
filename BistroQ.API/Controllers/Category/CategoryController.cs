using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Category;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers.Category;


[ApiController]
[Route("api/[controller]")]
[Authorize]
[Tags("Category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
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
}