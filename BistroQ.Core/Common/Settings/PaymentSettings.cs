namespace BistroQ.Core.Common.Settings;

public class PaymentSettings
{
    public string ApiKey { get; set; }
    
    public string ClientId { get; set; }
    
    public string BaseUrl { get; set; }
    
    public string AcqId { get; set; }
    
    public string AccountNumber { get; set; }
    
    public string AccountName { get; set; }

    public PaymentSettings ReadFromEnvironment()
    {
        ApiKey = Environment.GetEnvironmentVariable("VIETQR_API_KEY") ?? "";
        ClientId = Environment.GetEnvironmentVariable("VIETQR_CLIENT_ID") ?? "";
        BaseUrl = "https://api.vietqr.io/v2";
        AcqId = Environment.GetEnvironmentVariable("VIETQR_ACQ_ID") ?? "";
        AccountNumber = Environment.GetEnvironmentVariable("VIETQR_ACCOUNT_NUMBER") ?? "";
        AccountName = Environment.GetEnvironmentVariable("VIETQR_ACCOUNT_NAME") ?? "";
        
        return this;
    }
}