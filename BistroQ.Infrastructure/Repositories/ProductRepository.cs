using System.Linq.Expressions;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Core.Specifications;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly BistroQContext _context;
    
    public ProductRepository(BistroQContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Product>>  GetProductsAsync(IQueryable<Product> queryable)
    {
        var products = await queryable.ToListAsync();
        
        return products;
    }
    
    public async Task<int> GetProductsCountAsync(IQueryable<Product> queryable)
    {
        var count = await queryable.CountAsync();
        
        return count;
    }
}