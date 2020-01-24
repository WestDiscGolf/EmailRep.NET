using System.Collections.Generic;
using System.Threading.Tasks;
using EmailRep.NET.Models;

namespace EmailRep.NET.Mappers
{
    internal class DomainReputationMapper
    {
        public static Task<DomainReputation> MapAsync(string source) => Task.FromResult(Lookup.TryGetValue(source, out var reputation) ? reputation : DomainReputation.None);

        private static readonly Dictionary<string, DomainReputation> Lookup = new Dictionary<string, DomainReputation>
        {
            {"none", DomainReputation.None},
            {"low", DomainReputation.Low},
            {"medium", DomainReputation.Medium},
            {"high", DomainReputation.High},
            {"n/a", DomainReputation.NoneApplicable},
        };
    }
}