using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;

namespace BistroQ.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly BistroQContext _context;
    
    public OrderRepository(BistroQContext context) : base(context)
    {
        _context = context;
    }
}