namespace BistroQ.Core.Interfaces.Services;

public interface ICloudStorageService
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
    Task DeleteFileAsync(string fileUrl);
    Task<Stream> DownloadFileAsync(string fileUrl);
    Task<byte[]> DownloadFileAsBytesAsync(string fileUrl);
    Task<string> GeneratePresignedUrlAsync(string fileUrl, TimeSpan expiration);
}