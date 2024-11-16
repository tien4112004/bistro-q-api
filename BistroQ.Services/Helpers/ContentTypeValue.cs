namespace BistroQ.Services.Helpers;

public static class ContentTypeValue
{
    public const string ImageJpeg = "image/jpeg";
    public const string ImagePng = "image/png";
    public const string ImageGif = "image/gif";
    public const string ImageBmp = "image/bmp";
    
    public static string GetExtension(string contentType)
    {
        return contentType switch
        {
            ImageJpeg => ".jpg",
            ImagePng => ".png",
            ImageGif => ".gif",
            ImageBmp => ".bmp",
            _ => string.Empty
        };
    }
}