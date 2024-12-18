using System.IO.Compression;
using System.Text.Json;
using AutoMapper;
using BistroQ.Core.Common.Builder;
using BistroQ.Core.Dtos.Image;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Services.Helpers;
using Microsoft.AspNetCore.Http;

namespace BistroQ.Services.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICloudStorageService _cloudStorageService;
    
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ICloudStorageService cloudStorageService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cloudStorageService = cloudStorageService;
    }

    public async Task<ProductResponseDto> GetByIdAsync(int productId)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
        if(product == null)
        {
            throw new ResourceNotFoundException("Product not found");
        }
        
        return _mapper.Map<ProductResponseDto>(product);
    }

    public async Task<(IEnumerable<ProductResponseDto> Products, int Count)> GetAllAsync(ProductCollectionQueryParams queryParams)
    {
        var builder = 
            new ProductQueryableBuilder(_unitOfWork.ProductRepository.GetQueryable())
            .WithCategoryId(queryParams.CategoryId)
            .WithName(queryParams.Name)
            .WithPrice(queryParams.Price);
        
        var count = await _unitOfWork.ProductRepository.GetProductsCountAsync(builder.Build());

        builder
            .IncludeCategory()
            .IncludeImage()
            .IncludeNutritionFact()
            .ApplySorting(queryParams.OrderBy, queryParams.OrderDirection)
            .ApplyPaging(queryParams.Page, queryParams.Size);

        var products = await _unitOfWork.ProductRepository.GetProductsAsync(builder.Build());

        return (_mapper.Map<IEnumerable<ProductResponseDto>>(products), count);
    }

    public async Task<ProductResponseDto> AddAsync(CreateProductRequestDto productDto, ImageRequestDto? image)
    {
        var product = _mapper.Map<Product>(productDto);

        if (productDto.CategoryId != null)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(productDto.CategoryId.Value);
            if (category == null)
            {
                throw new ResourceNotFoundException("Category not found");
            }
        }

        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var createdProduct = await _unitOfWork.ProductRepository.AddAsync(product);
            if (createdProduct == null)
            {
                throw new Exception("Failed to create product");
            }

            if (image != null)
            {
                var newImage = _mapper.Map<Image>(image);
                var createdImage = await _unitOfWork.ImageRepository.AddAsync(newImage);
                if (createdImage == null)
                {
                    throw new Exception("Failed to create image");
                }
       
                await _cloudStorageService.UploadFileAsync(
                    image.Data, 
                    createdImage.ImageId + ContentTypeValue.GetExtension(createdImage.ContentType), 
                    createdImage.ContentType);

                
                createdProduct.ImageId = createdImage.ImageId;
            }

            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
            return _mapper.Map<ProductResponseDto>(createdProduct);
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<ProductDto> UpdateAsync(int productId, UpdateProductRequestDto productDto)
    {
        var existingProduct = await _unitOfWork.ProductRepository.GetProductByIdAsync(productId);
        if (existingProduct == null)
        {
            throw new ResourceNotFoundException("Product not found");
        }
        
        var newProduct = _mapper.Map<Product>(productDto);
        
        if (existingProduct.NutritionFact == null)
        {
            existingProduct.NutritionFact = new NutritionFact();
        }
        existingProduct.NutritionFact.Calories = productDto.Calories;
        
        if (newProduct.CategoryId != null)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(newProduct.CategoryId.Value);
            if (category == null)
            {
                throw new ResourceNotFoundException("Category not found");
            }
        }

        newProduct.ProductId = productId;
        newProduct.ImageId = existingProduct.ImageId;

        await _unitOfWork.ProductRepository.UpdateAsync(existingProduct, newProduct);
        await _unitOfWork.SaveChangesAsync();
        
        var updatedProduct = await _unitOfWork.ProductRepository.GetByIdAsync(productId);

        return _mapper.Map<ProductDto>(updatedProduct);
    }

    public async Task<ProductResponseDto> UpdateImageAsync(int productId, ImageRequestDto image)
    {
        
        var existingProduct = await _unitOfWork.ProductRepository.GetProductByIdAsync(productId);
        if (existingProduct == null)
        {
            throw new ResourceNotFoundException("Product not found");
        }
        
        var existingImage = await _unitOfWork.ImageRepository.GetByProductIdAsync(productId);
        if (existingImage == null)
        {
            throw new ResourceNotFoundException("Image not found");
        }
        
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            existingImage.Name = image.Name;
            existingImage.ContentType = image.ContentType;
            
            await _cloudStorageService.UploadFileAsync(
                image.Data, 
                existingImage.ImageId + ContentTypeValue.GetExtension(image.ContentType), 
                image.ContentType);
            
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }

        var updatedProduct = await _unitOfWork.ProductRepository.GetProductByIdAsync(productId);
        return _mapper.Map<ProductResponseDto>(updatedProduct);
    }

    public async Task DeleteAsync(int productId)
    {
        var existingProduct = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
        if (existingProduct == null)
        {
            throw new ResourceNotFoundException("Product not found");
        }

        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var existingImage = await _unitOfWork.ImageRepository.GetByProductIdAsync(productId);
            if (existingImage != null)
            {
                await _cloudStorageService.DeleteFileAsync(existingImage.ImageId + ContentTypeValue.GetExtension(existingImage.ContentType));
                await _unitOfWork.ImageRepository.DeleteAsync(existingImage);
            }

            await _unitOfWork.ProductRepository.DeleteAsync(existingProduct);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}