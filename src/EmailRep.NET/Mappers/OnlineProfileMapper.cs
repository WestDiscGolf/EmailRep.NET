using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailRep.NET.Models;

namespace EmailRep.NET.Mappers
{
    /// <summary>
    /// Profile mapper
    /// </summary>
    internal class OnlineProfileMapper
    {
        /// <summary>
        /// Maps a list of <see cref="string"/> source values to a list of <see cref="OnlineProfile"/> values.
        /// </summary>
        /// <param name="source">The <see cref="List{String}"/> from the email rep api.</param>
        /// <returns>The list of mapped <see cref="OnlineProfile"/> values.</returns>
        public static Task<List<OnlineProfile>> MapAsync(List<string> source)
        {
            return Task.FromResult(source.Select(Map).ToList());
        }

        private static OnlineProfile Map(string source)
        {
            // just use a simple look up for now. nothing fancy required.
            return Lookup.TryGetValue(source, out var profile) ? profile : OnlineProfile.None;
        }

        private static readonly Dictionary<string, OnlineProfile> Lookup = new Dictionary<string, OnlineProfile>
        {
            {"spotify", OnlineProfile.Spotify},
            {"myspace", OnlineProfile.MySpace},
            {"instagram", OnlineProfile.Instagram},
            {"twitter", OnlineProfile.Twitter},
            {"flickr", OnlineProfile.Flickr},
            {"vimeo", OnlineProfile.Vimeo},
            {"angellist", OnlineProfile.Angellist},
            {"pinterest", OnlineProfile.Pinterest},
            {"linkedin", OnlineProfile.LinkedIn }
        };
    }
}