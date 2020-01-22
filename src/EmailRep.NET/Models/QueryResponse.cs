using J = System.Text.Json.Serialization.JsonPropertyNameAttribute;

namespace EmailRep.NET.Models
{
    /// <summary>
    /// The query response poco which stores data mapped from the the emailrep.io response.
    /// </summary>
    public class QueryResponse
    {
        /// <summary>
        /// The queried email address.
        /// </summary>
        [J("email")]
        public string Email { get; set; }

        /// <summary>
        /// The profile reputation of the email address queried.
        /// </summary>
        [J("reputation")]
        public ProfileReputation Reputation { get; set; }

        /// <summary>
        /// Indicates if the email address should be treated as supicious.
        /// </summary>
        [J("suspicious")]
        public bool Suspicious { get; set; }

        /// <summary>
        /// The number of references of the email address queried.
        /// </summary>
        [J("references")]
        public long References { get; set; }

        /// <summary>
        /// Further details of the query response.
        /// </summary>
        [J("details")]
        public QueryResponseDetails Details { get; } = new QueryResponseDetails();
    }
}
