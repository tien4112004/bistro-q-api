using System.Numerics;
using AutoMapper.Configuration.Conventions;
using BistroQ.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Core.Common.Builder;

public class ZoneQueryableBuilder : BaseQueryableBuilder<Zone>
{
    public ZoneQueryableBuilder(IQueryable<Zone> queryable) : base(queryable)
    {
    }

    public ZoneQueryableBuilder WithName(string? name)
    {
        if (string.IsNullOrEmpty(name)) return this;
        Queryable = Queryable.Where(z => z.Name != null && z.Name.Contains(name));
        return this;    
    }

    public ZoneQueryableBuilder ApplyPaging(int page, int size)
    {
        Queryable = Queryable.Skip((page - 1) * size).Take(size);
        return this;
    }
    
    public ZoneQueryableBuilder ApplySorting(string? orderBy, string? orderDirection)
    {
        var isDescending = orderDirection != "asc";
        Queryable = orderBy switch
        {
            nameof(Zone.Name) => isDescending
                ? Queryable.OrderByDescending(z => z.Name)
                : Queryable.OrderBy(z => z.Name),
            nameof(Zone.Tables.Count) => isDescending
                ? Queryable.OrderByDescending(z => z.Tables.Count)
                : Queryable.OrderBy(z => z.Tables.Count),
            _ => Queryable
        };
        return this;
    }
}