using BistroQ.API.Controllers.Auth;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Auth;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BistroQ.Tests.Controllers;

[TestClass]
public class AuthControllerTests
{
	private Mock<ITokenService> _mockTokenService;
	private Mock<UserManager<AppUser>> _mockUserManager;
	private Mock<SignInManager<AppUser>> _mockSignInManager;
	private AuthController _authController;

	[TestInitialize]
	public void Setup()
	{
		_mockTokenService = new Mock<ITokenService>();
		_mockUserManager = new Mock<UserManager<AppUser>>(
			new Mock<IUserStore<AppUser>>().Object, null, null, null, null, null, null, null, null);
		_mockSignInManager = new Mock<SignInManager<AppUser>>(
			_mockUserManager.Object, null, null, null, null, null, null);

		_authController = new AuthController(
			_mockTokenService.Object,
			_mockUserManager.Object,
			_mockSignInManager.Object);
	}

	[TestMethod]
	public async Task Login_Success()
	{
		// Arrange
		var loginDto = new LoginDto { Username = "testuser", Password = "password" };
		var user = new AppUser { UserName = "testuser" };
		var roles = new List<string> { "User" };

		_mockUserManager.Setup(x => x.FindByNameAsync(loginDto.Username)).ReturnsAsync(user);
		_mockSignInManager.Setup(x => x.PasswordSignInAsync(user, loginDto.Password, false, false))
			.ReturnsAsync(SignInResult.Success);
		_mockTokenService.Setup(x => x.GenerateAccessToken(user)).ReturnsAsync("access_token");
		_mockTokenService.Setup(x => x.GenerateRefreshToken(user)).ReturnsAsync("refresh_token");
		_mockUserManager.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(roles);

		// Act
		var result = await _authController.Login(loginDto) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<object>;
		Assert.IsNotNull(response);
		dynamic data = response.Data;
		Assert.AreEqual("access_token", data.AccessToken);
		Assert.AreEqual("refresh_token", data.RefreshToken);
		Assert.AreEqual("User", data.Role);
	}

	[TestMethod]
	[ExpectedException(typeof(UnauthorizedException))]
	public async Task Login_UserNotFound()
	{
		// Arrange
		var loginDto = new LoginDto { Username = "nonexistentuser", Password = "password" };

		_mockUserManager.Setup(x => x.FindByNameAsync(loginDto.Username)).ReturnsAsync((AppUser)null);

		// Act
		await _authController.Login(loginDto);
	}

	[TestMethod]
	[ExpectedException(typeof(UnauthorizedException))]
	public async Task Login_InvalidPassword()
	{
		// Arrange
		var loginDto = new LoginDto { Username = "testuser", Password = "wrongpassword" };
		var user = new AppUser { UserName = "testuser" };

		_mockUserManager.Setup(x => x.FindByNameAsync(loginDto.Username)).ReturnsAsync(user);
		_mockSignInManager.Setup(x => x.PasswordSignInAsync(user, loginDto.Password, false, false))
			.ReturnsAsync(SignInResult.Failed);

		// Act
		await _authController.Login(loginDto);
	}

	[TestMethod]
	public async Task Refresh_Success()
	{
		// Arrange
		var refreshTokenDto = new RefreshTokenDto { UserId = "user_id", RefreshToken = "valid_refresh_token" };
		var user = new AppUser { Id = "user_id" };

		_mockUserManager.Setup(x => x.FindByIdAsync(refreshTokenDto.UserId)).ReturnsAsync(user);
		_mockTokenService.Setup(x => x.ValidateRefreshToken(user, refreshTokenDto.RefreshToken)).ReturnsAsync(true);
		_mockTokenService.Setup(x => x.GenerateAccessToken(user)).ReturnsAsync("new_access_token");

		// Act
		var result = await _authController.Refresh(refreshTokenDto) as OkObjectResult;

		// Assert
		Assert.IsNotNull(result);
		var response = result.Value as ResponseDto<object>;
		Assert.IsNotNull(response);
		dynamic data = response.Data;
		Assert.AreEqual("new_access_token", data.AccessToken);
	}

	[TestMethod]
	[ExpectedException(typeof(UnauthorizedException))]
	public async Task Refresh_InvalidRefreshToken()
	{
		// Arrange
		var refreshTokenDto = new RefreshTokenDto { UserId = "user_id", RefreshToken = "invalid_refresh_token" };
		var user = new AppUser { Id = "user_id" };

		_mockUserManager.Setup(x => x.FindByIdAsync(refreshTokenDto.UserId)).ReturnsAsync(user);
		_mockTokenService.Setup(x => x.ValidateRefreshToken(user, refreshTokenDto.RefreshToken)).ReturnsAsync(false);

		// Act
		await _authController.Refresh(refreshTokenDto);
	}
}
