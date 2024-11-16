namespace BistroQ.Core.Interfaces.Services;

public interface ICloudStorageService
{
    Task UploadFileAsync(Stream fileStream, string key, string contentType);
    Task DeleteFileAsync(string key);
    Task<Stream> DownloadFileAsync(string key);
    Task<byte[]> DownloadFileAsBytesAsync(string key);
    string GeneratePresignedUrlAsync(string? key, TimeSpan expiration);
}