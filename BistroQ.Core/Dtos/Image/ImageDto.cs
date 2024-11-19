namespace BistroQ.Core.Dtos.Image;

public class ImageDto
{
    public Guid ImageId { get; set; }

    public string Name { get; set; } = null!;

    public string ContentType { get; set; } = null!;
}