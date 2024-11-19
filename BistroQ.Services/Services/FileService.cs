using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace BistroQ.Services.Services;

public class FileService : IFileService
{
    public async Task<byte[]> GetBytes(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }

    public async Task<string> GetText(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        return await reader.ReadToEndAsync();
    }
}