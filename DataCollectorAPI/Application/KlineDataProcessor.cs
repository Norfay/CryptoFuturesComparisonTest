using DataCollectorAPI.Interfaces;
using Domain;
using System.Globalization;

namespace DataCollectorAPI.Application
{    
    public class KlineDataProcessor : IKlineDataProcessor
    {
        public KlineResponseDTO ConvertToEntitiesList(string rawData)
        {

            var newItemString = rawData.Replace("[", "").Replace("]", "").Replace("\"", "");
            var newItemList = newItemString.Split(",").ToList();

            if (newItemList.Count < 9) throw new ArgumentException("Raw kline response data error");

            var KlineResponse = new KlineResponseDTO()
            {
                OpenTime = UnixTimeStampMillisecondsToDateTime(Convert.ToUInt64(newItemList[0])),
                OpenPrice = ParseDecimal(newItemList[1]),
                HighPrice = ParseDecimal(newItemList[2]),
                LowPrice = ParseDecimal(newItemList[3]),
                ClosePrice = ParseDecimal(newItemList[4]),
                Volume = ParseDecimal(newItemList[5]),
                CloseTime = UnixTimeStampMillisecondsToDateTime(Convert.ToUInt64(newItemList[6])),
                QuoteAssetVolume = ParseDecimal(newItemList[7]),
                NumberOfTrades = Convert.ToUInt32(newItemList[8])
            };

            return KlineResponse;
        }

        private decimal ParseDecimal(string value)
        {
            return decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result) ? result : throw new FormatException($"Wrong data format: {value}");
        }

        private DateTime UnixTimeStampMillisecondsToDateTime(ulong unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddMilliseconds(unixTimeStamp).ToUniversalTime();
        }
    }
}
