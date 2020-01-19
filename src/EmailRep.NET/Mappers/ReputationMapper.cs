using System.Collections.Generic;
using System.Threading.Tasks;
using EmailRep.NET.Models;

namespace EmailRep.NET.Mappers
{
    internal class ReputationMapper
    {
        public static Task<Reputation> MapAsync(string source)
        {
            return Task.FromResult(Lookup.TryGetValue(source, out var reputation) ? reputation : Reputation.None);
        }

        private static readonly Dictionary<string, Reputation> Lookup = new Dictionary<string, Reputation>
        {
            {"none", Reputation.None},
            {"low", Reputation.Low},
            {"medium", Reputation.Medium},
            {"high", Reputation.High},
        };
    }
}
