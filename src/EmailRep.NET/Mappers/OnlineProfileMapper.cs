using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailRep.NET.Models;

namespace EmailRep.NET.Mappers
{
    /// <summary>
    /// Online Profile mapper
    /// </summary>
    internal class OnlineProfileMapper
    {
        /// <summary>
        /// Maps a list of <see cref="string"/> source values to a list of <see cref="OnlineProfile"/> values.
        /// </summary>
        /// <param name="source">The <see cref="List{String}"/> from the email rep api.</param>
        /// <returns>The list of mapped <see cref="OnlineProfile"/> values.</returns>
        public static Task<List<OnlineProfile>> MapAsync(List<string> source) => Task.FromResult(source.Select(Map).ToList());

        /// <summary>
        /// Map a single string source value to a corresponding <see cref="OnlineProfile"/> value.
        /// </summary>
        /// <param name="source">The string value from the email rep api.</param>
        /// <returns>The individual mapped <see cref="OnlineProfile"/> value.</returns>
        private static OnlineProfile Map(string source) => Lookup.TryGetValue(source, out var profile) ? profile : OnlineProfile.None;

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