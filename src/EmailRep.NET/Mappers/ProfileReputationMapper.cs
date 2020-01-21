using System.Collections.Generic;
using System.Threading.Tasks;
using EmailRep.NET.Models;

namespace EmailRep.NET.Mappers
{
    internal class ProfileReputationMapper
    {
        public static Task<ProfileReputation> MapAsync(string source)
        {
            return Task.FromResult(Lookup.TryGetValue(source, out var reputation) ? reputation : ProfileReputation.None);
        }

        private static readonly Dictionary<string, ProfileReputation> Lookup = new Dictionary<string, ProfileReputation>
        {
            {"none", ProfileReputation.None},
            {"low", ProfileReputation.Low},
            {"medium", ProfileReputation.Medium},
            {"high", ProfileReputation.High},
        };
    }
}
