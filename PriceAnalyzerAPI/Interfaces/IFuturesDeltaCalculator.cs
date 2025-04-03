using Domain;

namespace PriceAnalyzerAPI.Interfaces
{
    public interface IFuturesDeltaCalculator
    {
        FuturesDeltaEntity CalculateDelta(KlineResponseDTO currentFuturesKline, KlineResponseDTO nextFuturesKline);
    }
}
