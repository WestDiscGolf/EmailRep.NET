using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmailRep.NET.Internal;
using QueryResponse = EmailRep.NET.Models.QueryResponse;

namespace EmailRep.NET
{
    /// <summary>
    /// Default implementation of the emailrep.io api
    /// </summary>
    public class EmailRepClient : IEmailRepClient
    {
        private readonly HttpClient _httpClient;
        private readonly EmailRepClientSettings _settings;

        private const string ApiKeyHeader = "Key";

        public EmailRepClient(HttpClient httpClient, EmailRepClientSettings settings = default)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _settings = settings ?? EmailRepClientSettings.Default;
            EmailRepClientSettingsValidator.Validate(_settings);
        }

        public async Task<QueryResponse> QueryEmailAsync(string emailAddress, CancellationToken cancellationToken = default)
        {
            // validate the email address
            _ = emailAddress.IsValidEmail() ?? throw new EmailRepException("Invalid email address. Email must be valid.");

            // setup the request details
            SetupRequest();

            var response = await _httpClient.GetAsync($"{emailAddress}", cancellationToken);

            // response.StatusCode = 429;
            // {"status": "fail", "reason": "exceeded daily limit. please wait 24 hrs or visit emailrep.io/key for an api key."}


            // todo: check response; raise exceptions
            // todo: map from internal to external
            var source = await response.Content.ReadAsAsync<Internal.QueryResponse>();

            
            // todo: push out the door

            return await QueryResponseMapper.MapAsync(source);
        }

        private void SetupRequest()
        {
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);

            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(_settings.UserAgent);

            if (!string.IsNullOrWhiteSpace(_settings.ApiKey))
            {
                _httpClient.DefaultRequestHeaders.Add(ApiKeyHeader, _settings.ApiKey);
            }
        }
    }

    public class EmailRepConfigurationException : Exception
    {
        public EmailRepConfigurationException(string message) : base(message)
        {
        }
    }

    // todo: need to determine the types of exception and status?
    public class EmailRepException : Exception
    {
        public EmailRepException(string message) : base(message)
        {
        }
    }
}
