using System;
using System.Net.Http;
using System.Threading.Tasks;
using EmailRep.NET.Internal;

namespace EmailRep.NET
{
    /// <summary>
    /// Default implementation of the emailrep.io api
    /// </summary>
    public class EmailRepClient : IEmailRepClient
    {
        private readonly HttpClient _httpClient;
        private readonly EmailRepClientSettings _settings;
        
        public EmailRepClient(HttpClient httpClient, EmailRepClientSettings settings = default)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _settings = settings ?? EmailRepClientSettings.Default;
            EmailRepClientSettingsValidator.Validate(_settings);
        }

        public async Task<QueryResponse> QueryEmailAsync(string emailAddress)
        {
            // validate the email address
            _ = emailAddress.IsValidEmail() ?? throw new EmailRepException("Invalid email address. Email must be valid.");

            // setup the request details
            SetupRequest();

            var response = await _httpClient.GetAsync($"/{emailAddress}");

            // todo: check response; raise exceptions
            // todo: map from internal to external
            // todo: push out the door

            return await response.Content.ReadAsAsync<QueryResponse>();
        }

        private void SetupRequest()
        {
            _httpClient.BaseAddress = new Uri(_settings.BaseUrl);

            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(_settings.UserAgent);
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
