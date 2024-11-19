using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BistroQ.Core.Entities;
namespace BistroQ.Core.Entities;

public class Product
{
    public int ProductId { get; set; }

    public string? Name { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public string? Unit { get; set; }

    public decimal? DiscountPrice { get; set; }
    
    public Guid? ImageId { get; set; }
    
    public virtual Category? Category { get; set; }

    public virtual Image? Image { get; set; }

    public virtual NutritionFact? NutritionFact { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}