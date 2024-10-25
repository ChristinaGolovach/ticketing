using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TicketingIntegrationTests.Configuration
{
    public static class Utils
    {
        public static async Task<T?> GetRequestContent<T>(HttpResponseMessage httpResponseMessage)
        {
            JsonSerializerOptions jsonSettings = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() },
            };

            return await httpResponseMessage.Content.ReadFromJsonAsync<T>(jsonSettings);
        }
    }
}
