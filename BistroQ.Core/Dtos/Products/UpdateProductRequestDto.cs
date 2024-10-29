namespace BistroQ.Core.Dtos.Products;

public class UpdateProductRequestDto
{
    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Unit { get; set; }

    public decimal? DiscountPrice { get; set; }
}