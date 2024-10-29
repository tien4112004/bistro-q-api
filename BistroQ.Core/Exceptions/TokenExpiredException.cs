using System.Net;

namespace BistroQ.Core.Exceptions;

public class TokenExpiredException : CustomException
{
    public TokenExpiredException(string message) : base(message)
    {
    }
    
    public override int GetHttpStatusCode()
    {
        return (int)HttpStatusCode.Unauthorized;
    }
}