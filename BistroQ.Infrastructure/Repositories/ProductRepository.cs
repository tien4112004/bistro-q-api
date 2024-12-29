using System.Linq.Expressions;
using BistroQ.Core.Dtos.Products;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Core.Specifications;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(BistroQContext context) : base(context)
    {
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
    
    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        var product = await DbSet
            .Include(p => p.Image)
            .FirstOrDefaultAsync(p => p.ProductId == productId);
        
        return product;
    }
    
    public async Task<IEnumerable<Product>> GetRecommendedProductsAsync(string orderId)
    {
        return await DbSet
            .FromSqlRaw("""
            with NormalizedNutritionFact as (
            select 
            n.ProductId,
            n.Calories / 2000 as NormalizedCalories,
              n.Protein / 75 as NormalizedProtein,
              n.Carbohydrates / 300 as NormalizedCarb,
              n.Fat / 70 as NormalizedFat,
              n.Fiber / 25 as NormalizedFiber
            from `nutritionfact` n),
            CurrentNormalized AS (
            select 
            sum(NormalizedCalories) / o.PeopleCount as CurrentCalories,
            sum(NormalizedCarb) / o.PeopleCount as CurrentCarb,
            sum(NormalizedProtein) / o.PeopleCount as CurrentProtein,
            sum(NormalizedFat) / o.PeopleCount as CurrentFat,
            sum(NormalizedFiber) / o.PeopleCount as CurrentFiber
            from `orderitem` i
            join NormalizedNutritionFact as x on x.ProductId = i.ProductId
            join `order` as o on o.OrderId = {0} and i.OrderId = {0}
            group by o.OrderId)

            select p.Name, p.ProductId, p.Price, p.ImageId, p.CategoryId, p.DiscountPrice, p.Unit,
            (CASE 
              WHEN (n.NormalizedProtein - CurrentNormalized.CurrentProtein) < 0 
              THEN 0.3 * ABS(n.NormalizedProtein - CurrentNormalized.CurrentProtein) * 2
              ELSE 0.3 * ABS(n.NormalizedProtein - CurrentNormalized.CurrentProtein)
            END +
            CASE 
              WHEN (n.NormalizedFat - CurrentNormalized.CurrentFat) < 0 
              THEN 0.2 * ABS(n.NormalizedFat - CurrentNormalized.CurrentFat) * 2
              ELSE 0.2 * ABS(n.NormalizedFat - CurrentNormalized.CurrentFat)
            END +
            CASE 
              WHEN (n.NormalizedCalories - CurrentNormalized.CurrentCalories) < 0 
              THEN 0.1 * ABS(n.NormalizedCalories - CurrentNormalized.CurrentCalories) * 2
              ELSE 0.1 * ABS(n.NormalizedCalories - CurrentNormalized.CurrentCalories)
            END +
            CASE 
              WHEN (n.NormalizedFiber - CurrentNormalized.CurrentFiber) < 0 
              THEN 0.2 * ABS(n.NormalizedFiber - CurrentNormalized.CurrentFiber) * 2
              ELSE 0.2 * ABS(n.NormalizedFiber - CurrentNormalized.CurrentFiber) 
            END +
            CASE 
              WHEN (n.NormalizedCarb - CurrentNormalized.CurrentCarb) < 0 
              THEN 0.2 * ABS(n.NormalizedCarb - CurrentNormalized.CurrentCarb) * 2
              ELSE 0.2 * ABS(n.NormalizedCarb - CurrentNormalized.CurrentCarb)
            END) as Rating
            from `product` p
            join NormalizedNutritionFact as n on p.ProductId = n.ProductId
            join CurrentNormalized
            order by Rating desc
            limit 10
            """.Replace("\r\n", " "), orderId).ToListAsync();
    }
}