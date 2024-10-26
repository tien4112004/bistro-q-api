using System.Linq.Expressions;
using BistroQ.Core.Entities;

namespace BistroQ.Core.Specifications;

public class ProductSpecification
{
    public Expression<Func<Product, bool>> Filter { get;  set; }
    public string SortColumn { get;  set; }
    public bool IsDescending { get;  set; }
    public int Skip { get;  set; }
    public int Take { get;  set; }
    
}