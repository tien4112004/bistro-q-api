using System.ComponentModel.DataAnnotations;
using BistroQ.Core.Dtos;
using BistroQ.Core.Dtos.Auth;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BistroQ.API.Controllers.Auth;

[Route("api/[controller]")]
[ApiController]
[Tags("Authentication")]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AuthController(
        ITokenService tokenService,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager)
    {
        _tokenService = tokenService;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody, Required] LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.Username);
        if (user == null)
        {
            throw new UnauthorizedException("User not found.");
        }

        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
        if (!result.Succeeded)
        {
            throw new UnauthorizedException("Invalid password.");
        }

        var accessToken = await _tokenService.GenerateAccessToken(user);
        var refreshToken = await _tokenService.GenerateRefreshToken(user);
        
        var roles = await _userManager.GetRolesAsync(user);

        return Ok(new ResponseDto<Object>(new
            { AccessToken = accessToken, RefreshToken = refreshToken, UserId = user.Id, Role = roles[0] }));
    }

    [HttpPost]
    [Route("refresh")]
    public async Task<IActionResult> Refresh([FromBody, Required] RefreshTokenDto refreshTokenDto)
    {
        var user = await _userManager.FindByIdAsync(refreshTokenDto.UserId);
        if (user == null || !await _tokenService.ValidateRefreshToken(user, refreshTokenDto.RefreshToken))
        {
            throw new UnauthorizedException("Invalid refresh token.");
        }

        var newAccessToken = await _tokenService.GenerateAccessToken(user);
        return Ok(new ResponseDto<Object>(new { AccessToken = newAccessToken }));
    }
}