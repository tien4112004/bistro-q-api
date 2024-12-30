using System.Security.Claims;
using BistroQ.Core.Entities;
using BistroQ.Core.Enums;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace BistroQ.API.Hubs;

public class CheckoutHub : Hub
{
    private readonly IOrderService _orderService;
    private readonly IPaymentService _paymentService;
    private readonly UserManager<AppUser> _userManager;
    
    public CheckoutHub(IOrderService orderService, IPaymentService paymentService, UserManager<AppUser> userManager)
    {
        _orderService = orderService;
        _paymentService = paymentService;
        _userManager = userManager;
    }

    public async Task InitiatePayment(int tableId, int zoneId)
    {
        try
        {
            var order = await _orderService.GetOrderByTableId(tableId);
            if (order == null)
            {
                throw new ResourceNotFoundException("Order not found");
            }

            // var paymentUrl = await _paymentService.InitiatePayment(order.TotalAmount); // <--- Generate payment URL
            
            var paymentUrl = "https://example.com/payment"; // <--- Temporary payment URL
            
            Console.WriteLine($"Payment initiated for table {tableId} in zone {zoneId}");
            
            await Clients.Caller.SendAsync("PaymentInitiated", paymentUrl);
            await Clients.Group("Cashiers").SendAsync("NewPayment", tableId, zoneId);
        }
        catch (ResourceNotFoundException e)
        {
            await Clients.Caller.SendAsync("OrderNotFound", e.Message);
        }
        catch (Exception e)
        {
            await Clients.Caller.SendAsync("PaymentError", e.Message);
        }
    }

    public async Task CompletePayment(int tableId, int zoneId)
    {
        try
        {
            var order = await _orderService.GetOrderByTableId(tableId);
            if (order == null)
            {
                throw new ResourceNotFoundException("Order not found");
            }
            
            Console.WriteLine($"Payment completed for table {tableId} in zone {zoneId}");

            // await _orderService.UpdateStatus(tableId, OrderStatus.Completed);
            await Clients.Group($"Client_{tableId}").SendAsync("PaymentCompleted");
        }
        catch (ResourceNotFoundException e)
        {
            await Clients.Caller.SendAsync("OrderNotFound", e.Message);
        }
        catch (Exception e)
        {
            await Clients.Caller.SendAsync("PaymentError", e.Message);
        }
    }
    
    public override async Task OnConnectedAsync()
    {
        var userRole = Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        if (userRole == BistroRoles.Cashier)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Cashiers");
        }
        else if (userRole == BistroRoles.Client)
        {
            var user = await _userManager.GetUserAsync(Context.User);
            
            await Groups.AddToGroupAsync(Context.ConnectionId, "Client_" + user.TableId.Value);
        }
    }
}