using System.Threading.Tasks;
using EmailRep.NET.Mappers;
using EmailRep.NET.Models;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests.Mappers
{
    public class ProfileReputationMapperTests
    {
        [Theory]
        [InlineData("", ProfileReputation.None)]
        [InlineData("none", ProfileReputation.None)]
        [InlineData("low", ProfileReputation.Low)]
        [InlineData("medium", ProfileReputation.Medium)]
        [InlineData("high", ProfileReputation.High)]
        public async Task Map(string source, ProfileReputation expected)
        {
            // Arrange

            // Act
            var result = await ProfileReputationMapper.MapAsync(source);

            // Assert
            result.Should().Be(expected);
        }
    }
}
