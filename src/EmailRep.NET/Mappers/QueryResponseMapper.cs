using System.Threading.Tasks;
using EmailRep.NET.Internal;

namespace EmailRep.NET.Mappers
{
    internal class QueryResponseMapper
    {
        public static async Task<Models.QueryResponse> MapAsync(QueryResponse source)
        {
            // todo: blog post; "Why have 2 pocos and write the mapping myself?"
            // -> abstraction between their API surface and data model so either can change and not effect the other
            // -> Map self as don't want to be reliant on an external library which would be throwing the kitchen sink at a specific problem
            // -> expose dates as dates and not magic strings

            // todo: blog post; "why async all the things?"
            // -> consistency across the api surface
            // -> 

            var target = new Models.QueryResponse();
            target.Email = source.Email;

            // todo: enum mapping
            target.Reputation = source.Reputation;
            target.Suspicious = source.Suspicious;
            target.References = source.References;

            target.Details.Blacklisted = source.Details.Blacklisted;
            target.Details.MaliciousActivity = source.Details.MaliciousActivity;
            target.Details.MaliciousActivityRecent = source.Details.MaliciousActivityRecent;
            target.Details.CredentialsLeaked = source.Details.CredentialsLeaked;
            target.Details.CredentialsLeakedRecent = source.Details.CredentialsLeakedRecent;
            target.Details.DataBreach = source.Details.DataBreach;

            // todo: change to datetime offset and map
            target.Details.FirstSeen = source.Details.FirstSeen;
            target.Details.LastSeen  = source.Details.LastSeen;

            target.Details.DomainExists = source.Details.DomainExists;
            target.Details.DomainReputation = source.Details.DomainReputation;
            target.Details.NewDomain = source.Details.NewDomain;
            target.Details.DaysSinceDomainCreation = source.Details.DaysSinceDomainCreation;

            target.Details.SuspiciousTld = source.Details.SuspiciousTld;
            target.Details.Spam = source.Details.Spam;
            target.Details.FreeProvider = source.Details.FreeProvider;
            target.Details.Disposable = source.Details.Disposable;
            target.Details.Deliverable = source.Details.Deliverable;
            target.Details.AcceptAll = source.Details.AcceptAll;
            target.Details.ValidMx = source.Details.ValidMx;
            target.Details.Spoofable = source.Details.Spoofable;
            target.Details.SpfStrict = source.Details.SpfStrict;
            target.Details.DmarcEnforced = source.Details.DmarcEnforced;

            target.Details.Profiles = await ProfileMapper.MapAsync(source.Details.Profiles);

            return target;
        }
    }
}