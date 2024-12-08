using BistroQ.API.Controllers.Category;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Category;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BistroQ.Tests.Controllers
{
	[TestClass]
	public class AdminCategoryControllerTests
	{
		private Mock<ICategoryService> _mockCategoryService;
		private AdminCategoryController _adminCategoryController;

		[TestInitialize]
		public void Setup()
		{
			_mockCategoryService = new Mock<ICategoryService>();
			_adminCategoryController = new AdminCategoryController(_mockCategoryService.Object);
		}

		[TestMethod]
		public async Task GetCategories_Success()
		{
			// Arrange
			var categories = new List<CategoryDto> { new CategoryDto { Name = "Category1" } };
			_mockCategoryService.Setup(x => x.GetCategoriesAsync()).ReturnsAsync((categories, categories.Count));

			// Act
			var result = await _adminCategoryController.GetCategories() as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as PaginationResponseDto<IEnumerable<CategoryDto>>;
			Assert.IsNotNull(response);
			Assert.AreEqual(true, response.Success);
			var data = response.Data as IEnumerable<CategoryDto>;
			Assert.AreEqual(1, data.Count());
			Assert.AreEqual("Category1", response.Data.First().Name);
		}

		[TestMethod]
		public async Task GetCategory_Success()
		{
			// Arrange
			var category = new CategoryDetailDto { Name = "Category1" };
			_mockCategoryService.Setup(x => x.GetCategoryByIdAsync(1)).ReturnsAsync(category);

			// Act
			var result = await _adminCategoryController.GetCategory(1) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as ResponseDto<CategoryDetailDto>;
			Assert.IsNotNull(response);
			Assert.AreEqual("Category1", response.Data.Name);
		}

		[TestMethod]
		public async Task AddProductsToCategory_Success()
		{
			// Arrange
			var category = new CategoryDetailDto { Name = "Category1" };
			var productIds = new List<int> { 1, 2, 3 };
			_mockCategoryService.Setup(x => x.AddProductsToCategoryAsync(1, productIds)).ReturnsAsync(category);

			// Act
			var result = await _adminCategoryController.AddProductsToCategory(1, productIds) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as ResponseDto<CategoryDetailDto>;
			Assert.IsNotNull(response);
			Assert.AreEqual("Category1", response.Data.Name);
		}

		[TestMethod]
		public async Task AddCategory_Success()
		{
			// Arrange
			var request = new CreateCategoryRequestDto { Name = "NewCategory" };
			var category = new CategoryDto { Name = "NewCategory" };
			_mockCategoryService.Setup(x => x.CreateCategoryAsync(request)).ReturnsAsync(category);

			// Act
			var result = await _adminCategoryController.AddCategory(request) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as ResponseDto<CategoryDto>;
			Assert.IsNotNull(response);
			Assert.AreEqual("NewCategory", response.Data.Name);
		}

		[TestMethod]
		public async Task UpdateCategory_Success()
		{
			// Arrange
			var request = new UpdateCategoryRequestDto { Name = "UpdatedCategory" };
			var category = new CategoryDto { Name = "UpdatedCategory" };
			_mockCategoryService.Setup(x => x.UpdateCategoryAsync(1, request)).ReturnsAsync(category);

			// Act
			var result = await _adminCategoryController.UpdateCategory(1, request) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as ResponseDto<CategoryDto>;
			Assert.IsNotNull(response);
			Assert.AreEqual("UpdatedCategory", response.Data.Name);
		}

		[TestMethod]
		public async Task DeleteCategory_Success()
		{
			// Arrange
			_mockCategoryService.Setup(x => x.DeleteCategoryAsync(1)).Returns(Task.CompletedTask);

			// Act
			var result = await _adminCategoryController.DeleteCategory(1) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as ResponseDto<string>;
			Assert.IsNotNull(response);
			Assert.AreEqual("Category deleted successfully", response.Data);
		}
	}
}
