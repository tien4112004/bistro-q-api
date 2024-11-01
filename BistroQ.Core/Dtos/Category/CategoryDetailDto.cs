using BistroQ.Core.Dtos.Products;

namespace BistroQ.Core.Dtos.Category;

public class CategoryDetailDto
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
}