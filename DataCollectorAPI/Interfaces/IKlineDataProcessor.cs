using Domain;

namespace DataCollectorAPI.Interfaces
{
    public interface IKlineDataProcessor
    {
        KlineResponseDTO ConvertToEntitiesList(string rawData);
    }
}
