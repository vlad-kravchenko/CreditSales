namespace CreditSales.Data.Models
{
    public class Base
    {
        public int Id { get; set; }
        public int DayPayment { get; set; }
        public decimal FirstPaymentPercent { get; set; }
        public decimal PercentPenalty { get; set; }
        public decimal PercentYear { get; set; }
        public int Round { get; set; }
        public int Term { get; set; }
        public int LastCredit { get; set; }
    }
}