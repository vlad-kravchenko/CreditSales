namespace CreditSales.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserFIO { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Access { get; set; }
    }
}