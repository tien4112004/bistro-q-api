namespace BistroQ.Core.Dtos.Auth;

public class AccountCollectionQueryParams : BaseCollectionQueryParams
{
    public string? Username { get; set; }
    public string? Role { get; set; }
    public string? Zone { get; set; }
}