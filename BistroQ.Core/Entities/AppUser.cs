using Microsoft.AspNetCore.Identity;

namespace BistroQ.Core.Entities;

public class AppUser : IdentityUser
{
    public int? TableId { get; set; }
    
    public virtual Table? Table { get; set; }
    public string? RefreshToken { get; set; }
    
    public DateTime? RefreshTokenExpiryTime { get; set; }
}