using System.Collections.Generic;
using System.Threading.Tasks;
using EmailRep.NET.Internal;
using EmailRep.NET.Models;
using FluentAssertions;
using Xunit;

namespace EmailRep.NET.Tests.Mappers
{
    public class QueryResponseMapperTest
    {
        [Fact]
        public async Task QueryResponse_SuccessMap()
        {
            // Arrange
            var input = new NET.Internal.QueryResponse();
            input.Email = "bill@microsoft.com";
            input.Reputation = "high";
            input.Suspicious = false;
            input.References = 59;
            input.Details = new Details
            {
                Blacklisted = false,
                MaliciousActivity = false,
                MaliciousActivityRecent = false,
                CredentialsLeaked = true,
                CredentialsLeakedRecent = false,
                DataBreach = true,
                FirstSeen = "07/01/2008",
                LastSeen = "02/25/2019",
                DomainExists = true,
                DomainReputation = "high",
                NewDomain = false,
                DaysSinceDomainCreation = 10289,
                SuspiciousTld = false,
                Spam = false,
                FreeProvider = false,
                Disposable = false,
                Deliverable = true,
                AcceptAll = true,
                ValidMx = true,
                Spoofable = false,
                SpfStrict = true,
                DmarcEnforced = true,
                Profiles = new List<string> { "spotify", "linkedin", "myspace", "instagram", "twitter", "flickr", "vimeo", "angellist", "pinterest"}
            };

            // Act
            var response = await NET.Mappers.QueryResponseMapper.MapAsync(input);

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