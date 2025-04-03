using Domain;
using Newtonsoft.Json;
using PriceAnalyzerAPI.Interfaces;

namespace PriceAnalyzerAPI.Application
{   
    public class DataCollectorService : IDataCollectorService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string BaseUrl = "https://localhost:7009/DataCollector/get-yesterday-prices/";

        public DataCollectorService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<KlineResponseDTO> GetFuturesDataAsync(string ticker)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetStringAsync($"{BaseUrl}{ticker}");

            return string.IsNullOrEmpty(response)
                ? null
                : JsonConvert.DeserializeObject<KlineResponseDTO>(response);
        }
    }
}
