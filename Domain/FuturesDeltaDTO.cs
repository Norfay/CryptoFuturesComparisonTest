namespace Domain
{
    public class FuturesDeltaDTO
    {
        public DateTime ComparingTime { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal ClosePrice { get; set; }
    }
}
