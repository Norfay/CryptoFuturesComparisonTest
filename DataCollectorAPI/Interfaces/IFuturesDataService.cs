using Domain;

namespace DataCollectorAPI.Interfaces
{
    public interface IFuturesDataService
    {
        Task<KlineResponseDTO> GetFuturesDataAsync(string futuresTicker, DateTime targetDate);
    }
}
