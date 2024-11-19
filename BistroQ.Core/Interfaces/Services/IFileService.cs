using Microsoft.AspNetCore.Http;

namespace BistroQ.Core.Interfaces.Services;

public interface IFileService
{
    public Task<byte[]> GetBytes(IFormFile file);

    public Task<string> GetText(IFormFile file);
}