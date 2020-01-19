﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EmailRep.NET.Internal;
using EmailRep.NET.Mappers;
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

            // make the request and handle the response if error returned
            var response = await _httpClient.GetAsync($"{emailAddress}", cancellationToken);
            await ErrorResponseHandler.HandleResponse(response);

            // if we've got here then we have a valid response and we can read and map accordingly
            var source = await response.Content.ReadAsAsync<Internal.QueryResponse>();
            
            // map and push out the door
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
}
