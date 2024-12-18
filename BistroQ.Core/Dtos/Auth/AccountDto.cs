using BistroQ.Core.Dtos.Tables;

namespace BistroQ.Core.Dtos.Auth;

public class AccountDto
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public int? TableId { get; set; }
    
    public TableDetailDto Table { get; set; }
}