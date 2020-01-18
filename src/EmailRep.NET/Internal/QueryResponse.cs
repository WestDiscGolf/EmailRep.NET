using J = System.Text.Json.Serialization.JsonPropertyNameAttribute;

namespace EmailRep.NET.Internal
{
    public partial class QueryResponse
    {
        [J("email")]
        public string Email { get; set; }

        [J("reputation")]
        public string Reputation { get; set; }

        [J("suspicious")]
        public bool Suspicious { get; set; }

        [J("references")]
        public long References { get; set; }

        [J("details")]
        public Details Details { get; set; }
    }
}