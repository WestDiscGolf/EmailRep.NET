using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailRep.NET.Models;

namespace EmailRep.NET.Mappers
{
    /// <summary>
    /// Profile mapper
    /// </summary>
    internal class ProfileMapper
    {
        /// <summary>
        /// Maps a list of <see cref="string"/> source values to a list of <see cref="Profile"/> values.
        /// </summary>
        /// <param name="source">The <see cref="List{String}"/> from the email rep api.</param>
        /// <returns>The list of mapped <see cref="Profile"/> values.</returns>
        public static Task<List<Profile>> MapAsync(List<string> source)
        {
            return Task.FromResult(source.Select(Map).ToList());
        }

        private static Profile Map(string source)
        {
            // just use a simple look up for now. nothing fancy required.
            return Lookup.TryGetValue(source, out var profile) ? profile : Profile.None;
        }

        private static readonly Dictionary<string, Profile> Lookup = new Dictionary<string, Profile>
        {
            {"spotify", Profile.Spotify},
            {"myspace", Profile.MySpace},
            {"instagram", Profile.Instagram},
            {"twitter", Profile.Twitter},
            {"flickr", Profile.Flickr},
            {"vimeo", Profile.Vimeo},
            {"angellist", Profile.Angellist},
            {"pinterest", Profile.Pinterest},
            {"linkedin", Profile.LinkedIn }
        };
    }
}