using System;
using System.Collections.Generic;

namespace bistro_q_api.Models;

public partial class NutritionFact
{
    public int ProductId { get; set; }

    public double? Calories { get; set; }

    public virtual Product Product { get; set; } = null!;
}
