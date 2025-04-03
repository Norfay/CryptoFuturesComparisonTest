namespace DataCollectorAPI.Interfaces
{
    public interface IFuturesGetter
    {
        Task<string> GetFuturesDataAsync(string futuresTiker, DateTime targetDate);
    }
}
