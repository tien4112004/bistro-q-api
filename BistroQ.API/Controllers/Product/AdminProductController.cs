using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Image;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Enums;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;

namespace BistroQ.API.Controllers.Product;

[ApiController]
[Route("api/Admin/Product")]
[Authorize(Roles = BistroRoles.Admin)]
[Tags("Admin Product")]
public class AdminProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IFileService _fileService;
    
    public AdminProductController(IProductService productService, IFileService fileService)
    {
        _productService = productService;
        _fileService = fileService;
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
        return Ok(new ResponseDto<ProductResponseDto>(product));
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromForm] CreateProductMultipartRequestDto request)
    {
        ProductResponseDto product;
        if (request.Image == null)
        {
            product = await _productService.AddAsync(request.Product, null);
            return Ok(new ResponseDto<ProductResponseDto>(product));
        }
        using var stream = request.Image.OpenReadStream();
        var imageRequest = new ImageRequestDto
        {
            Name = request.Image.FileName,
            Data = stream,
            ContentType = request.Image.ContentType
        };
        
        product = await _productService.AddAsync(request.Product, imageRequest);
        return Ok(new ResponseDto<ProductResponseDto>(product));
    }
    
    [HttpPut]
    [Route("{productId:int}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] UpdateProductRequestDto productDto)
    {
        var updatedProduct = await _productService.UpdateAsync(productId, productDto);
        return Ok(new ResponseDto<ProductDto>(updatedProduct));
    }
    
    [HttpPatch]
    [Route("{productId:int}")]
    public async Task<IActionResult> UpdateProductImage([FromRoute] int productId, IFormFile image)
    {
        using var stream = image.OpenReadStream();
        var imageRequest = new ImageRequestDto
        {
            Name = image.FileName,
            Data = stream,
            ContentType = image.ContentType
        };
        
        
        var updatedProduct = await _productService.UpdateImageAsync(productId, imageRequest);
        return Ok(new ResponseDto<ProductResponseDto>(updatedProduct));
    }
    
    [HttpDelete]
    [Route("{productId:int}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
    {
        await _productService.DeleteAsync(productId);
        return Ok(new ResponseDto<string>("Product deleted successfully"));
    }
}