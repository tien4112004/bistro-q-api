namespace BistroQ.Core.Enums;

public class BistroRoles
{
    public const string Admin = "Admin";
    public const string Cashier = "Cashier";
    public const string Kitchen = "Kitchen";
    public const string Client = "Client";
    
    public static string[] AllRoles = { Admin, Cashier, Kitchen, Client };
}