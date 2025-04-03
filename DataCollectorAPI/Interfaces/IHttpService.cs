namespace DataCollectorAPI.Interfaces
{
    public interface IHttpService
    {
        Task<string?> SendGetRequestAsync(string url);
        Task<string?> SendRequestAsync(HttpRequestMessage request);
    }
}
