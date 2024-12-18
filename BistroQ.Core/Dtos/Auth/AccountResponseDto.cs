namespace BistroQ.Core.Dtos.Auth;

public class AccountResponseDto
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public int? TableId { get; set; }
}