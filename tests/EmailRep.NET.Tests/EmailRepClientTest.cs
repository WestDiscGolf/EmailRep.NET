using System;
using System.Linq;
using System.Threading.Tasks;
using EmailRep.NET.Models;
using FluentAssertions;
using JustEat.HttpClientInterception;
using Xunit;

namespace EmailRep.NET.Tests
{
    public class EmailRepClientTest
    {
        [Fact]
        public async Task ClientSetWithDefaults()
        {
            // Arrange
            var options = new HttpClientInterceptorOptions().RegisterBundle("emailrep.client.bundle.json");

            var client = options.CreateHttpClient();
            var sut = new EmailRepClient(client);

            // Act
            await sut.QueryEmailAsync("bill@microsoft.com");

            // Assert
            client.BaseAddress.Should().Be(new Uri("https://emailrep.io/"));
            client.DefaultRequestHeaders.UserAgent.Should().NotBeNull();
            client.DefaultRequestHeaders.TryGetValues("User-Agent", out var values).Should().BeTrue();
            values.FirstOrDefault().Should().Be(EmailRepClientSettings.Default.UserAgent);
            client.DefaultRequestHeaders.TryGetValues("Key", out _).Should().BeFalse();
        }

        [Theory, InlineAutoMoqData]
        public async Task ClientSetWithApiKey(string apiKey)
        {
            // Arrange
            var options = new HttpClientInterceptorOptions().RegisterBundle("emailrep.client.bundle.json");

            var client = options.CreateHttpClient();
            var settings = EmailRepClientSettings.Default;
            settings.ApiKey = apiKey;
            
            var sut = new EmailRepClient(client, settings);

            // Act
            await sut.QueryEmailAsync("bill@microsoft.com");

            // Assert
            client.DefaultRequestHeaders.TryGetValues("Key", out var key).Should().BeTrue();
            key.FirstOrDefault().Should().Be(apiKey);
        }

        [Fact]
        public async Task QueryEmailAsync_Mapping()
        {
            // Arrange
            var options = new HttpClientInterceptorOptions().RegisterBundle("emailrep.client.bundle.json");

            var client = options.CreateHttpClient();
            var sut = new EmailRepClient(client);

            // Act
            var response = await sut.QueryEmailAsync("bill@microsoft.com");

            // Assert
            response.Should().NotBeNull();
            response.Email.Should().Be("bill@microsoft.com");
            response.Reputation.Should().Be(ProfileReputation.High);
            response.Suspicious.Should().BeFalse();
            response.References.Should().Be(59);
            response.Details.Should().NotBeNull();

            var d = response.Details;
            d.Blacklisted.Should().BeFalse();
            d.MaliciousActivity.Should().BeFalse();
            d.MaliciousActivityRecent.Should().BeFalse();
            d.CredentialsLeaked.Should().BeTrue();
            d.CredentialsLeakedRecent.Should().BeFalse();
            d.DataBreach.Should().BeTrue();
            d.FirstSeen.Year.Should().Be(2008);
            d.FirstSeen.Month.Should().Be(7);
            d.FirstSeen.Day.Should().Be(1);
            d.LastSeen.Year.Should().Be(2019);
            d.LastSeen.Month.Should().Be(2);
            d.LastSeen.Day.Should().Be(25);
            d.DomainExists.Should().BeTrue();
            d.DomainReputation.Should().Be(DomainReputation.High);
            d.NewDomain.Should().BeFalse();
            d.DaysSinceDomainCreation.Should().Be(10289);
            d.SuspiciousTld.Should().BeFalse();
            d.Spam.Should().BeFalse();
            d.FreeProvider.Should().BeFalse();
            d.Disposable.Should().BeFalse();
            d.Deliverable.Should().BeTrue();
            d.AcceptAll.Should().BeTrue();
            d.ValidMx.Should().BeTrue();
            d.Spoofable.Should().BeFalse();
            d.SpfStrict.Should().BeTrue();
            d.DmarcEnforced.Should().BeTrue();

            var profiles = d.Profiles;
            profiles.Should().Contain(new[]
            {
                OnlineProfile.Spotify, 
                OnlineProfile.LinkedIn, 
                OnlineProfile.MySpace, 
                OnlineProfile.Instagram,
                OnlineProfile.Twitter,
                OnlineProfile.Flickr,
                OnlineProfile.Vimeo, 
                OnlineProfile.Angellist,
                OnlineProfile.Pinterest
            });
        }
    }
}
