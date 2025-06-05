using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace TourismRecommenderByKnowledgeBased.Services
{
    public class GeminiService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public GeminiService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _apiKey = configuration["Gemini:ApiKey"] ?? string.Empty;
        }

        public async Task<string> GetExplanationAsync(string destination)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                return string.Empty;
            }

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                $"https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={_apiKey}");

            var payload = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = $"Why should I visit {destination}? Provide a short explanation." }
                        }
                    }
                }
            };

            var json = JsonSerializer.Serialize(payload);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            using var response = await _client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return string.Empty;
            }

            using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);
            if (doc.RootElement.TryGetProperty("candidates", out var candidates) && candidates.GetArrayLength() > 0)
            {
                var parts = candidates[0].GetProperty("content").GetProperty("parts");
                if (parts.GetArrayLength() > 0)
                {
                    return parts[0].GetProperty("text").GetString() ?? string.Empty;
                }
            }

            return string.Empty;
        }
    }
}
