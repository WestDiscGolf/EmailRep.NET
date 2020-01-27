﻿using System;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using JustEat.HttpClientInterception;
using Xunit;

namespace EmailRep.NET.Tests
{
    public class EmailRepClientTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void QueryEmailAsync_InvalidEmail_ThrowsException(string emailAddress)
        {
            // Arrange
            var settings = new EmailRepClientSettings();
            var options = new HttpClientInterceptorOptions().RegisterBundle("emailrep.client.bundle.json");

            var client = options.CreateHttpClient();
            var sut = new EmailRepClient(client, settings);

            // Act
            Func<Task> result = () => sut.QueryEmailAsync(emailAddress);

            // Assert
            result.Should().ThrowExactly<EmailRepException>().WithMessage("Invalid email address. Email must be valid.");
        }

        [Fact]
        public void QueryEmailAsync_InvalidEmail_ThrowsResponseException()
        {
            // Arrange
            var settings = new EmailRepClientSettings();
            var options = new HttpClientInterceptorOptions().RegisterBundle("emailrep.client.bundle.json");

            var client = options.CreateHttpClient();
            var sut = new EmailRepClient(client, settings);

            // Act
            Func<Task> result = () => sut.QueryEmailAsync("invalid@bob");

            // Assert
            result.Should().ThrowExactly<EmailRepResponseException>()
                .Where(
                    x => x.ErrorCode == ErrorCode.InvalidEmailAddress
                         && x.OriginalCode == HttpStatusCode.BadRequest)
                .WithMessage("invalid email");
        }

        [Fact]
        public void QueryEmailAsync_InvalidApiKey_ThrowsResponseException()
        {
            // Arrange
            var settings = new EmailRepClientSettings();
            var options = new HttpClientInterceptorOptions().RegisterBundle("emailrep.client.bundle.json");

            var client = options.CreateHttpClient();
            var sut = new EmailRepClient(client, settings);

            // Act
            Func<Task> result = () => sut.QueryEmailAsync("api@example.com");

            // Assert
            result.Should().ThrowExactly<EmailRepResponseException>()
                .Where(
                    x => x.ErrorCode == ErrorCode.InvalidApiKey
                         && x.OriginalCode == HttpStatusCode.Unauthorized)
                .WithMessage("invalid api key");
        }

        [Fact]
        public void QueryEmailAsync_DailyLimitHit_ThrowsResponseException()
        {
            // Arrange
            var settings = new EmailRepClientSettings();
            var options = new HttpClientInterceptorOptions().RegisterBundle("emailrep.client.bundle.json");

            var client = options.CreateHttpClient();
            var sut = new EmailRepClient(client, settings);

            // Act
            Func<Task> result = () => sut.QueryEmailAsync("limit@example.com");

            // Assert
            result.Should().ThrowExactly<EmailRepResponseException>()
                .Where(
                    x => x.ErrorCode == ErrorCode.TooManyRequests
                         && x.OriginalCode == HttpStatusCode.TooManyRequests)
                .WithMessage("exceeded daily limit. please wait 24 hrs or visit emailrep.io/key for an api key.");
        }

        [Theory]
        [InlineData(HttpStatusCode.BadGateway)]
        [InlineData(HttpStatusCode.Conflict)]
        // etc
        public void QueryEmailAsync_AnotherError_ThrowsResponseException(HttpStatusCode httpStatusCode)
        {
            // Arrange
            var builder = new HttpRequestInterceptionBuilder()
                .ForHost("emailrep.io")
                .ForPath("error@example.com")
                .ForHttps()
                .WithStatus(httpStatusCode);

            var options = new HttpClientInterceptorOptions { ThrowOnMissingRegistration = true }
                .Register(builder);

            var client = options.CreateHttpClient();
            var settings = new EmailRepClientSettings();

            var sut = new EmailRepClient(client, settings);

            // Act
            Func<Task> result = () => sut.QueryEmailAsync("error@example.com");

            // Assert
            result.Should().ThrowExactly<EmailRepResponseException>()
                .Where(x => x.ErrorCode == ErrorCode.Unknown
                            && x.OriginalCode == httpStatusCode)
                .WithMessage("Unknown error occured.");
        }

        [Fact]
        public async Task QueryEmailAsync_Success()
        {
            // Arrange
            var settings = new EmailRepClientSettings();
            var options = new HttpClientInterceptorOptions().RegisterBundle("emailrep.client.bundle.json");

            var client = options.CreateHttpClient();
            var sut = new EmailRepClient(client, settings);

            // Act
            var result = await sut.QueryEmailAsync("bill@microsoft.com");
            
            // Assert
            result.Should().NotBeNull();
            result.Email.Should().Be("bill@microsoft.com");
            // not checking the mapping code here, so not further processing to be checked.
        }
    }
}