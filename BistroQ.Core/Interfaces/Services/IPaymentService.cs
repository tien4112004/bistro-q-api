namespace BistroQ.Core.Interfaces.Services;

public interface IPaymentService
{
    Task<string> InitiatePayment(decimal? amount);
}