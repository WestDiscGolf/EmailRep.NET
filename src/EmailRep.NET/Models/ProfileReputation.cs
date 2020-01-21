using System.Text.Json.Serialization;

namespace EmailRep.NET.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProfileReputation
    {
        None = 0,
        High,
        Medium,
        Low,
    }
}