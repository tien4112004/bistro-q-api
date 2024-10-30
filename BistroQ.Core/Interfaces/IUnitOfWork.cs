using BistroQ.Core.Interfaces.Repositories;

namespace BistroQ.Core.Interfaces;

public interface IUnitOfWork 
{
    IProductRepository ProductRepository { get; }
    IZoneRepository ZoneRepository { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}