namespace BistroQ.Core.Dtos.Orders;

public class OrderItemCollectionQueryParams : BaseCollectionQueryParams
{
    public string[]? Status { get; set; }
    
    public DateTime? CreatedFrom { get; set; }
    
    public DateTime? CreatedTo { get; set; } = DateTime.Now;
    
    public DateTime? UpdatedFrom { get; set; }
    
    public DateTime? UpdatedTo { get; set; } = DateTime.Now;
}