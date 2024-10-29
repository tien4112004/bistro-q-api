using System.Net;

namespace BistroQ.Core.Exceptions;

public class ForbiddenException : CustomException
{
    public ForbiddenException(string message) : base(message)
    {
    }

    public override int GetHttpStatusCode()
    {
        return (int)HttpStatusCode.Forbidden;
    }
}