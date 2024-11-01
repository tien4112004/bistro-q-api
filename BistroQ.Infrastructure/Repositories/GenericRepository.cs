using System.Linq.Expressions;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly BistroQContext _context;
    private readonly DbSet<T> _dbSet;
    
    public GenericRepository(BistroQContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IQueryable<T> GetQueryable()
    {
        return _dbSet.AsQueryable();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var res = await _dbSet.FindAsync(id);
        return res;
    }
    
    public async Task<T?> AddAsync(T entity)
    {
        var res = await _dbSet.AddAsync(entity);
        return res.Entity;
    }
    
    public async Task<IEnumerable<T>?> AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        return entities.ToList();
    }

    public async Task UpdateAsync(T oldEntity, T newEntity)
    {
        _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await Task.CompletedTask;
    }
}