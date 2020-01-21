using System.Threading.Tasks;
using EmailRep.NET.Mappers;
using EmailRep.NET.Models;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests.Mappers
{
    public class DomainReputationMapperTests
    {
        [Theory]
        [InlineData("", DomainReputation.None)]
        [InlineData("none", DomainReputation.None)]
        [InlineData("low", DomainReputation.Low)]
        [InlineData("medium", DomainReputation.Medium)]
        [InlineData("high", DomainReputation.High)]
        [InlineData("n/a", DomainReputation.NoneApplicable)]
        public async Task Map(string source, DomainReputation expected)
        {
            // Arrange

            // Act
            var result = await DomainReputationMapper.MapAsync(source);

            // Assert
            result.Should().Be(expected);
        }
    }
}