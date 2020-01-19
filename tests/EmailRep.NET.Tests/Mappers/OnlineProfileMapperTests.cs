using System.Collections.Generic;
using System.Threading.Tasks;
using EmailRep.NET.Mappers;
using EmailRep.NET.Models;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests.Mappers
{
    public class OnlineProfileMapperTests
    {
        [Theory]
        [InlineData("", OnlineProfile.None)]
        [InlineData("spotify", OnlineProfile.Spotify)]
        [InlineData("linkedin", OnlineProfile.LinkedIn)]
        [InlineData("myspace", OnlineProfile.MySpace)]
        [InlineData("instagram", OnlineProfile.Instagram)]
        [InlineData("twitter", OnlineProfile.Twitter)]
        [InlineData("flickr", OnlineProfile.Flickr)]
        [InlineData("vimeo", OnlineProfile.Vimeo)]
        [InlineData("angellist", OnlineProfile.Angellist)]
        [InlineData("pinterest", OnlineProfile.Pinterest)]
        public async Task Map(string source, OnlineProfile expected)
        {
            // Arrange

            // Act
            var result = await OnlineProfileMapper.MapAsync(new List<string>{ source });

            // Assert
            result.Count.Should().Be(1);
            result[0].Should().Be(expected);
        }
    }
}
