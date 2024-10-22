using System;
using System.Collections.Generic;

namespace bistro_q_api.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public string? Unit { get; set; }

    public decimal? DiscountPrice { get; set; }

    public virtual Category? Category { get; set; }

    public virtual NutritionFact? NutritionFact { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
