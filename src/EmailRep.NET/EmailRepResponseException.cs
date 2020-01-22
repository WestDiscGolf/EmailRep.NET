using System.Net;

namespace EmailRep.NET
{
    /// <summary>
    /// Email Rep Request Exception. This exception is raised on error from the api request. It will contain the error code and reason message.
    /// </summary>
    public class EmailRepResponseException : EmailRepException
    {
        /// <summary>
        /// Access to the specific type of error which has been caught.
        /// </summary>
        public ErrorCode ErrorCode { get; }

        /// <summary>
        /// Access the original http status code.
        /// </summary>
        public HttpStatusCode OriginalCode { get; }

        /// <summary>
        /// Constructor of a <see cref="EmailRepResponseException"/>. The <see cref="ErrorCode"/> and corresponding message are required.
        /// </summary>
        /// <param name="errorCode">Error request code.</param>
        /// <param name="originalCode">The original http status code.</param>
        /// <param name="message">Error request message.</param>
        public EmailRepResponseException(ErrorCode errorCode, HttpStatusCode originalCode, string message) : base(message)
        {
            ErrorCode = errorCode;
            OriginalCode = originalCode;
        }
    }
}