namespace CreditSales.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal AddAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}