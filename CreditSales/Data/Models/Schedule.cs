using System;

namespace CreditSales.Data.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int CreditId { get; set; }
        public decimal Rest { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal SumPercent { get; set; }
        public decimal SumTotal { get; set; }
        public DateTime DatePayment { get; set; }
        public string Comment { get; set; }
    }
}