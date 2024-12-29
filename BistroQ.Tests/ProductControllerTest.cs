using BistroQ.API.Controllers.Product;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.NutritionFact;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BistroQ.Tests.Controllers;

[TestClass]
public class ProductControllerTests
{
    private Mock<IProductService> _mockProductService;
    private ProductController _productController;

    [TestInitialize]
    public void Setup()
    {
        _mockProductService = new Mock<IProductService>();
        _productController = new ProductController(_mockProductService.Object);
    }

    [TestMethod]
    public async Task GetRecommendations_Success()
    {
        // Arrange
        var orderId = "order123";
        var size = 5;
        var expectedProducts = new List<ProductResponseDto>
        {
            new ProductResponseDto { ProductId = 1, Name = "Product 1" },
            new ProductResponseDto { ProductId = 2, Name = "Product 2" }
        };

        _mockProductService
            .Setup(x => x.GetRecommendedProductsAsync(orderId, size))
            .ReturnsAsync(expectedProducts);

        // Act
        var result = await _productController.GetRecommendations(size, orderId) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        var response = result.Value as ResponseDto<IEnumerable<ProductResponseDto>>;
        Assert.IsNotNull(response);
        Assert.AreEqual(2, response.Data.Count());
        Assert.AreEqual(1, response.Data.First().ProductId);
    }

    [TestMethod]
    public async Task GetRecommendations_OrderNotFound_ThrowsException()
    {
        // Arrange
        var orderId = "nonexistent_order";
        var size = 5;

        _mockProductService
            .Setup(x => x.GetRecommendedProductsAsync(orderId, size))
            .ThrowsAsync(new ResourceNotFoundException("Order not found"));

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ResourceNotFoundException>(async () =>
        {
            await _productController.GetRecommendations(size, orderId);
        });
    }

    [TestMethod]
    public async Task GetRecommendations_EmptyResults_ReturnsEmptyList()
    {
        // Arrange
        var orderId = "order123";
        var size = 5;
        var emptyList = new List<ProductResponseDto>();

        _mockProductService
            .Setup(x => x.GetRecommendedProductsAsync(orderId, size))
            .ReturnsAsync(emptyList);

        // Act
        var result = await _productController.GetRecommendations(size, orderId) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        var response = result.Value as ResponseDto<IEnumerable<ProductResponseDto>>;
        Assert.IsNotNull(response);
        Assert.IsFalse(response.Data.Any());
    }

    [TestMethod]
    public async Task GetRecommendations_WithNutritionFacts_Success()
    {
        // Arrange 
        var orderId = "order123";
        var size = 5;
        var expectedProducts = new List<ProductResponseDto>
        {
            new ProductResponseDto 
            { 
                ProductId = 1, 
                Name = "Product 1",
                NutritionFact = new NutritionFactDto 
                { 
                    Calories = 100,
                    Protein = 10
                }
            }
        };

        _mockProductService
            .Setup(x => x.GetRecommendedProductsAsync(orderId, size))
            .ReturnsAsync(expectedProducts);

        // Act
        var result = await _productController.GetRecommendations(size, orderId) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        var response = result.Value as ResponseDto<IEnumerable<ProductResponseDto>>;
        Assert.IsNotNull(response);
        var product = response.Data.First();
        Assert.IsNotNull(product.NutritionFact);
        Assert.AreEqual(100, product.NutritionFact.Calories);
    }

    [TestMethod]
    public async Task GetRecommendations_InvalidSize_ThrowsException()
    {
        // Arrange
        var orderId = "order123";
        var invalidSize = -1;

        _mockProductService
            .Setup(x => x.GetRecommendedProductsAsync(orderId, invalidSize))
            .ThrowsAsync(new ArgumentException("Size must be positive"));

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
        {
            await _productController.GetRecommendations(invalidSize, orderId);
        });
    }
}