using System;
using System.Collections.Generic;
using J = System.Text.Json.Serialization.JsonPropertyNameAttribute;

namespace EmailRep.NET.Models
{
    public class QueryResponseDetails
    {
        [J("blacklisted")]
        public bool Blacklisted { get; set; }

        [J("malicious_activity")]
        public bool MaliciousActivity { get; set; }

        [J("malicious_activity_recent")]
        public bool MaliciousActivityRecent { get; set; }

        [J("credentials_leaked")]
        public bool CredentialsLeaked { get; set; }

        [J("credentials_leaked_recent")]
        public bool CredentialsLeakedRecent { get; set; }

        [J("data_breach")]
        public bool DataBreach { get; set; }

        [J("first_seen")]
        public DateTimeOffset FirstSeen { get; set; }

        [J("last_seen")]
        public DateTimeOffset LastSeen { get; set; }

        [J("domain_exists")]
        public bool DomainExists { get; set; }

        [J("domain_reputation")]
        public string DomainReputation { get; set; }

        [J("new_domain")]
        public bool NewDomain { get; set; }

        [J("days_since_domain_creation")]
        public long DaysSinceDomainCreation { get; set; }

        [J("suspicious_tld")]
        public bool SuspiciousTld { get; set; }

        [J("spam")]
        public bool Spam { get; set; }

        [J("free_provider")]
        public bool FreeProvider { get; set; }

        [J("disposable")]
        public bool Disposable { get; set; }

        [J("deliverable")]
        public bool Deliverable { get; set; }

        [J("accept_all")]
        public bool AcceptAll { get; set; }

        [J("valid_mx")]
        public bool ValidMx { get; set; }

        [J("spoofable")]
        public bool Spoofable { get; set; }

        [J("spf_strict")]
        public bool SpfStrict { get; set; }

        [J("dmarc_enforced")]
        public bool DmarcEnforced { get; set; }

        [J("profiles")]
        public List<Profile> Profiles { get; set; }
    }
}
