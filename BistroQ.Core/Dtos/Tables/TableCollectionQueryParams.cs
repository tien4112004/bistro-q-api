namespace BistroQ.Core.Dtos.Tables;

public class TableCollectionQueryParams : BaseCollectionQueryParams
{
    public int? ZoneId { get; set; }

    public int? Number { get; set; }

    public int? SeatsCount { get; set; }

    public string? ZoneName { get; set; }    
}