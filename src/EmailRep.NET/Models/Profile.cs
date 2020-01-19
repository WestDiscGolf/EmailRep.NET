using System.Text.Json.Serialization;

namespace EmailRep.NET.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum Profile
    {
        None = 0,
        Angellist,
        Flickr,
        Instagram,
        LinkedIn,
        MySpace,
        Pinterest,
        Spotify,
        Twitter,
        Vimeo,
    }
}