using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using JustEat.HttpClientInterception;
using Xunit;

namespace EmailRep.NET.Tests
{
    public class EmailRepClientTest
    {
        [Fact]
        public async Task Test()
        {
            // Arrange
            var builder = new HttpRequestInterceptionBuilder()
                .ForHost("emailrep.io")
                .ForPath("bill@microsoft.com")
                .ForHttps()
                .WithSystemTextJsonContent(new
                {
                    email = "bill@microsoft.com",
                    reputation = "high",
                    suspicious = false,
                    references = 79,
                });

            var options = new HttpClientInterceptorOptions { ThrowOnMissingRegistration = true }
                .Register(builder);


            var client = options.CreateHttpClient();
            var sut = new EmailRepClient(client);

            // Act
            var response = await sut.QueryEmailAsync("bill@microsoft.com");

            // Assert
            response.Should().NotBeNull();
            response.Email.Should().Be("bill@microsoft.com");
            response.Reputation.Should().Be("high");
        }
    }
}
