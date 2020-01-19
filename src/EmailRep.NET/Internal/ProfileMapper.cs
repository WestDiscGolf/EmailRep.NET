using System.Collections.Generic;
using System.Threading.Tasks;
using EmailRep.NET.Models;

namespace EmailRep.NET.Internal
{
    internal class ProfileMapper
    {
        public static Task<List<Profile>> MapAsync(List<string> source)
        {
            return Task.FromResult(new List<Profile>());
        }
    }
}