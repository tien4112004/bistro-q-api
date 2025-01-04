using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BistroQ.API.Controllers.Product;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly UserManager<AppUser> _userManager;
    
    public ProductController(IProductService productService, UserManager<AppUser> userManager)
    {
        _productService = productService;
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] ProductCollectionQueryParams queryParams)
    {
        var (products, count) = await _productService.GetAllAsync(queryParams);
        return Ok(new PaginationResponseDto<IEnumerable<ProductResponseDto>>(products, count, queryParams.Page, queryParams.Size));
    }
    
    [HttpGet]
    [Route("{productId:int}")]
    public async Task<IActionResult> GetProduct([FromRoute] int productId)
    {
        var product = await _productService.GetByIdAsync(productId);
        return Ok(new ResponseDto<ProductResponseDto>(product));
    }
    
    [HttpGet]
    [Route("Recommendations")]
    public async Task<IActionResult> GetRecommendations()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user?.TableId == null)
        {
            throw new UnauthorizedException("User not found");
        }
        var tableId = user.TableId.Value;
        var products = await _productService.GetRecommendedProductsAsync(tableId);
        return Ok(new ResponseDto<IEnumerable<ProductResponseDto>>(products));
    }
}