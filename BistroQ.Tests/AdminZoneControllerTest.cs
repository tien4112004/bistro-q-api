using BistroQ.API.Controllers;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Dtos.Zones;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BistroQ.Tests.Controllers;

[TestClass]
public class AdminZoneControllerTest
{
	private Mock<IZoneService> _mockZoneService;
	private AdminZoneController _adminZoneController;

	[TestInitialize]
	public void Setup()
	{
		_mockZoneService = new Mock<IZoneService>();
		_adminZoneController = new AdminZoneController(_mockZoneService.Object);
	}

	[TestMethod]
	public async Task GetZones_Success()
	{
		// Arrange
		var zones = new List<ZoneDto> { new ZoneDto { ZoneId = 1, Name = "Zone1" } };
		var queryParams = new ZoneCollectionQueryParams { Page = 1, Size = 10 };
		_mockZoneService.Setup(x => x.GetAllAsync(queryParams)).ReturnsAsync((zones, zones.Count));

		// Act
		var result = await _adminZoneController.GetZones(queryParams) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as PaginationResponseDto<IEnumerable<ZoneDto>>;
		Assert.IsNotNull(response);
		Assert.AreEqual(true, response.Success);
		var data = response.Data as IEnumerable<ZoneDto>;
		Assert.AreEqual(1, data.Count());
		Assert.AreEqual(1, response.Data.First().ZoneId);
	}

	[TestMethod]
	public async Task GetZones_ThrowsException_WhenRetrievalFails()
	{
		// Arrange
		var queryParams = new ZoneCollectionQueryParams { Page = 1, Size = 10 };
		_mockZoneService.Setup(x => x.GetAllAsync(queryParams)).ThrowsAsync(new Exception("Failed to get zones"));

		// Act & Assert
		await Assert.ThrowsExceptionAsync<Exception>(async () =>
		{
			await _adminZoneController.GetZones(queryParams);
		});
	}

	[TestMethod]
	public async Task GetZone_Success()
	{
		// Arrange
		var zone = new ZoneDto { ZoneId = 1, Name = "Zone1" };
		_mockZoneService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(zone);

		// Act
		var result = await _adminZoneController.GetZone(1) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<ZoneDto>;
		Assert.IsNotNull(response);
		Assert.AreEqual(1, response.Data.ZoneId);
	}

	[TestMethod]
	public async Task GetZone_ThrowsException_WhenRetrievalFails()
	{
		// Arrange
		_mockZoneService.Setup(x => x.GetByIdAsync(1)).ThrowsAsync(new Exception("Failed to get zone"));

		// Act & Assert
		await Assert.ThrowsExceptionAsync<Exception>(async () =>
		{
			await _adminZoneController.GetZone(1);
		});
	}

	[TestMethod]
	public async Task AddZone_Success()
	{
		// Arrange
		var request = new CreateZoneRequestDto { Name = "NewZone" };
		var zone = new ZoneDto { ZoneId = 1, Name = "NewZone" };
		_mockZoneService.Setup(x => x.AddAsync(request)).ReturnsAsync(zone);

		// Act
		var result = await _adminZoneController.AddZone(request) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<ZoneDto>;
		Assert.IsNotNull(response);
		Assert.AreEqual(1, response.Data.ZoneId);
	}

	[TestMethod]
	public async Task AddZone_ThrowsException_WhenCreationFails()
	{
		// Arrange
		var request = new CreateZoneRequestDto { Name = "NewZone" };
		_mockZoneService.Setup(x => x.AddAsync(request)).ThrowsAsync(new Exception("Failed to create zone"));

		// Act & Assert
		await Assert.ThrowsExceptionAsync<Exception>(async () =>
		{
			await _adminZoneController.AddZone(request);
		});
	}

	[TestMethod]
	public async Task AddTables_Success()
	{
		// Arrange
		var requests = new List<CreateTableRequestDto> { new CreateTableRequestDto { ZoneId = 1, SeatsCount = 4 } };
		var zone = new ZoneDetailDto { ZoneId = 1, Name = "Zone1" };
		_mockZoneService.Setup(x => x.AddTablesToZoneAsync(1, requests)).ReturnsAsync(zone);

		// Act
		var result = await _adminZoneController.AddTables(1, requests) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<ZoneDetailDto>;
		Assert.IsNotNull(response);
		Assert.AreEqual(1, response.Data.ZoneId);
	}

	[TestMethod]
	public async Task AddTables_ThrowsException_WhenAddTablesFails()
	{
		// Arrange
		var requests = new List<CreateTableRequestDto> { new CreateTableRequestDto { ZoneId = 1, SeatsCount = 4 } };
		_mockZoneService.Setup(x => x.AddTablesToZoneAsync(1, requests)).ThrowsAsync(new Exception("Failed to add tables"));

		// Act & Assert
		await Assert.ThrowsExceptionAsync<Exception>(async () =>
		{
			await _adminZoneController.AddTables(1, requests);
		});
	}

	[TestMethod]
	public async Task UpdateZone_Success()
	{
		// Arrange
		var request = new UpdateZoneRequestDto { Name = "UpdatedZone" };
		var zone = new ZoneDto { ZoneId = 1, Name = "UpdatedZone" };
		_mockZoneService.Setup(x => x.UpdateAsync(1, request)).ReturnsAsync(zone);

		// Act
		var result = await _adminZoneController.UpdateZone(1, request) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<ZoneDto>;
		Assert.IsNotNull(response);
		Assert.AreEqual(1, response.Data.ZoneId);
	}

	[TestMethod]
	public async Task UpdateZone_ThrowsException_WhenUpdateFails()
	{
		// Arrange
		var request = new UpdateZoneRequestDto { Name = "UpdatedZone" };
		_mockZoneService.Setup(x => x.UpdateAsync(1, request)).ThrowsAsync(new Exception("Failed to update zone"));

		// Act & Assert
		await Assert.ThrowsExceptionAsync<Exception>(async () =>
		{
			await _adminZoneController.UpdateZone(1, request);
		});
	}

	[TestMethod]
	public async Task DeleteZone_Success()
	{
		// Arrange
		_mockZoneService.Setup(x => x.DeleteAsync(1)).Returns(Task.CompletedTask);

		// Act
		var result = await _adminZoneController.DeleteZone(1) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<string>;
		Assert.IsNotNull(response);
		Assert.AreEqual("Zone deleted successfully", response.Data);
	}

	[TestMethod]
	public async Task DeleteZone_ThrowsException_WhenDeletionFails()
	{
		// Arrange
		_mockZoneService.Setup(x => x.DeleteAsync(1)).ThrowsAsync(new Exception("Failed to delete zone"));

		// Act & Assert
		await Assert.ThrowsExceptionAsync<Exception>(async () =>
		{
			await _adminZoneController.DeleteZone(1);
		});
	}
}
