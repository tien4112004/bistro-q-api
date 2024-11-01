namespace BistroQ.Core.Interfaces.Repositories;

/// <summary>
/// Represents a generic repository interface for basic CRUD operations
/// </summary>
/// <typeparam name="T">The entity type this repository works with</typeparam>
public interface IGenericRepository<T> where T : class
{
    /// <summary>
    /// Gets a queryable instance of the entity set
    /// </summary>
    /// <returns>An IQueryable of type T that can be further filtered, ordered, or projected</returns>
    IQueryable<T> GetQueryable();
    
    /// <summary>
    /// Retrieves an entity by its identifier
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve</param>
    /// <returns>The entity if found; null otherwise</returns>
    /// <remarks>
    /// Consider whether int is always the appropriate type for your ID
    /// You might want to make this generic as well: TId
    /// </remarks>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Retrieves all entities in the repository
    /// </summary>
    /// <returns>An enumerable of all entities in the repository</returns>
    /// <remarks>
    /// Should be used with caution on large datasets
    /// </remarks>
    Task<IEnumerable<T>> GetAllAsync();
    
    /// <summary>
    /// Adds a new entity to the repository
    /// </summary>
    /// <param name="entity">The entity to add</param>
    /// <returns>The added entity (potentially with generated values like ID)</returns>
    Task<T?> AddAsync(T entity);

    /// <summary>
    /// Adds a collection of entities to the repository
    /// </summary>
    /// <param name="entities">The collection of entities to add</param>
    /// <returns>A task representing the asynchronous operation, containing the added entities</returns>
    Task<IEnumerable<T>?> AddRangeAsync(IEnumerable<T> entities);
    
    /// <summary>
    /// Replaces an existing entity with a new version
    /// </summary>
    /// <param name="oldEntity">The existing entity to be replaced</param>
    /// <param name="newEntity">The new entity data to replace with</param>
    /// <remarks>
    /// This is a full replacement operation. Consider whether partial updates
    /// might be more appropriate for your use case
    /// </remarks>
    Task UpdateAsync(T oldEntity, T newEntity);

    /// <summary>
    /// Removes an entity from the repository
    /// </summary>
    /// <param name="entity">The entity to remove</param>
    Task DeleteAsync(T entity);
}