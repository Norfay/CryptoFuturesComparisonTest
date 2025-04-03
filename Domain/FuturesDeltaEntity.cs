namespace Domain
{
    public class FuturesDeltaEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime ComparingTime { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal ClosePrice { get; set; }
    }
}
