using System.Text;
using System.Text.Json;
using BistroQ.Core.Common.Settings;
using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Services;

namespace BistroQ.Services.Services;

public class QrCodePaymentService : IPaymentService
{
    private readonly HttpClient _client;
    private readonly PaymentSettings _settings;

    public QrCodePaymentService(PaymentSettings settings)
    {
        _client = new HttpClient();
        _settings = settings;
    }

    public async Task<string> InitiatePayment(OrderDto order)
    {
        try
        {
            var content = new StringContent(
                JsonSerializer.Serialize(new
                {
                    accountNo = _settings.AccountNumber,
                    accountName = _settings.AccountName,
                    acqId = _settings.AcqId,
                    amount = order.TotalAmount,
                    addInfo = $"Payment for table {order.TableId},  order {order.OrderId}",
                    format = "text",
                    template = "compact"
                }),
                Encoding.UTF8,
                "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{_settings.BaseUrl}/generate");
            request.Content = content;
            request.Headers.Add("x-client-id", _settings.ClientId);
            request.Headers.Add("x-api-key", _settings.ApiKey);

            var response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to initiate payment");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonObject = JsonSerializer.Deserialize<JsonElement>(responseContent);
            var data = jsonObject.GetProperty("data");
            return data.GetProperty("qrCode").GetString() ?? "";
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            throw;
        }
    }
}