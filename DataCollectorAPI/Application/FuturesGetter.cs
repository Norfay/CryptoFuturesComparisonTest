using DataCollectorAPI.Infra;
using DataCollectorAPI.Interfaces;

namespace DataCollectorAPI.Application
{    
    public class FuturesGetter : IFuturesGetter
    {        
        private readonly IHttpService _httpService;        

        public FuturesGetter(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<string> GetFuturesDataAsync(string futuresTiker, DateTime dateTime)
        {
            int counter = 0;
            while (counter <= 10)
            {
                var targetDate = dateTime.Date.AddDays(-counter);
                var targetStartTimeStamp = ((DateTimeOffset)targetDate).ToUnixTimeMilliseconds();
                var targetEndTimeStamp = ((DateTimeOffset)targetDate.AddDays(1)).ToUnixTimeMilliseconds() - 1;

                var query = BuildKlineQuary(futuresTiker, targetStartTimeStamp, targetEndTimeStamp);
                var response = await _httpService.SendGetRequestAsync(query);

                if (!string.IsNullOrEmpty(response))
                {
                    return response;
                }
                counter++;
            }
            throw new Exception("Can't get futures data");
        }

        private string BuildKlineQuary(string tiker, long startTimeStamp, long endTimeStamp, string interval = "1d")
        {
            string endpoint = "https://fapi.binance.com/fapi/v1/klines";
            return $"{endpoint}?symbol={tiker}&interval={interval}&startTime={startTimeStamp}&endTime={endTimeStamp}";
        }
    }

}
