using System.Net;

namespace BistroQ.Core.Exceptions;

public static class ExceptionExtensions
{
    public static int GetHttpStatusCode(this Exception ex)
    {
        if (ex is CustomException customException)
        {
            return customException.GetHttpStatusCode();
        }

        return (int)HttpStatusCode.InternalServerError;
    }
}