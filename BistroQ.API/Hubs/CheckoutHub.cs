using System.Security.Claims;
using AutoMapper;
using BistroQ.Core.Dtos.Orders;
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
    private readonly ITableService _tableService;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    
    public CheckoutHub(IOrderService orderService, IPaymentService paymentService, UserManager<AppUser> userManager, ITableService tableService, IMapper mapper)
    {
        _orderService = orderService;
        _paymentService = paymentService;
        _tableService = tableService;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task InitiateCheckout(int tableId)
    {
        try
        {
            var order = await _orderService.GetOrderByTableId(tableId);
            if (order == null)
            {
                throw new ResourceNotFoundException("Order not found");
            }
            
            var table = await _tableService.GetByIdAsync(tableId);
            var paymentData = await _paymentService.InitiatePayment(_mapper.Map<OrderDto>(order)); 
            
            Console.WriteLine($"Payment initiated for table {tableId} in zone {table.ZoneId}");
            
            await Clients.Caller.SendAsync("CheckoutInitiated", paymentData);
            await Clients.Group("Cashiers").SendAsync("NewCheckout", tableId, table.Number, table.ZoneName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            await Clients.Caller.SendAsync("CheckoutError", e.Message);
        }
    }

    public async Task CompleteCheckout(int tableId)
    {
        try
        {
            var order = await _orderService.GetOrderByTableId(tableId);
            if (order == null)
            {
                throw new ResourceNotFoundException("Order not found");
            }
            
            Console.WriteLine($"Payment completed for table {tableId}");
            
            // await _orderService.UpdateStatus(tableId, OrderStatus.Completed);
            await Clients.Group($"Client_{tableId}").SendAsync("CheckoutCompleted");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
            await Clients.Caller.SendAsync("CheckoutError", e.Message);
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