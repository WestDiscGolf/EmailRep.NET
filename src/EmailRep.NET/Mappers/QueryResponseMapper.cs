using System.Threading.Tasks;
using EmailRep.NET.Internal;

namespace EmailRep.NET.Mappers
{
    /// <summary>
    /// QueryResponseMapper class
    /// </summary>
    internal class QueryResponseMapper
    {
        /// <summary>
        /// Maps the internal QueryResponse to the external, library owned, model classes.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<Models.QueryResponse> MapAsync(QueryResponse source)
        {
            var target = new Models.QueryResponse
            {
                Email = source.Email,
                Reputation = await ProfileReputationMapper.MapAsync(source.Reputation),
                Suspicious = source.Suspicious,
                References = source.References
            };
            target.Details.Blacklisted = source.Details.Blacklisted;
            target.Details.MaliciousActivity = source.Details.MaliciousActivity;
            target.Details.MaliciousActivityRecent = source.Details.MaliciousActivityRecent;
            target.Details.CredentialsLeaked = source.Details.CredentialsLeaked;
            target.Details.CredentialsLeakedRecent = source.Details.CredentialsLeakedRecent;
            target.Details.DataBreach = source.Details.DataBreach;
            target.Details.FirstSeen = await DateMapper.MapAsync(source.Details.FirstSeen);
            target.Details.LastSeen  = await DateMapper.MapAsync(source.Details.LastSeen);
            target.Details.DomainExists = source.Details.DomainExists;
            target.Details.DomainReputation = await DomainReputationMapper.MapAsync(source.Details.DomainReputation);
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
            target.Details.Profiles = await OnlineProfileMapper.MapAsync(source.Details.Profiles);

            return target;
        }
    }
}