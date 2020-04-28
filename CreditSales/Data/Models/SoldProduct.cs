namespace CreditSales.Data.Models
{
    public class SoldProduct
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CreditId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal AddAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}