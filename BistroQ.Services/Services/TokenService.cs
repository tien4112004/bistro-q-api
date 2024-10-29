using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BistroQ.Core.Common.Settings;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Infrastructure.Data;
using BistroQ.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BistroQ.Services.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly JwtSettings _jwtSettings;
    private readonly BistroQContext _context;
    private ITokenService _tokenServiceImplementation;

    public TokenService(UserManager<AppUser> userManager, JwtSettings jwtSettings, BistroQContext context)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings;
        _context = context;
    }

    public async Task<string> GenerateAccessToken(AppUser user)
    {
        var authClaims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var jwtExpirationMinutes = _jwtSettings.AccessTokenExpiresInMinutes;

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: authClaims,
            expires: DateTime.Now.AddMinutes(jwtExpirationMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> GenerateRefreshToken(AppUser user)
    {    
        using var rng = RandomNumberGenerator.Create();
        using var sha256 = SHA256.Create();
    
        var randomNumber = new byte[32];
        rng.GetBytes(randomNumber);
    
        var refreshToken = Convert.ToBase64String(randomNumber);
        var hashedToken = Convert.ToBase64String(
            sha256.ComputeHash(Encoding.UTF8.GetBytes(refreshToken))
        );

        user.RefreshToken = hashedToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow
            .AddMinutes(_jwtSettings.RefreshTokenExpiredInMinutes);

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            // Log error
            throw new Exception();
        }

        return refreshToken;
    }

    public Task<bool> ValidateRefreshToken(AppUser user, string refreshToken)
    {
        using var sha256 = SHA256.Create();
        var hashedProvidedToken = Convert.ToBase64String(
            sha256.ComputeHash(Encoding.UTF8.GetBytes(refreshToken))
        );

        return Task.FromResult(user.RefreshToken == hashedProvidedToken && user.RefreshTokenExpiryTime > DateTime.UtcNow);
    }
}