namespace OllamaAIWebAPP.Services
{
    public class OllamaService
    {
        private readonly HttpClient _httpClient;

        public OllamaService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OllamaClient");
        }

        public async Task<string> GenerateResponseAsync(string prompt)
        {
            var requestBody = new
            {
                model = "llama3.2:latest",
                prompt,
                Stream = false
            };

            var response = await _httpClient.PostAsJsonAsync("/api/generate", requestBody);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
