using Domain;
using PriceAnalyzerAPI.Interfaces;

namespace PriceAnalyzerAPI.Application
{    
    public class FuturesDeltaCalculator : IFuturesDeltaCalculator
    {
        public FuturesDeltaEntity CalculateDelta(KlineResponseDTO currentFuturesKline, KlineResponseDTO nextFuturesKline)
        {
            if (currentFuturesKline == null || nextFuturesKline == null)
                throw new ArgumentNullException("One of KlineEntities is null");

            return new FuturesDeltaEntity
            {
                ComparingTime = DateTime.UtcNow,
                OpenPrice = currentFuturesKline.OpenPrice - nextFuturesKline.OpenPrice,
                HighPrice = currentFuturesKline.HighPrice - nextFuturesKline.HighPrice,
                LowPrice = currentFuturesKline.LowPrice - nextFuturesKline.LowPrice,
                ClosePrice = currentFuturesKline.ClosePrice - nextFuturesKline.ClosePrice
            };
        }
    }
}
