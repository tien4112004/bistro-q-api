using System.Text.Json;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = BistroRoles.Admin)]
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
    
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductRequestDto request)
    {
        var product = await _productService.AddAsync(request);
        
        return Ok(new ResponseDto<ProductDto>(product));
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
    {
        var updatedProduct = await _productService.UpdateAsync(productDto);
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