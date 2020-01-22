using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmailRep.NET.Internal
{
    /// <summary>
    /// The error response handler.
    /// </summary>
    internal class ErrorResponseHandler
    {
        /// <summary>
        /// Handles the response and deals with the error status codes; 400, 401, 429.
        /// </summary>
        /// <param name="message">The incoming <see cref="HttpResponseMessage"/>.</param>
        /// <returns>Task</returns>
        public static async Task HandleResponse(HttpResponseMessage message)
        {
            if (!message.IsSuccessStatusCode)
            {
                // errors to handle:
                // 400 - Badrequest ( invalid email )
                // 401 - Unauthorized ( invalid API key)
                // 429 - Too Many Requests

                // response.StatusCode = 400
                // {"status": "fail", "reason": "invalid email"}

                // response.StatusCode = 401
                // {"status": "fail", "reason": "invalid api key"}

                // response.StatusCode = 429;
                // {"status": "fail", "reason": "exceeded daily limit. please wait 24 hrs or visit emailrep.io/key for an api key."}

                ErrorCode errorCode = ErrorCode.Unknown;
                ErrorResponse errorResponse = null;

                switch (message.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        errorCode = ErrorCode.InvalidEmailAddress;
                        break;

                    case HttpStatusCode.Unauthorized:
                        errorCode = ErrorCode.InvalidApiKey;
                        break;

                    case HttpStatusCode.TooManyRequests:
                        errorCode = ErrorCode.TooManyRequests;
                        break;
                }

                if (errorCode != ErrorCode.Unknown)
                {
                    // ReSharper disable once PossibleNullReferenceException
                    errorResponse = await message.Content?.ReadAsAsync<ErrorResponse>();
                }

                throw new EmailRepResponseException(errorCode, message.StatusCode, errorResponse?.Reason ?? "Unknown error occured.");
            }
        }
    }
}
