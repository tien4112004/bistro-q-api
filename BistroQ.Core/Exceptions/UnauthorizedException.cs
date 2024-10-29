using System.Net;

namespace BistroQ.Core.Exceptions;

public class UnauthorizedException : CustomException
{
    public UnauthorizedException(string message) : base(message)
    {
    }

    public override int GetHttpStatusCode()
    {
        return (int)HttpStatusCode.Unauthorized;
    }
}