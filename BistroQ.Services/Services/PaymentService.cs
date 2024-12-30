using BistroQ.Core.Interfaces.Services;

namespace BistroQ.Services.Services;

public class PaymentService : IPaymentService
{
    public Task<string> InitiatePayment(decimal? amount)
    {
        return Task.FromResult("https://payment.com");
    }
}