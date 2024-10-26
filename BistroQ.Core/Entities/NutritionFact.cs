namespace BistroQ.Core.Entities;

public class NutritionFact
{
    public int ProductId { get; set; }

    public double? Calories { get; set; }

    public virtual Product Product { get; set; } = null!;
}