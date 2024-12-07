using System.ComponentModel;

namespace BistroQ.Core.Enums;

public enum OrderItemStatus
{
    [Description("Pending")]
    Pending,
    
    [Description("In Progress")]
    InProgress,
    
    [Description("Completed")]
    Completed,
    
    [Description("Cancelled")]
    Cancelled
}