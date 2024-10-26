namespace BistroQ.Core.Dtos;

public class BaseCollectionQueryParams
{
    public int Page { get; set; } = 1;

    public int Size { get; set; } = 5;

    public string? OrderBy { get; set; }

    public string? OrderDirection { get; set; } = "asc";
}