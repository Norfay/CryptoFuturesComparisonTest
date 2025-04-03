using Domain;

namespace DatabaseAPI.Interfaces
{
    public interface IFuturesDeltaRepository
    {
        Task SaveAsync(FuturesDeltaEntity delta);
    }
}
