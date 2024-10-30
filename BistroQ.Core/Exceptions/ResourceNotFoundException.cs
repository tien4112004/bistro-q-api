using System.Net;

namespace BistroQ.Core.Exceptions;

public class ResourceNotFoundException : CustomException
{
    public ResourceNotFoundException(string message) : base(message)
    {
    }
    
    public override int GetHttpStatusCode()
    {
        return (int)HttpStatusCode.NotFound;
    }
}