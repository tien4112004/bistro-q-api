namespace BistroQ.Core.Dtos.Products;

public class ProductCollectionQueryParams : BaseCollectionQueryParams
{
    public string? Name { get; set; }
    
    public decimal? Price { get; set; }
    
    public string? Unit { get; set; }
    
    public decimal? DiscountPrice { get; set; }
}