using BistroQ.API.Controllers.Order;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Claims;

namespace BistroQ.Tests.Controllers;

[TestClass]
public class ClientOrderControllerTests
{
	private Mock<IOrderService> _mockOrderService;
	private Mock<UserManager<AppUser>> _mockUserManager;
	private ClientOrderController _clientOrderController;

	[TestInitialize]
	public void Setup()
	{
		_mockOrderService = new Mock<IOrderService>();
		_mockUserManager = new Mock<UserManager<AppUser>>(
			new Mock<IUserStore<AppUser>>().Object,
			null,
			new Mock<IPasswordHasher<AppUser>>().Object,
			new IUserValidator<AppUser>[0],
			new IPasswordValidator<AppUser>[0],
			new UpperInvariantLookupNormalizer(),
			new IdentityErrorDescriber(),
			null,
			new Mock<ILogger<UserManager<AppUser>>>().Object);

		_clientOrderController = new ClientOrderController(_mockOrderService.Object, _mockUserManager.Object);
	}

	private void SetupUserManager(AppUser user)
	{
		var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
		{
				new Claim(ClaimTypes.NameIdentifier, user.Id)
		}));

		_mockUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
		_clientOrderController.ControllerContext = new ControllerContext
		{
			HttpContext = new DefaultHttpContext { User = userPrincipal }
		};
	}

	[TestMethod]
	public async Task CreateOrder_Success()
	{
		// Arrange
		var user = new AppUser { Id = "user_id", TableId = 1 };
		SetupUserManager(user);
		var order = new OrderDto { OrderId = "1", TableId = 1, PeopleCount = 4 };
		_mockOrderService.Setup(x => x.CreateOrder(1, 4)).ReturnsAsync(order);

		// Act
		var result = await _clientOrderController.CreateOrder(4) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<OrderDto>;
		Assert.IsNotNull(response);
		Assert.AreEqual("1", response.Data.OrderId);
		Assert.AreEqual(4, response.Data.PeopleCount);
	}

	[TestMethod]
	public async Task GetOrder_Success()
	{
		// Arrange
		var user = new AppUser { Id = "user_id", TableId = 1 };
		SetupUserManager(user);
		var order = new DetailOrderDto { OrderId = "1", TableId = 1 };
		_mockOrderService.Setup(x => x.GetOrder(1)).ReturnsAsync(order);

		// Act
		var result = await _clientOrderController.GetOrder() as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<DetailOrderDto>;
		Assert.IsNotNull(response);
		Assert.AreEqual("1", response.Data.OrderId);
	}

	[TestMethod]
	public async Task DeleteOrder_Success()
	{
		// Arrange
		var user = new AppUser { Id = "user_id", TableId = 1 };
		SetupUserManager(user);
		_mockOrderService.Setup(x => x.DeleteOrder(1)).Returns(Task.CompletedTask);

		// Act
		var result = await _clientOrderController.DeleteOrder() as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<string>;
		Assert.IsNotNull(response);
		Assert.AreEqual("Order deleted", response.Data);
	}

	[TestMethod]
	public async Task UpdatePeopleCount_Success()
	{
		// Arrange
		var user = new AppUser { Id = "user_id", TableId = 1 };
		SetupUserManager(user);
		var order = new OrderDto { OrderId = "1", TableId = 1, PeopleCount = 5 };
		_mockOrderService.Setup(x => x.UpdatePeopleCount(1, 5)).ReturnsAsync(order);

		// Act
		var result = await _clientOrderController.UpdatePeopleCount(5) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<OrderDto>;
		Assert.IsNotNull(response);
		Assert.AreEqual("1", response.Data.OrderId);
		Assert.AreEqual(5, response.Data.PeopleCount);
	}

	[TestMethod]
	public async Task AddProductsToOrder_Success()
	{
		// Arrange
		var user = new AppUser { Id = "user_id", TableId = 1 };
		SetupUserManager(user);
		var orderItems = new List<CreateOrderItemRequestDto>
			{
				new CreateOrderItemRequestDto { ProductId = 1, Quantity = 2 }
			};
		var addedItems = new List<OrderItemDto>
			{
				new OrderItemDto { ProductId = 1, Quantity = 2 }
			};
		_mockOrderService.Setup(x => x.AddProductsToOrder(1, orderItems)).ReturnsAsync(addedItems);

		// Act
		var result = await _clientOrderController.AddProductsToOrder(orderItems) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<IEnumerable<OrderItemDto>>;
		Assert.IsNotNull(response);
		Assert.AreEqual(1, response.Data.First().ProductId);
		Assert.AreEqual(2, response.Data.First().Quantity);
	}

	[TestMethod]
	public async Task RemoveProductsFromOrder_Success()
	{
		// Arrange
		var user = new AppUser { Id = "user_id", TableId = 1 };
		SetupUserManager(user);
		var orderItems = new List<RemoveOrderItemRequestDto>
			{
				new RemoveOrderItemRequestDto { OrderItemId = "item1" }
			};
		var cancelledItems = new List<OrderItemDto>
			{
				new OrderItemDto { ProductId = 1, Quantity = 0 }
			};
		_mockOrderService.Setup(x => x.CancelOrderItems(1, orderItems)).ReturnsAsync(cancelledItems);

		// Act
		var result = await _clientOrderController.RemoveProductsFromOrder(orderItems) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<IEnumerable<OrderItemDto>>;
		Assert.IsNotNull(response);
		Assert.AreEqual(1, response.Data.First().ProductId);
		Assert.AreEqual(0, response.Data.First().Quantity);
	}
}
