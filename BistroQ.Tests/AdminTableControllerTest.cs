using BistroQ.API.Controllers;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BistroQ.Tests.Controllers
{
	[TestClass]
	public class AdminTableControllerTests
	{
		private Mock<ITableService> _mockTableService;
		private AdminTableController _adminTableController;

		[TestInitialize]
		public void Setup()
		{
			_mockTableService = new Mock<ITableService>();
			_adminTableController = new AdminTableController(_mockTableService.Object);
		}

		[TestMethod]
		public async Task GetTables_Success()
		{
			// Arrange
			var tables = new List<TableDetailDto> { new TableDetailDto { TableId = 1, SeatsCount = 4 } };
			var queryParams = new TableCollectionQueryParams { Page = 1, Size = 10 };
			_mockTableService.Setup(x => x.GetAllAsync(queryParams)).ReturnsAsync((tables, tables.Count));

			// Act
			var result = await _adminTableController.GetTables(queryParams) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as PaginationResponseDto<IEnumerable<TableDetailDto>>;
			Assert.IsNotNull(response);
			Assert.AreEqual(true, response.Success);
			var data = response.Data as IEnumerable<TableDetailDto>;
			Assert.AreEqual(1, data.Count());
			Assert.AreEqual(1, response.Data.First().TableId);
		}

		[TestMethod]
		public async Task GetTables_ThrowsException_WhenRetrievalFails()
		{
			// Arrange
			var queryParams = new TableCollectionQueryParams { Page = 1, Size = 10 };
			_mockTableService.Setup(x => x.GetAllAsync(queryParams)).ThrowsAsync(new Exception("Failed to get tables"));

			// Act & Assert
			await Assert.ThrowsExceptionAsync<Exception>(async () =>
			{
				await _adminTableController.GetTables(queryParams);
			});
		}

		[TestMethod]
		public async Task GetTable_Success()
		{
			// Arrange
			var table = new TableDetailDto { TableId = 1, SeatsCount = 4 };
			_mockTableService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(table);

			// Act
			var result = await _adminTableController.GetTable(1) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as ResponseDto<TableDetailDto>;
			Assert.IsNotNull(response);
			Assert.AreEqual(1, response.Data.TableId);
		}

		[TestMethod]
		public async Task GetTable_ThrowsException_WhenRetrievalFails()
		{
			// Arrange
			_mockTableService.Setup(x => x.GetByIdAsync(1)).ThrowsAsync(new Exception("Failed to get table"));

			// Act & Assert
			await Assert.ThrowsExceptionAsync<Exception>(async () =>
			{
				await _adminTableController.GetTable(1);
			});
		}

		[TestMethod]
		public async Task AddTable_Success()
		{
			// Arrange
			var request = new CreateTableRequestDto { ZoneId = 1, SeatsCount = 4 };
			var table = new TableDto { TableId = 1, SeatsCount = 4 };
			_mockTableService.Setup(x => x.AddAsync(request)).ReturnsAsync(table);

			// Act
			var result = await _adminTableController.AddTable(request) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as ResponseDto<TableDto>;
			Assert.IsNotNull(response);
			Assert.AreEqual(1, response.Data.TableId);
		}

		[TestMethod]
		public async Task AddTable_ThrowsException_WhenCreationFails()
		{
			// Arrange
			var request = new CreateTableRequestDto { ZoneId = 1, SeatsCount = 4 };
			_mockTableService.Setup(x => x.AddAsync(request)).ThrowsAsync(new Exception("Failed to create table"));

			// Act & Assert
			await Assert.ThrowsExceptionAsync<Exception>(async () =>
			{
				await _adminTableController.AddTable(request);
			});
		}

		[TestMethod]
		public async Task AddTable_ThrowsException_WhenNegativeSeatsCount()
		{
			// Arrange
			var request = new CreateTableRequestDto { ZoneId = 1, SeatsCount = -1 };
			_mockTableService.Setup(x => x.AddAsync(request)).ThrowsAsync(new ArgumentException("Invalid argument"));

			// Act & Assert
			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await _adminTableController.AddTable(request);
			});
		}

		[TestMethod]
		public async Task UpdateTable_Success()
		{
			// Arrange
			var request = new UpdateTableRequestDto { ZoneId = 1, SeatsCount = 4 };
			var table = new TableDto { TableId = 1, SeatsCount = 4 };
			_mockTableService.Setup(x => x.UpdateAsync(1, request)).ReturnsAsync(table);

			// Act
			var result = await _adminTableController.UpdateTable(1, request) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as ResponseDto<TableDto>;
			Assert.IsNotNull(response);
			Assert.AreEqual(1, response.Data.TableId);
		}

		[TestMethod]
		public async Task UpdateTable_ThrowsException_WhenUpdateFails()
		{
			// Arrange
			var request = new UpdateTableRequestDto { ZoneId = 1, SeatsCount = 4 };
			_mockTableService.Setup(x => x.UpdateAsync(1, request)).ThrowsAsync(new Exception("Failed to update table"));

			// Act & Assert
			await Assert.ThrowsExceptionAsync<Exception>(async () =>
			{
				await _adminTableController.UpdateTable(1, request);
			});
		}

		[TestMethod]
		public async Task UpdateTable_ThrowsException_WhenNegativeSeatsCount()
		{
			// Arrange
			var request = new UpdateTableRequestDto { ZoneId = 1, SeatsCount = -1 };
			_mockTableService.Setup(x => x.UpdateAsync(1, request)).ThrowsAsync(new ArgumentException("Invalid argument"));

			// Act & Assert
			await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
			{
				await _adminTableController.UpdateTable(1, request);
			});
		}

		[TestMethod]
		public async Task DeleteTable_Success()
		{
			// Arrange
			_mockTableService.Setup(x => x.DeleteAsync(1)).Returns(Task.CompletedTask);

			// Act
			var result = await _adminTableController.DeleteTable(1) as OkObjectResult;

			// Assert
			Assert.IsNotNull(result);
			var response = result.Value as ResponseDto<string>;
			Assert.IsNotNull(response);
			Assert.AreEqual("Table deleted successfully", response.Data);
		}

		[TestMethod]
		public async Task DeleteTable_ThrowsException_WhenDeletionFails()
		{
			// Arrange
			_mockTableService.Setup(x => x.DeleteAsync(1)).ThrowsAsync(new Exception("Failed to delete table"));

			// Act & Assert
			await Assert.ThrowsExceptionAsync<Exception>(async () =>
			{
				await _adminTableController.DeleteTable(1);
			});
		}
	}
}