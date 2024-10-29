namespace BistroQ.Core.Dtos.Auth;

public class RefreshTokenDto
{
    public string UserId { get; set; }
    public string RefreshToken { get; set; }
}