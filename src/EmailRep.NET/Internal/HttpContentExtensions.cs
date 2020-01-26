using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmailRep.NET.Internal
{
    /// <summary>
    /// HttpContent Extensions
    /// </summary>
    internal static class HttpContentExtensions
    {
        /// <summary>
        /// Reads the specified <typeparamref name="TResult"/> from the specified <see cref="HttpContent"/>.
        /// </summary>
        /// <typeparam name="TResult">The target type of the content.</typeparam>
        /// <param name="content">The target httpcontent.</param>
        /// <returns>An instance of <typeparamref name="TResult"/> from the HttpContent.</returns>
        public static async Task<TResult> ReadAsAsync<TResult>(this HttpContent content)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            // easier for debugging
            //var jsonString = await content.ReadAsStringAsync();
            //return JsonSerializer.Deserialize<TResult>(jsonString, options);

            using var responseStream = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<TResult>(responseStream, options);
        }
    }
}