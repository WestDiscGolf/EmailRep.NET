using System.Text.Json.Serialization;

namespace EmailRep.NET.Models
{
    /// <summary>
    /// The online profile on which the email address has been used on.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum OnlineProfile
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Angel list - the startups, angel investors and job-seekers one
        /// </summary>
        Angellist,

        /// <summary>
        /// Flickr - the images and videos one
        /// </summary>
        Flickr,

        /// <summary>
        /// Instagram - the pictures with filters one
        /// </summary>
        Instagram,

        /// <summary>
        /// LinkedIn - the professional network one
        /// </summary>
        LinkedIn,

        /// <summary>
        /// MySpace - the pics, videos, music, groups one
        /// </summary>
        MySpace,

        /// <summary>
        /// Pinterest - the picture board one
        /// </summary>
        Pinterest,

        /// <summary>
        /// Spotify - the music streaming one
        /// </summary>
        Spotify,

        /// <summary>
        /// Twitter - the tweeting based one
        /// </summary>
        Twitter,

        /// <summary>
        /// Vimeo - the video one
        /// </summary>
        Vimeo,
    }
}