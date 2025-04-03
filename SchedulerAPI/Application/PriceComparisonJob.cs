using Domain;
using Newtonsoft.Json;
using SchedulerAPI.Interfaces;

namespace SchedulerAPI.Application
{    
    public class PriceComparisonJob : IPriceComparisonJob
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string FuturesCompareUrl = "https://localhost:7189/PriceAnalyzer/compare-prices";
        private const string SaveToDBUrl = "https://localhost:7249/Database/save-price-difference";

        public PriceComparisonJob(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task Execute()
        {
            var client = _clientFactory.CreateClient();

            var response = await client.GetStringAsync(FuturesCompareUrl);

            var priceDiff = JsonConvert.DeserializeObject<FuturesDeltaDTO>(response);
            await client.PostAsJsonAsync(SaveToDBUrl, priceDiff);
        }
    }
}
