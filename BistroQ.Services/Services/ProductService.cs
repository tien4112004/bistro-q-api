using System.Text.Json;
using AutoMapper;
using BistroQ.Core.Common.Builder;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Services;

namespace BistroQ.Services.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProductDto> GetByIdAsync(int productId)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
        if(product == null)
        {
            throw new ResourceNotFoundException("Product not found");
        }
        
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<(IEnumerable<ProductDto> Products, int Count)> GetAllAsync(ProductCollectionQueryParams queryParams)
    {
        var builder = 
            new ProductQueryableBuilder(await _unitOfWork.ProductRepository.GetQueryable())
            .WithName(queryParams.Name)
            .WithPrice(queryParams.Price)
            .WithUnit(queryParams.Unit)
            .WithDiscountPrice(queryParams.DiscountPrice);
        
        var count = await _unitOfWork.ProductRepository.GetProductsCountAsync(builder.Build());

        builder
            .ApplySorting(queryParams.OrderBy, queryParams.OrderDirection)
            .ApplyPaging(queryParams.Page, queryParams.Size);

        var products = await _unitOfWork.ProductRepository.GetProductsAsync(builder.Build());

        return (_mapper.Map<IEnumerable<ProductDto>>(products), count);
    }

    public async Task<ProductDto> AddAsync(CreateProductRequestDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);

        var createdProduct = await _unitOfWork.ProductRepository.AddAsync(product);

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ProductDto>(createdProduct);
    }

    public async Task<ProductDto> UpdateAsync(int productId, UpdateProductRequestDto productDto)
    {
        var existingProduct = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
        if (existingProduct == null)
        {
            throw new ResourceNotFoundException("Product not found");
        }
        
        var newProduct = _mapper.Map<Product>(productDto);
        newProduct.ProductId = productId;

        await _unitOfWork.ProductRepository.UpdateAsync(existingProduct, newProduct);
        await _unitOfWork.SaveChangesAsync();
        
        var updatedProduct = await _unitOfWork.ProductRepository.GetByIdAsync(productId);

        return _mapper.Map<ProductDto>(updatedProduct);
    }

    public async Task DeleteAsync(int productId)
    {
        var existingProduct = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
        if (existingProduct == null)
        {
            throw new ResourceNotFoundException("Product not found");
        }
        
        await _unitOfWork.ProductRepository.DeleteAsync(existingProduct);
        await _unitOfWork.SaveChangesAsync();
    }
}