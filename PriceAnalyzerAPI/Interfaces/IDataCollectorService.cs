using Domain;

namespace PriceAnalyzerAPI.Interfaces
{
    public interface IDataCollectorService
    {
        Task<KlineResponseDTO> GetFuturesDataAsync(string ticker);
    }
}
