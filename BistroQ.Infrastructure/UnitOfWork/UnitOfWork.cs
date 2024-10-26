using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace BistroQ.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    public BistroQContext Context { get; }

    private IDbContextTransaction? _transaction;
    
    public UnitOfWork(BistroQContext context,IProductRepository productRepository)
    {
        Context = context;
        ProductRepository = productRepository;
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