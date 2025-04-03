using DataCollectorAPI.Interfaces;

namespace DataCollectorAPI.Infra
{    
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> SendRequestAsync(HttpRequestMessage request)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error during making request: {e.Message}");
                return null;
            }
        }

        public async Task<string?> SendGetRequestAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            return await SendRequestAsync(request);
        }
    }
}
