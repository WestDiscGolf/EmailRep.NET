using System.Collections.Generic;
using System.Threading.Tasks;
using EmailRep.NET.Models;

namespace EmailRep.NET.Mappers
{
    /// <summary>
    /// Profile Reputation Mapper
    /// </summary>
    internal class ProfileReputationMapper
    {
        /// <summary>
        /// Map a single string source value to a corresponding <see cref="ProfileReputation"/> value.
        /// </summary>
        /// <param name="source">The string value from the email rep api.</param>
        /// <returns>The individual mapped <see cref="ProfileReputation"/> value.</returns>
        public static Task<ProfileReputation> MapAsync(string source) => Task.FromResult(Lookup.TryGetValue(source, out var reputation) ? reputation : ProfileReputation.None);

        private static readonly Dictionary<string, ProfileReputation> Lookup = new Dictionary<string, ProfileReputation>
        {
            {"none", ProfileReputation.None},
            {"low", ProfileReputation.Low},
            {"medium", ProfileReputation.Medium},
            {"high", ProfileReputation.High},
        };
    }
}
