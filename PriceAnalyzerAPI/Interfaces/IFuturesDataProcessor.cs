using Domain;

namespace PriceAnalyzerAPI.Interfaces
{
    public interface IFuturesDataProcessor
    {
        Task<FuturesDeltaEntity> CompareFuturesPrices();
    }
}
