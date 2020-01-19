using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmailRep.NET.Internal;
using EmailRep.NET.Models;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests
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

    public class DateMapperTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public async Task Map(string source, DateTimeOffset expected)
        {
            // Arrange

            // Act
            var result = await DateMapper.MapAsync(source);

            // Assert
            result.Should().Be(expected);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { "07/01/2008", new DateTimeOffset(2008, 07, 01, 0, 0, 0, TimeSpan.Zero) };
            yield return new object[] { "05/24/2019", new DateTimeOffset(2019, 05, 24, 0, 0, 0, TimeSpan.Zero) };
        }
    }

    public class InternalQueryResponseMapper
    {
        public async Task Map()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
