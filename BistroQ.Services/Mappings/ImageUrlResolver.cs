using AutoMapper;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Services.Helpers;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BistroQ.Core.Mappings;

public class ImageUrlResolver : IValueResolver<Product, ProductResponseDto, string>
{
    private readonly ICloudStorageService _cloudStorageService;

    public ImageUrlResolver(ICloudStorageService cloudStorageService)
    {
        _cloudStorageService = cloudStorageService;
    }

    public string Resolve(Product source, ProductResponseDto destination, string destMember, ResolutionContext context)
    {
        var key = source.ImageId + ContentTypeValue.GetExtension(source.Image.ContentType);
        var url = _cloudStorageService.GeneratePresignedUrlAsync(key,
            TimeSpan.FromDays(1));
        return url;
    }
}