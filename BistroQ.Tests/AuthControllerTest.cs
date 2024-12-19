using BistroQ.API.Controllers.Auth;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Auth;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Domain.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
			new Mock<IUserStore<AppUser>>().Object,
			null,
			new Mock<IPasswordHasher<AppUser>>().Object,
			new IUserValidator<AppUser>[0],
			new IPasswordValidator<AppUser>[0],
			new UpperInvariantLookupNormalizer(),
			new IdentityErrorDescriber(),
			null,
			new Mock<ILogger<UserManager<AppUser>>>().Object);

		var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
		var mockClaimsPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<AppUser>>();
		var mockOptions = new Mock<IOptions<IdentityOptions>>();
		var mockLogger = new Mock<ILogger<SignInManager<AppUser>>>();
		var mockSchemeProvider = new Mock<IAuthenticationSchemeProvider>();
		var mockUserConfirmation = new Mock<IUserConfirmation<AppUser>>();

		_mockSignInManager = new Mock<SignInManager<AppUser>>(
			_mockUserManager.Object,
			mockHttpContextAccessor.Object,
			mockClaimsPrincipalFactory.Object,
			mockOptions.Object,
			mockLogger.Object,
			mockSchemeProvider.Object,
			mockUserConfirmation.Object);

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
		var response = result.Value as ResponseDto<LoginResponseDto>;
		Assert.IsNotNull(response);
		Assert.AreEqual("access_token", response.Data.AccessToken);
		Assert.AreEqual("refresh_token", response.Data.RefreshToken);
		Assert.AreEqual("User", response.Data.Role);
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
		var accessToken = response.Data?.GetType().GetProperty("AccessToken")?.GetValue(response.Data, null);
		Assert.AreEqual("new_access_token", accessToken);
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
