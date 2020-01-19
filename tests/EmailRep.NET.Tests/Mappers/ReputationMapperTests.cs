using System.Threading.Tasks;
using EmailRep.NET.Mappers;
using EmailRep.NET.Models;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests.Mappers
{
    public class ReputationMapperTests
    {
        [Theory]
        [InlineData("", Reputation.None)]
        [InlineData("none", Reputation.None)]
        [InlineData("low", Reputation.Low)]
        [InlineData("medium", Reputation.Medium)]
        [InlineData("high", Reputation.High)]
        public async Task Map(string source, Reputation expected)
        {
            // Arrange

            // Act
            var result = await ReputationMapper.MapAsync(source);

            // Assert
            result.Should().Be(expected);
        }
    }
}
