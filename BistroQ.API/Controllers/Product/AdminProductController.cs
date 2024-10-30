using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers.Product;

[ApiController]
[Route("api/Admin/Product")]
[Authorize(Roles = BistroRoles.Admin)]
[Tags("Admin Product")]
public class AdminProductController : ControllerBase
{
    private readonly IProductService _productService;
    
    public AdminProductController(IProductService productService)
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
    
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductRequestDto request)
    {
        var product = await _productService.AddAsync(request);
        return Ok(new ResponseDto<ProductDto>(product));
    }
    
    [HttpPut]
    [Route("{productId:int}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] UpdateProductRequestDto productDto)
    {
        var updatedProduct = await _productService.UpdateAsync(productId, productDto);
        return Ok(new ResponseDto<ProductDto>(updatedProduct));
    }
    
    [HttpDelete]
    [Route("{productId:int}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
    {
        await _productService.DeleteAsync(productId);
        return Ok(new ResponseDto<string>("Product deleted successfully"));
    }
}