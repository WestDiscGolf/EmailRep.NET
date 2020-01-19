using J = System.Text.Json.Serialization.JsonPropertyNameAttribute;

namespace EmailRep.NET.Internal
{
    /// <summary>
    /// Error Response POCO returned from emailrep.io on error.
    /// </summary>
    internal class ErrorResponse
    {
        /// <summary>
        /// Default: "fail". The returned HttpStatusCode is used to determine type of failure.
        /// </summary>
        [J("status")]
        public string Status { get; set; }

        /// <summary>
        /// Reason message for the failure.
        /// </summary>
        [J("reason")]
        public string Reason { get; set; }
    }
}
