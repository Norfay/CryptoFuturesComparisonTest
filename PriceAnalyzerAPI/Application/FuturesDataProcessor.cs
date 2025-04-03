using Domain;
using PriceAnalyzerAPI.Interfaces;

namespace PriceAnalyzerAPI.Application
{    
    public class FuturesDataProcessor : IFuturesDataProcessor
    {
        private readonly IDataCollectorService _dataCollector;
        private readonly IFuturesDeltaCalculator _deltaCalculator;

        public FuturesDataProcessor(IDataCollectorService dataCollector, IFuturesDeltaCalculator deltaCalculator)
        {
            _dataCollector = dataCollector;
            _deltaCalculator = deltaCalculator;
        }

        public async Task<FuturesDeltaEntity> CompareFuturesPrices()
        {
            var currentQuarterFuturesKline = await _dataCollector.GetFuturesDataAsync("BTCUSDT_250627");
            var nextQuarterFuturesKline = await _dataCollector.GetFuturesDataAsync("BTCUSDT_250926");

            return _deltaCalculator.CalculateDelta(currentQuarterFuturesKline, nextQuarterFuturesKline);
        }
    }
}
