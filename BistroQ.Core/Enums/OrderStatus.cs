using System.ComponentModel;

namespace BistroQ.Core.Enums;

public enum OrderStatus
{
    [Description("In Progress")]
    InProgress,

    [Description("Pending")]
    Pending,
    
    [Description("Completed")] 
    Completed,
}