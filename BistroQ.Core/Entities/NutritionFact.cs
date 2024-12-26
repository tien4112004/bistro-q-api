namespace BistroQ.Core.Entities;

public class NutritionFact
{
    public int ProductId { get; set; }

    public double? Calories { get; set; }
    public double? Fat { get; set; }
    public double? Fiber { get; set; }
    public double? Protein { get; set; }
    public double? Carbohydrates { get; set; }

    public virtual Product Product { get; set; } = null!;
}