using BistroQ.Infrastructure.Identity;

namespace BistroQ.Core.Interfaces.Services;

/// <summary>
/// Interface for TokenService
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Generates an access token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom the access token is generated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the generated access token as a string.</returns>
    Task<string> GenerateAccessToken(AppUser user);

    /// <summary>
    /// Generates a refresh token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom the refresh token is generated.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the generated refresh token as a string.</returns>
    Task<string> GenerateRefreshToken(AppUser user);

    /// <summary>
    /// Validates the specified refresh token for the given user.
    /// </summary>
    /// <param name="user">The user to whom the refresh token belongs.</param>
    /// <param name="refreshToken">The refresh token to validate.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the refresh token is valid.</returns>
    Task<bool> ValidateRefreshToken(AppUser user, string refreshToken);
}