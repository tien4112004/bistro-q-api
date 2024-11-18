using System.Net;

namespace BistroQ.Core.Exceptions;

public class ConflictException : CustomException
{
    public ConflictException(string message) : base(message)
    {
    }

    public override int GetHttpStatusCode()
    {
        return (int)HttpStatusCode.Conflict;
    }
}