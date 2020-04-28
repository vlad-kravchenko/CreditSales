using System;

namespace CreditSales.Data.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Data { get; set; }
        public string Consult { get; set; }
        public string ClientFIO { get; set; }
        public string ClientAdr { get; set; }
        public string ClientDoc { get; set; }
        public string ClientPhone { get; set; }
        public decimal TotalClean { get; set; }
        public decimal DiscPercent { get; set; }
        public decimal AddPercent { get; set; }
        public decimal Total { get; set; }
        public decimal FirstPayment { get; set; }
        public int Term { get; set; }
        public decimal PercentYear { get; set; }
        public int DayPayment { get; set; }
        public bool IsActive { get; set; }
    }
}