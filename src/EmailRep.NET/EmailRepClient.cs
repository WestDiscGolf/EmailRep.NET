using System;
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
        
        /// <summary>
        /// Default constructor to create a new <see cref="EmailRepClient"/>.
        /// </summary>
        /// <param name="httpClient">A <see cref="HttpClient"/> instance. This can be provided manually or through dependency injection.</param>
        /// <param name="settings">An instance of the settings is .</param>
        public EmailRepClient(HttpClient httpClient, EmailRepClientSettings settings = default)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            // make sure the http client is in a fit state to continue
            _httpClient.SetBaseAddress(settings);
            _httpClient.SetUserAgent(settings);
            _httpClient.SetApiHeader(settings);
            _httpClient.Validate();
        }
        
        /// <inheritdoc />
        public async Task<QueryResponse> QueryEmailAsync(string emailAddress, CancellationToken cancellationToken = default)
        {
            // validate the email address; this is basic checking as many different opinions on how to validate email addresses
            // and none of them are bullet proof. I am keeping away from the regex route as there is no perfect catch all one.
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new EmailRepException("Invalid email address. Email must be valid.");
            }

            // make the request and handle the response if error returned
            var response = await _httpClient.GetAsync($"{emailAddress}", cancellationToken);
            await ErrorResponseHandler.HandleResponse(response);

            // if we've got here then we have a valid response and we can read and map accordingly
            var source = await response.Content.ReadAsAsync<Internal.QueryResponse>();
            
            // map and push out the door
            return await QueryResponseMapper.MapAsync(source);
        }
    }
}
