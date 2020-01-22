using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmailRep.NET.Mappers;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests.Mappers
{
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
            result.Year.Should().Be(expected.Year);
            result.Month.Should().Be(expected.Month);
            result.Day.Should().Be(expected.Day);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { "07/01/2008", new DateTimeOffset(2008, 07, 01, 0, 0, 0, TimeSpan.Zero) };
            yield return new object[] { "05/24/2019", new DateTimeOffset(2019, 05, 24, 0, 0, 0, TimeSpan.Zero) };
            yield return new object[] { "never", DateTimeOffset.MinValue};
        }
    }
}