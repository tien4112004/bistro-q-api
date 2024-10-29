using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BistroQ.API.Controllers.Product;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] ProductCollectionQueryParams queryParams)
    {
        var (products, count) = await _productService.GetAllAsync(queryParams);
        return Ok(new PaginationResponseDto<IEnumerable<ProductDto>>(products, count, queryParams.Page, queryParams.Size));
    }
    
    [HttpGet]
    [Route("{productId:int}")]
    public async Task<IActionResult> GetProduct([FromRoute] int productId)
    {
        var product = await _productService.GetByIdAsync(productId);
        return Ok(new ResponseDto<ProductDto>(product));
    }
}