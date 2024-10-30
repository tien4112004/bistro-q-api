using BistroQ.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace BistroQ.Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    
    public DateTime? RefreshTokenExpiryTime { get; set; }
}