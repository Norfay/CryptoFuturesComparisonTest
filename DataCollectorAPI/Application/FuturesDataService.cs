using DataCollectorAPI.Interfaces;
using Domain;

namespace DataCollectorAPI.Application
{    
    public class FuturesDataService : IFuturesDataService
    {
        private readonly IFuturesGetter _getter;
        private readonly IKlineDataProcessor _dataProcessor;

        public FuturesDataService(IFuturesGetter getter, IKlineDataProcessor dataProcessor)
        {
            _getter = getter;
            _dataProcessor = dataProcessor;
        }

        public async Task<KlineResponseDTO> GetFuturesDataAsync(string futuresTicker, DateTime targetDate)
        {
            var rawData = await _getter.GetFuturesDataAsync(futuresTicker, targetDate);
            return _dataProcessor.ConvertToEntitiesList(rawData);
        }
    }
}
