using BistroQ.Core.Dtos.NutritionFact;

namespace BistroQ.Core.Dtos.Products;

public class CreateProductRequestDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Unit { get; set; }
    public decimal DiscountPrice { get; set; }
    public int? CategoryId { get; set; }
    public double Calories { get; set; }
}