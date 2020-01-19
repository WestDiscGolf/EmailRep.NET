using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmailRep.NET.Internal
{
    internal static class HttpContentExtensions
    {
        public static async Task<TResult> ReadAsAsync<TResult>(this HttpContent content)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            using var responseStream = await content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<TResult>(responseStream, options);
        }
    }
}