namespace Domain
{
    public class KlineResponseDTO
    {
        public DateTime OpenTime { get; set; } 
        public decimal OpenPrice { get; set; }   
        public decimal HighPrice { get; set; }   
        public decimal LowPrice { get; set; }                                        
        public decimal ClosePrice { get; set; }
        public decimal Volume { get; set; }
        public DateTime CloseTime { get; set; }
        public decimal QuoteAssetVolume { get; set; }
        public uint NumberOfTrades { get; set; }                                                                                                      
    }
}
