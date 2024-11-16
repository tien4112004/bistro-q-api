namespace BistroQ.Core.Dtos.Image;

public class ImageRequestDto
{
    public string Name { get; set; }

    public string ContentType { get; set; }
    
    public Stream Data { get; set; }
}