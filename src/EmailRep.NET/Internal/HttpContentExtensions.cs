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

            var jsonString = await content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResult>(jsonString, options);
        }
    }
}