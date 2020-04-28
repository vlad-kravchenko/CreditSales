using System;

namespace CreditSales.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int CreditId { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal SumPercent { get; set; }
        public decimal SumPenalty { get; set; }
        public DateTime DatePayment { get; set; }
    }
}