using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace BistroQ.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IZoneRepository ZoneRepository { get; }
    public ITableRepository TableRepository { get; }
    
    public IImageRepository ImageRepository { get; }
    
    public IOrderRepository OrderRepository { get; }
    
    public IOrderItemRepository OrderItemRepository { get; }
    
    public INutritionFactRepository NutritionFactRepository { get; }
    
    public BistroQContext Context { get; }

    private IDbContextTransaction? _transaction;
    
    public UnitOfWork(
        BistroQContext context,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IZoneRepository zoneRepository, 
        ITableRepository tableRepository,
        IImageRepository imageRepository,
        IOrderItemRepository orderItemRepository,
        IOrderRepository orderRepository,
        INutritionFactRepository nutritionFactRepository)
    {
        Context = context;
        ProductRepository = productRepository;
        CategoryRepository = categoryRepository;
        ZoneRepository = zoneRepository;
        TableRepository = tableRepository;
        OrderRepository = orderRepository;
        OrderItemRepository = orderItemRepository;
        ImageRepository = imageRepository;
        NutritionFactRepository = nutritionFactRepository;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await Context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await Context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {        
        try
        {
            await _transaction?.CommitAsync();
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync()
    {
        try
        {
            await _transaction?.RollbackAsync();
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}