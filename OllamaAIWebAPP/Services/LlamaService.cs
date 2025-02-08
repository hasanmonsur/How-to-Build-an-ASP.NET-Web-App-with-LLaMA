using System.Text.Json;
using System.Text;
using OllamaAIWebAPP.Models;

namespace OllamaAIWebAPP.Services
{
    public class LlamaService
    {
        private readonly HttpClient _httpClient;

        public LlamaService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OllamaClient");
        }

        public async Task<string> GetResponseFromLlamaAsync(string prompt)
        {
            var requestBody = new { model = "llama3.2:latest", prompt = prompt, Stream = false };
            //var content = new StringContent(requestBody, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsJsonAsync("/api/generate", requestBody);
            response.EnsureSuccessStatusCode();

            var jsonResponse=await response.Content.ReadAsStringAsync();

            //var response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);
            //response.EnsureSuccessStatusCode();

            //var jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<LlamaResponse>(jsonResponse)?.response ?? "No response";
        }
    }
}
