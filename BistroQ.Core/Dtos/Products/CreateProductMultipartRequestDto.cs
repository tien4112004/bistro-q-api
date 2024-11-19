using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.Core.Dtos.Products;

public class CreateProductMultipartRequestDto
{
    [FromForm(Name = "Product")]
    public CreateProductRequestDto Product { get; set; } = null!;
    
    [FromForm(Name = "Image")]
    public IFormFile? Image { get; set; }
}