using System.Text.Json.Serialization;

namespace EmailRep.NET.Models
{
    /// <summary>
    /// The domain reputation ranking
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DomainReputation
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// High
        /// </summary>
        High,

        /// <summary>
        /// Medium
        /// </summary>
        Medium,

        /// <summary>
        /// Low
        /// </summary>
        Low,

        /// <summary>
        /// None applicable
        /// </summary>
        NoneApplicable
    }
}