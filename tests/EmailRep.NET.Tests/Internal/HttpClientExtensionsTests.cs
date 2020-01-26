using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using EmailRep.NET.Internal;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests.Internal
{
    public class HttpClientExtensionsTests
    {
        [Fact]
        public void Validate_BaseAddressNotSet_ThrowsException()
        {
            // Arrange
            HttpClient client = new HttpClient { BaseAddress = null };

            // Act
            Action result = () => client.Validate();

            // Assert
            result.Should().Throw<EmailRepConfigurationException>()
                .And.Message.Should().Contain("'BaseAddress' can not be empty. Please check your configuration.");
        }

        [Theory]
        [InlineAutoMoqData]
        public void Validate_UserAgentNotSet_ThrowsException(HttpClient client)
        {
            // Arrange

            // Act
            Action result = () => client.Validate();

            // Assert
            result.Should().Throw<EmailRepConfigurationException>()
                .And.Message.Should().Contain("'User-Agent' Header can not be empty. Please check your configuration.");
        }

        [Theory]
        [InlineAutoMoqData]
        public void Validate_HappyPath(EmailRepClientSettings settings, HttpClient client)
        {
            // Arrange
            client.SetUserAgent(settings);

            // Act
            Action result = () => client.Validate();

            // Assert
            result.Should().NotThrow<EmailRepConfigurationException>();
        }

        [Theory]
        [InlineAutoMoqData(null, false)]
        [InlineAutoMoqData("", false)]
        [InlineAutoMoqData("apiKey", true)]
        public void IsApiHeaderConfigured(string headerValue, bool expected, HttpClient sut)
        {
            // Arrange
            sut.DefaultRequestHeaders.Add("Key", headerValue);

            // Act
            var result = sut.IsApiHeaderConfigured();

            // Assert
            result.Should().Be(expected);
        }

        [Theory, InlineAutoMoqData]
        public void IsApiHeaderConfigured_Empty(HttpClient sut)
        {
            // Arrange
            
            // Act
            var result = sut.IsApiHeaderConfigured();

            // Assert
            result.Should().BeFalse();
        }

        [Theory, InlineAutoMoqData]
        public void SetupApiHeader_HeaderValueWins(string headerValue, EmailRepClientSettings settings, HttpClient sut)
        {
            // Arrange
            sut.DefaultRequestHeaders.Add("Key", headerValue);

            // Act
            sut.SetApiHeader(settings);

            // Assert
            var values = sut.DefaultRequestHeaders.GetValues("Key");
            values.Count().Should().Be(1);
            values.FirstOrDefault().Should().Be(headerValue);
        }

        [Theory, InlineAutoMoqData]
        public void SetupApiHeader_SettingsValueWins(EmailRepClientSettings settings, HttpClient sut)
        {
            // Arrange
            
            // Act
            sut.SetApiHeader(settings);

            // Assert
            var values = sut.DefaultRequestHeaders.GetValues("Key");
            values.Count().Should().Be(1);
            values.FirstOrDefault().Should().Be(settings.ApiKey);
        }

        [Theory, InlineAutoMoqData]
        public void SetupApiHeader_NotSet(HttpClient sut)
        {
            // Arrange

            // Act
            sut.SetApiHeader(null);

            // Assert
            sut.DefaultRequestHeaders.TryGetValues("Key", out _).Should().BeFalse();
        }

        [Theory, InlineAutoMoqData]
        public void SetupApiHeader_NotSet_NoApiKeySpecified(HttpClient sut)
        {
            // Arrange
            var settings = new EmailRepClientSettings();

            // Act
            sut.SetApiHeader(settings);

            // Assert
            sut.DefaultRequestHeaders.TryGetValues("Key", out _).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(BaseAddressData))]
        public void IsBaseAddressConfigured(Uri baseAddress, bool expected)
        {
            // Arrange
            HttpClient sut = new HttpClient();
            sut.BaseAddress = baseAddress;

            // Act
            var result = sut.IsBaseAddressConfigured();

            // Assert
            result.Should().Be(expected);
        }

        public static IEnumerable<object[]> BaseAddressData()
        {
            yield return new object[] { null, false };
            yield return new object[] { new Uri("https://emailrep.io/"), true };
        }

        [Theory, InlineAutoMoqData]
        public void SetBaseAddress(EmailRepClientSettings settings, HttpClient sut)
        {
            // Arrange
            sut.BaseAddress = new Uri("https://localhost/");

            // Act
            sut.SetBaseAddress(settings);

            // Assert
            sut.BaseAddress.Host.Should().Be("localhost");
        }

        [Theory, InlineAutoMoqData]
        public void SetBaseAddress_FromSettings(EmailRepClientSettings settings, HttpClient sut)
        {
            // Arrange
            sut.BaseAddress = null;
            settings.BaseUrl = "https://example.com/";

            // Act
            sut.SetBaseAddress(settings);

            // Assert
            sut.BaseAddress.Host.Should().Be("example.com");
        }

        [Theory, InlineAutoMoqData]
        public void SetBaseAddress_NotSet(EmailRepClientSettings settings, HttpClient sut)
        {
            // Arrange
            sut.BaseAddress = null;
            settings.BaseUrl = null;

            // Act
            sut.SetBaseAddress(settings);

            // Assert
            sut.BaseAddress.Should().BeNull();
        }

        [Theory]
        [MemberData(nameof(UserAgentData))]
        public void IsUserAgentConfigured(string userAgent, bool expected)
        {
            // Arrange
            HttpClient sut = new HttpClient();
            sut.DefaultRequestHeaders.UserAgent.TryParseAdd(userAgent);

            // Act
            var result = sut.IsUserAgentConfigured();

            // Assert
            result.Should().Be(expected);
        }

        public static IEnumerable<object[]> UserAgentData()
        {
            yield return new object[] { "", false };
            yield return new object[] { "test/agent", true };
        }

        [Theory, InlineAutoMoqData]
        public void SetupUserAgent_HeaderValueWins(string headerValue, EmailRepClientSettings settings, HttpClient sut)
        {
            // Arrange
            sut.DefaultRequestHeaders.Add("User-Agent", headerValue);

            // Act
            sut.SetUserAgent(settings);

            // Assert
            var values = sut.DefaultRequestHeaders.UserAgent;
            values.Count().Should().Be(1);
            values.FirstOrDefault().Product.Name.Should().Be(headerValue);
        }

        [Theory, InlineAutoMoqData]
        public void SetupUserAgent_SettingsValueWins(EmailRepClientSettings settings, HttpClient sut)
        {
            // Arrange
            settings.UserAgent = "settings-useragent";
            sut.DefaultRequestHeaders.Remove("User-Agent");

            // Act
            sut.SetUserAgent(settings);

            // Assert
            var values = sut.DefaultRequestHeaders.UserAgent;
            values.Count().Should().Be(1);
            values.FirstOrDefault().Product.Name.Should().Be(settings.UserAgent);
        }
    }
}
