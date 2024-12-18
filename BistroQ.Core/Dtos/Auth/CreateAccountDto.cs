using BistroQ.Core.Enums;

namespace BistroQ.Core.Dtos.Auth;

public class CreateAccountDto
{
    public string Username { get; set; }
    
    public string Password { get; set; }

    public string Role { get; set; } = BistroRoles.Client;
}