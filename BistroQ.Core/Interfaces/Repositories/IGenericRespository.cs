namespace BistroQ.Core.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<IQueryable<T>> GetQueryable();
    
    Task<T?> GetByIdAsync(int id);
    Task<T?> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}