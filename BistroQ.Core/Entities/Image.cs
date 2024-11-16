namespace BistroQ.Core.Entities;

public class Image
{
    public string ImageId { get; set; }

    public string Name { get; set; } = null!;
    
    public string Path { get; set; } = null!;

    public string ContentType { get; set; } = null!;

    public long Size { get; set; }
    
    public string? ProductId { get; set; }
    
    public Product? Product { get; set; }
}