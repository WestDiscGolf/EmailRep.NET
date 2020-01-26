using System;
using System.Linq;
using System.Net.Http;

namespace EmailRep.NET.Internal
{
    /// <summary>
    /// Internal HttpClient Extensions.
    /// </summary>
    internal static class HttpClientExtensions
    {
        private const string ApiKeyHeader = "Key";

        /// <summary>
        /// Validate the <see cref="HttpClient"/> is ready to be used.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> instance being used in the typed client.</param>
        public static void Validate(this HttpClient client)
        {
            // must have a base url so we'd better check for one
            if (!client.IsBaseAddressConfigured())
            {
                throw new EmailRepConfigurationException($"'{nameof(HttpClient.BaseAddress)}' can not be empty. Please check your configuration.");
            }

            if (!client.IsUserAgentConfigured())
            {
                throw new EmailRepConfigurationException("'User-Agent' Header can not be empty. Please check your configuration.");
            }
        }

        /// <summary>
        /// Checks to see if the Api Request header has already been set.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> instance being used in the typed client.</param>
        /// <returns></returns>
        public static bool IsApiHeaderConfigured(this HttpClient client) => client.DefaultRequestHeaders.TryGetValues(ApiKeyHeader, out var values) && values.Any(x => !string.IsNullOrWhiteSpace(x));

        /// <summary>
        /// Sets the Api request header if supplied and not already configured.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> instance being used in the typed client.</param>
        /// <param name="settings">The optional <see cref="EmailRepClientSettings"/> instance.</param>
        public static void SetApiHeader(this HttpClient client, EmailRepClientSettings settings)
        {
            if (!client.IsApiHeaderConfigured() && (settings != null && settings.ApiKeySpecified))
            {
                client.DefaultRequestHeaders.Add(ApiKeyHeader, settings.ApiKey);
            }
        }

        /// <summary>
        /// Checks to see if the base address has already been set.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> instance being used in the typed client.</param>
        /// <returns></returns>
        public static bool IsBaseAddressConfigured(this HttpClient client) => client.BaseAddress != null;

        /// <summary>
        /// Sets the BaseAddress if supplied and not already configured.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> instance being used in the typed client.</param>
        /// <param name="settings">The optional <see cref="EmailRepClientSettings"/> instance.</param>
        public static void SetBaseAddress(this HttpClient client, EmailRepClientSettings settings)
        {
            if (!client.IsBaseAddressConfigured() && (settings != null && settings.BaseUrlSpecified))
            {
                client.BaseAddress = new Uri(settings.BaseUrl);
            }
        }

        /// <summary>
        /// Checks to see if the User Agent Request header has already been set.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> instance being used in the typed client.</param>
        /// <returns></returns>
        public static bool IsUserAgentConfigured(this HttpClient client) => client.DefaultRequestHeaders.TryGetValues("User-Agent", out var values) && values.Any();

        /// <summary>
        /// Sets the User Agent request header if supplied and not already configured.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> instance being used in the typed client.</param>
        /// <param name="settings">The optional <see cref="EmailRepClientSettings"/> instance.</param>
        public static void SetUserAgent(this HttpClient client, EmailRepClientSettings settings)
        {
            if (!client.IsUserAgentConfigured() && (settings != null && settings.UserAgentSpecified))
            {
                client.DefaultRequestHeaders.UserAgent.TryParseAdd(settings.UserAgent);
            }
        }
    }
}