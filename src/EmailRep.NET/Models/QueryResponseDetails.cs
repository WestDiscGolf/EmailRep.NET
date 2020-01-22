using System;
using System.Collections.Generic;
using J = System.Text.Json.Serialization.JsonPropertyNameAttribute;

namespace EmailRep.NET.Models
{
    /// <summary>
    /// Further response details
    /// </summary>
    public class QueryResponseDetails
    {
        /// <summary>
        /// The email is believed to be malicious or spammy
        /// </summary>
        [J("blacklisted")]
        public bool Blacklisted { get; set; }

        /// <summary>
        /// The email has exhibited malicious behavior (e.g. phishing or fraud)
        /// </summary>
        [J("malicious_activity")]
        public bool MaliciousActivity { get; set; }

        /// <summary>
        /// Malicious behavior in the last 90 days (e.g. in the case of temporal account takeovers)
        /// </summary>
        [J("malicious_activity_recent")]
        public bool MaliciousActivityRecent { get; set; }

        /// <summary>
        /// Credentials were leaked at some point in time (e.g. a data breach, pastebin, dark web, etc.)
        /// </summary>
        [J("credentials_leaked")]
        public bool CredentialsLeaked { get; set; }

        /// <summary>
        /// Credentials were leaked in the last 90 days
        /// </summary>
        [J("credentials_leaked_recent")]
        public bool CredentialsLeakedRecent { get; set; }

        /// <summary>
        /// The email was in a data breach at some point in time
        /// </summary>
        [J("data_breach")]
        public bool DataBreach { get; set; }

        /// <summary>
        /// The first date the email was observed in a breach, credential leak, or exhibiting malicious or spammy behavior (if never seen DateTimeOffSet.MinValue)
        /// </summary>
        [J("first_seen")]
        public DateTimeOffset FirstSeen { get; set; } = DateTimeOffset.MinValue;

        /// <summary>
        /// The last date the email was observed in a breach, credential leak, or exhibiting malicious or spammy behavior (if never seen DateTimeOffSet.MinValue)
        /// </summary>
        [J("last_seen")]
        public DateTimeOffset LastSeen { get; set; } = DateTimeOffset.MinValue;

        /// <summary>
        /// Valid domain
        /// </summary>
        [J("domain_exists")]
        public bool DomainExists { get; set; }

        /// <summary>
        /// Reputation of the domain itself. NoneApplicable if free provider, disposable or doesn't exist.
        /// </summary>
        [J("domain_reputation")]
        public DomainReputation DomainReputation { get; set; }

        /// <summary>
        /// The domain was created within the last year
        /// </summary>
        [J("new_domain")]
        public bool NewDomain { get; set; }

        /// <summary>
        /// Days since the domain was created
        /// </summary>
        [J("days_since_domain_creation")]
        public long DaysSinceDomainCreation { get; set; }

        /// <summary>
        /// Suspicious tld
        /// </summary>
        [J("suspicious_tld")]
        public bool SuspiciousTld { get; set; }

        /// <summary>
        /// The email has exhibited spammy behavior (e.g. spam traps, login form abuse)
        /// </summary>
        [J("spam")]
        public bool Spam { get; set; }

        /// <summary>
        /// The email uses a free email provider
        /// </summary>
        [J("free_provider")]
        public bool FreeProvider { get; set; }

        /// <summary>
        /// The email uses a temporary/disposable service
        /// </summary>
        [J("disposable")]
        public bool Disposable { get; set; }

        /// <summary>
        /// Deliverable
        /// </summary>
        [J("deliverable")]
        public bool Deliverable { get; set; }

        /// <summary>
        /// Whether the mail server has a default accept all policy
        /// </summary>
        [J("accept_all")]
        public bool AcceptAll { get; set; }

        /// <summary>
        /// Has an MX record
        /// </summary>
        [J("valid_mx")]
        public bool ValidMx { get; set; }

        /// <summary>
        /// Email address can be spoofed (e.g. not a strict SPF policy or DMARC is not enforced)
        /// </summary>
        [J("spoofable")]
        public bool Spoofable { get; set; }

        /// <summary>
        /// Sufficiently strict SPF record to prevent spoofing
        /// </summary>
        [J("spf_strict")]
        public bool SpfStrict { get; set; }

        /// <summary>
        /// DMARC is configured correctly and enforced
        /// </summary>
        [J("dmarc_enforced")]
        public bool DmarcEnforced { get; set; }

        /// <summary>
        /// Online profiles used by the email
        /// </summary>
        [J("profiles")]
        public List<OnlineProfile> Profiles { get; set; }
    }
}
