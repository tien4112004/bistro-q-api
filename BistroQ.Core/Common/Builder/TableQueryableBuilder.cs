using System.Numerics;
using AutoMapper.Configuration.Conventions;
using BistroQ.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Core.Common.Builder;

public class TableQueryableBuilder : BaseQueryableBuilder<Table>
{
    public TableQueryableBuilder(IQueryable<Table> queryable) : base(queryable)
    {
    }

    public TableQueryableBuilder WithZoneId(int? zoneId)
    {
        if (zoneId == null) return this;
        Queryable = Queryable.Where(z => z.ZoneId == zoneId);
        return this;
    }
    
    public TableQueryableBuilder WithSeatsCount(int? seatsCount)
    {
        if (seatsCount == null) return this;
        Queryable = Queryable.Where(z => z.SeatsCount > seatsCount);
        return this;
    }

    public TableQueryableBuilder WithZoneName(string? zoneName)
    {
        if (string.IsNullOrEmpty(zoneName)) return this;
        
        Queryable = Queryable.Where(z => z.Zone != null 
                                         && z.Zone.Name.ToUpper().Contains(zoneName.ToUpper()));        
        return this;
    }

    public TableQueryableBuilder ApplyPaging(int page, int size)
    {
        Queryable = Queryable.Skip((page - 1) * size).Take(size);
        return this;
    }
    
    public TableQueryableBuilder ApplySorting(string? orderBy, string? orderDirection)
    {
        var isDescending = orderDirection != "asc";
        Queryable = orderBy switch
        {
            nameof(Table.ZoneId) => isDescending
                ? Queryable.OrderByDescending(t => t.ZoneId)
                : Queryable.OrderBy(t => t.ZoneId),
            nameof(Table.Zone.Name) => isDescending
                ? Queryable.OrderByDescending(t => t.Zone != null ? t.Zone.Name : string.Empty)
                : Queryable.OrderBy(t => t.Zone != null ? t.Zone.Name : string.Empty),
            _ => Queryable
        };
        return this;
    }
}