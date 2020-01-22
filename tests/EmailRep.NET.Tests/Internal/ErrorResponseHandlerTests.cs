using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EmailRep.NET.Internal;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests.Internal
{
    public class ErrorResponseHandlerTests
    {
        [Theory, InlineAutoMoqData]
        public async Task Success_NoThrow(HttpResponseMessage message)
        {
            // Arrange
            message.StatusCode = HttpStatusCode.OK;

            // Act
            Func<Task> result = () => ErrorResponseHandler.HandleResponse(message);

            // Assert
            result.Should().NotThrow<EmailRepResponseException>();
        }

        [Theory]
        [InlineAutoMoqData(HttpStatusCode.BadRequest,      "{\"status\": \"fail\", \"reason\": \"invalid email\"}",   ErrorCode.InvalidEmailAddress, "invalid email")]
        [InlineAutoMoqData(HttpStatusCode.Unauthorized,    "{\"status\": \"fail\", \"reason\": \"invalid api key\"}", ErrorCode.InvalidApiKey, "invalid api key")]
        [InlineAutoMoqData(HttpStatusCode.TooManyRequests, "{\"status\": \"fail\", \"reason\": \"exceeded daily limit. please wait 24 hrs or visit emailrep.io/key for an api key.\"}",
            ErrorCode.TooManyRequests, @"exceeded daily limit. please wait 24 hrs or visit emailrep.io/key for an api key.")]
        public async Task ExpectedStatusCodes_ThrowAsExpected(HttpStatusCode statusCode, string json, ErrorCode expectedCode, string expectedMessage, HttpResponseMessage message)
        {
            // Arrange
            message.StatusCode = statusCode;
            message.Content = new StringContent(json);

            // Act
            Func<Task> result = () => ErrorResponseHandler.HandleResponse(message);

            // Assert
            var exception = result.Should().ThrowExactly<EmailRepResponseException>().WithMessage(expectedMessage).Which;
            exception.ErrorCode.Should().Be(expectedCode);
            exception.OriginalCode.Should().Be(statusCode);
        }

        [Theory, InlineAutoMoqData]
        public async Task UnknownStatusCode_ThrowsGenericError(HttpResponseMessage message)
        {
            // Arrange
            message.StatusCode = HttpStatusCode.Conflict;

            // Act
            Func<Task> result = () => ErrorResponseHandler.HandleResponse(message);

            // Assert
            var exception = result.Should().ThrowExactly<EmailRepResponseException>().WithMessage("Unknown error occured.").Which;
            exception.ErrorCode.Should().Be(ErrorCode.Unknown);
            exception.OriginalCode.Should().Be(HttpStatusCode.Conflict);
        }
    }
}
