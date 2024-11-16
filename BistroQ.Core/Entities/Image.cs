namespace BistroQ.Core.Entities;

public class Image
{
    public Guid ImageId { get; set; }

    public string Name { get; set; } = null!;
    
    public string ContentType { get; set; } = null!;
    
    public virtual Product? Product { get; set; }
}