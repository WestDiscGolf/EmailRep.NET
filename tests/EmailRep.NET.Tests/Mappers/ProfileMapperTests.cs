using System.Collections.Generic;
using System.Threading.Tasks;
using EmailRep.NET.Mappers;
using EmailRep.NET.Models;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests.Mappers
{
    public class ProfileMapperTests
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
        public async Task Map(string source, Profile expected)
        {
            // Arrange

            // Act
            var result = await ProfileMapper.MapAsync(new List<string>{ source });

            // Assert
            result.Count.Should().Be(1);
            result[0].Should().Be(expected);
        }
    }
}
