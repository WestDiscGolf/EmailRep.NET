using System.Net;

namespace EmailRep.NET
{
    /// <summary>
    /// RequestError enum type
    /// </summary>
    public enum ErrorCode
    {
        Unknown,

        InvalidEmailAddress = HttpStatusCode.BadRequest, // 400

        InvalidApiKey = HttpStatusCode.Unauthorized, // 401

        TooManyRequests = HttpStatusCode.TooManyRequests // 429
    }
}