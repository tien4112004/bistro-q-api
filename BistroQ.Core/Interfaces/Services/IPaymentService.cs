using BistroQ.Core.Dtos.Orders;
using BistroQ.Core.Entities;

namespace BistroQ.Core.Interfaces.Services;

public interface IPaymentService
{
    Task<string> InitiatePayment(OrderDto order);
}