using System.Net;

namespace BistroQ.Core.Exceptions;

public class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {
    }
    public virtual int GetHttpStatusCode()
    {
        return (int)HttpStatusCode.InternalServerError;
    }
}