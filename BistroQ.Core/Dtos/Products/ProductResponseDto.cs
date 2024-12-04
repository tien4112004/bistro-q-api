namespace BistroQ.Core.Dtos.Products;

public class ProductResponseDto 
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public string? Unit { get; set; }

    public decimal? DiscountPrice { get; set; }
   
    public string? ImageUrl { get; set; }
}