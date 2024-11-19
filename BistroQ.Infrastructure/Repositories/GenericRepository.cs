using System.Linq.Expressions;
using BistroQ.Core.Interfaces.Repositories;
using BistroQ.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly BistroQContext Context;
    protected readonly DbSet<T> DbSet;
    
    public GenericRepository(BistroQContext context)
    {
        Context = context;
        DbSet = context.Set<T>();
    }

    public IQueryable<T> GetQueryable()
    {
        return DbSet.AsQueryable();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        var res = await DbSet.FindAsync(id);
        return res;
    }
    
    public async Task<T?> AddAsync(T entity)
    {
        var res = await DbSet.AddAsync(entity);
        return res.Entity;
    }
    
    public async Task<IEnumerable<T>?> AddRangeAsync(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
        return entities.ToList();
    }

    public Task UpdateAsync(T oldEntity, T newEntity)
    {
        Context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(T entity)
    {
        DbSet.Remove(entity);
        await Task.CompletedTask;
    }
}