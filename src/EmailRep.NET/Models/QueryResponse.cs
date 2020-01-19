using J = System.Text.Json.Serialization.JsonPropertyNameAttribute;

namespace EmailRep.NET.Models
{
    public class QueryResponse
    {
        [J("email")]
        public string Email { get; set; }

        [J("reputation")]
        public Reputation Reputation { get; set; }

        [J("suspicious")]
        public bool Suspicious { get; set; }

        [J("references")]
        public long References { get; set; }

        [J("details")]
        public QueryResponseDetails Details { get; set; } = new QueryResponseDetails();
    }
}
