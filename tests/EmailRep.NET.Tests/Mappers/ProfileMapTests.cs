using EmailRep.NET.Models;
using Xunit;

namespace EmailRep.NET.Tests.Mappers
{
    public class ProfileMapTests
    {
        [Theory]
        [InlineData("", Profile.None)]
        [InlineData("spotify", Profile.Spotify)]
        [InlineData("linkedin", Profile.LinkedIn)]
        [InlineData("myspace", Profile.MySpace)]
        [InlineData("instagram", Profile.Instagram)]
        [InlineData("twitter", Profile.Twitter)]
        [InlineData("flickr", Profile.Flickr)]
        [InlineData("vimeo", Profile.Vimeo)]
        [InlineData("angellist", Profile.Angellist)]
        [InlineData("pinterest", Profile.Pinterest)]
        public void Map(string source, Profile expected)
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
