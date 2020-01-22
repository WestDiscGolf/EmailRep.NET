using System;
using EmailRep.NET.Internal;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests.Internal
{
    public class EmailRepClientSettingsValidatorTests
    {
        [Fact]
        public void NullSettings_ThrowsException()
        {
            // Arrange
            
            // Act
            Action result = () => EmailRepClientSettingsValidator.Validate(null);

            // Assert
            result.Should().Throw<ArgumentNullException>()
                .And.Message.Should().Contain("EmailRepClientSettings can not be null. Please check your configuration.");
        }

        [Theory]
        [InlineAutoMoqData(null)]
        [InlineAutoMoqData("")]
        public void BaseUrlEmpty_ThrowsException(string baseUrl, EmailRepClientSettings settings)
        {
            // Arrange
            settings.BaseUrl = baseUrl;

            // Act
            Action result = () => EmailRepClientSettingsValidator.Validate(settings);

            // Assert
            result.Should().Throw<EmailRepConfigurationException>()
                .And.Message.Should().Contain($"BaseUrl can not be empty. Please check your configuration.");
        }

        [Theory]
        [InlineAutoMoqData(null)]
        [InlineAutoMoqData("")]
        public void UserAgentEmpty_ThrowsException(string userAgent, EmailRepClientSettings settings)
        {
            // Arrange
            settings.UserAgent = userAgent;

            // Act
            Action result = () => EmailRepClientSettingsValidator.Validate(settings);

            // Assert
            result.Should().Throw<EmailRepConfigurationException>()
                .And.Message.Should().Contain($"UserAgent can not be empty. Please check your configuration.");
        }
    }
}
