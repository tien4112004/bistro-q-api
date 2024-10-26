namespace BistroQ.Core.Common.Builder;

public abstract class BaseQueryableBuilder<T> where T : class
{
    protected IQueryable<T> Queryable;

    protected BaseQueryableBuilder(IQueryable<T> queryable)
    {
        Queryable = queryable;
    }

    public IQueryable<T> Build()
    {
        return Queryable;
    }
}