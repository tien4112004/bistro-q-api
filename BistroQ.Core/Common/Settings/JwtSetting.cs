namespace BistroQ.Core.Common.Settings;

public class JwtSettings 
{
    public string SecretKey { get; set; } 
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int AccessTokenExpiresInMinutes { get; set; }
    
    public int RefreshTokenExpiredInMinutes { get; set; }

    public JwtSettings ReadFromEnvironment()
    {
        SecretKey =  Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? throw new InvalidOperationException("JWT secret key is not configured.");
        Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? throw new InvalidOperationException("JWT issuer is not configured.");
        Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? throw new InvalidOperationException("JWT audience is not configured.");
        AccessTokenExpiresInMinutes = int.Parse(Environment.GetEnvironmentVariable("JWT_ACCESS_TOKEN_EXPIRES_IN_MINUTES") ?? "10");
        RefreshTokenExpiredInMinutes =
            Environment.GetEnvironmentVariable("ENV") == "development"
                ? int.Parse(Environment.GetEnvironmentVariable("TEST_JWT_REFRESH_TOKEN_EXPIRES_IN_MINUTES") ?? "10")
                : int.Parse(Environment.GetEnvironmentVariable("JWT_REFRESH_TOKEN_EXPIRES_IN_DAYS") ?? "1") * 24 * 60;

        return this;
    }
}