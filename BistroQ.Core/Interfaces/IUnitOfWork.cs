using BistroQ.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BistroQ.Core.Interfaces;

public interface IUnitOfWork 
{
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    IZoneRepository ZoneRepository { get; }
    ITableRepository TableRepository { get; }
    IOrderRepository OrderRepository { get; }
    IImageRepository ImageRepository { get; }
    INutritionFactRepository NutritionFactRepository { get; }
    
    IOrderItemRepository OrderItemRepository { get; }

    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}