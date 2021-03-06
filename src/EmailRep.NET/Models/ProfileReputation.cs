﻿using System.Text.Json.Serialization;

namespace EmailRep.NET.Models
{
    /// <summary>
    /// The profile reputation ranking
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProfileReputation
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
    }
}