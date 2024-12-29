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

    public async Task<IEnumerable<Product>> GetProductsAsync(IQueryable<Product> queryable)
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

    private class NutritionalConstants
    {
        // Daily recommended values
        public const decimal DAILY_CALORIES = 2000m;
        public const decimal DAILY_PROTEIN = 75m;
        public const decimal DAILY_CARBOHYDRATES = 300m;
        public const decimal DAILY_FAT = 70m;
        public const decimal DAILY_FIBER = 25m;

        // Rating weights (must sum to 1.0)
        public const decimal PROTEIN_WEIGHT = 0.3m;
        public const decimal FAT_WEIGHT = 0.2m;
        public const decimal CALORIES_WEIGHT = 0.1m;
        public const decimal FIBER_WEIGHT = 0.2m;
        public const decimal CARB_WEIGHT = 0.2m;

        // Individual deficiency multipliers
        public const decimal PROTEIN_DEFICIENCY_MULTIPLIER = 1.0m;
        public const decimal FAT_DEFICIENCY_MULTIPLIER = 3.0m; // Fat is harmful in excess
        public const decimal CALORIES_DEFICIENCY_MULTIPLIER = 2.0m;
        public const decimal FIBER_DEFICIENCY_MULTIPLIER = 0.5m; 
        public const decimal CARB_DEFICIENCY_MULTIPLIER = 2.0m;
    }

    public async Task<IEnumerable<Product>> GetRecommendedProductsAsync(string orderId, int size)
    {
        const string query = """
                             with NormalizedNutritionFact as (
                             select 
                                 n.ProductId,
                                 n.Calories / {1} as NormalizedCalories,
                                 n.Protein / {2} as NormalizedProtein,
                                 n.Carbohydrates / {3} as NormalizedCarb,
                                 n.Fat / {4} as NormalizedFat,
                                 n.Fiber / {5} as NormalizedFiber
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
                                 THEN {6} * ABS(n.NormalizedProtein - CurrentNormalized.CurrentProtein) * {11}
                                 ELSE {6} * ABS(n.NormalizedProtein - CurrentNormalized.CurrentProtein)
                             END +
                             CASE 
                                 WHEN (n.NormalizedFat - CurrentNormalized.CurrentFat) < 0 
                                 THEN {7} * ABS(n.NormalizedFat - CurrentNormalized.CurrentFat) * {12}
                                 ELSE {7} * ABS(n.NormalizedFat - CurrentNormalized.CurrentFat)
                             END +
                             CASE 
                                 WHEN (n.NormalizedCalories - CurrentNormalized.CurrentCalories) < 0 
                                 THEN {8} * ABS(n.NormalizedCalories - CurrentNormalized.CurrentCalories) * {13}
                                 ELSE {8} * ABS(n.NormalizedCalories - CurrentNormalized.CurrentCalories)
                             END +
                             CASE 
                                 WHEN (n.NormalizedFiber - CurrentNormalized.CurrentFiber) < 0 
                                 THEN {9} * ABS(n.NormalizedFiber - CurrentNormalized.CurrentFiber) * {14}
                                 ELSE {9} * ABS(n.NormalizedFiber - CurrentNormalized.CurrentFiber) 
                             END +
                             CASE 
                                 WHEN (n.NormalizedCarb - CurrentNormalized.CurrentCarb) < 0 
                                 THEN {10} * ABS(n.NormalizedCarb - CurrentNormalized.CurrentCarb) * {15}
                                 ELSE {10} * ABS(n.NormalizedCarb - CurrentNormalized.CurrentCarb)
                             END) as Rating
                             from `product` p
                             join NormalizedNutritionFact as n on p.ProductId = n.ProductId
                             join CurrentNormalized
                             order by Rating desc
                             limit {16};
                             """;

        string formattedQuery = string.Format(
            query.Replace("\r\n", " "),
            orderId,
            NutritionalConstants.DAILY_CALORIES,
            NutritionalConstants.DAILY_PROTEIN,
            NutritionalConstants.DAILY_CARBOHYDRATES,
            NutritionalConstants.DAILY_FAT,
            NutritionalConstants.DAILY_FIBER,
            NutritionalConstants.PROTEIN_WEIGHT,
            NutritionalConstants.FAT_WEIGHT,
            NutritionalConstants.CALORIES_WEIGHT,
            NutritionalConstants.FIBER_WEIGHT,
            NutritionalConstants.CARB_WEIGHT,
            NutritionalConstants.PROTEIN_DEFICIENCY_MULTIPLIER,
            NutritionalConstants.FAT_DEFICIENCY_MULTIPLIER,
            NutritionalConstants.CALORIES_DEFICIENCY_MULTIPLIER,
            NutritionalConstants.FIBER_DEFICIENCY_MULTIPLIER,
            NutritionalConstants.CARB_DEFICIENCY_MULTIPLIER,
            size
        );

        return await DbSet.FromSqlRaw(formattedQuery).ToListAsync();
    }
}