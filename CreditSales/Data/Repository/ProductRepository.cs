using CreditSales.Data.Models;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows.Forms;

namespace CreditSales.Data.Repository
{
    public class ProductRepository
    {
        private CategoryRepository _categoryRepository = new CategoryRepository();

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            string sql = "SELECT * FROM Product";
            using (SqlCeConnection conn = new SqlCeConnection(Storage.ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show("Невозможно установить соединение с базой данных!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return products;
                }
                SqlCeCommand command = new SqlCeCommand(sql, conn);
                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = (int)reader[0],
                            Number = (int)reader[1],
                            CategoryId = (int)reader[2],
                            Category = _categoryRepository.GetCategories().FirstOrDefault(c=>c.Id == (int)reader[2]),
                            Name = reader[3].ToString(),
                            Price = (decimal)reader[4],
                            AddAmount = (decimal)reader[5],
                            Discount = (decimal)reader[6],
                            Total = (decimal)reader[7]
                        });
                    }
                }
            }

            return products;
        }

        public void Delete(Product product)
        {
            string sql = "DELETE FROM Product WHERE Id=" + product.Id;
            using (SqlCeConnection conn = new SqlCeConnection(Storage.ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show("Невозможно установить соединение с базой данных!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SqlCeCommand command = new SqlCeCommand(sql, conn);
                command.ExecuteScalar();
            }
        }

        public void AddOrUpdate(Product product)
        {
            if (GetProducts().Any(p => p.Id == product.Id))
            {
                string sql = "UPDATE Product SET " +
                             "Number=" + product.Number +
                             ",CategoryId=" + product.CategoryId +
                             ",Name='" + product.Name +
                             "',Price='" + product.Price.ToString().Replace(',', '.') +
                             "',Discount='" + product.Discount.ToString().Replace(',', '.') +
                             "',Total='" + product.Total.ToString().Replace(',', '.') +
                             "',AddAmount='" + product.AddAmount.ToString().Replace(',', '.') +
                             "' WHERE Id=" + product.Id;
                using (SqlCeConnection conn = new SqlCeConnection(Storage.ConnectionString))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно установить соединение с базой данных!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SqlCeCommand command = new SqlCeCommand(sql, conn);
                    command.ExecuteScalar();
                }
            }
            else
            {
                string sql = "INSERT INTO Product (Number, CategoryId, Name, Price, AddAmount, Discount, Total) Values (" +
                             product.Number + "," +
                             product.CategoryId + ",'" +
                             product.Name + "','" +
                             product.Price.ToString().Replace(',', '.') + "','" +
                             product.AddAmount.ToString().Replace(',', '.') + "','" +
                             product.Discount.ToString().Replace(',', '.') + "','" +
                             product.Total.ToString().Replace(',', '.') + "')";
                using (SqlCeConnection conn = new SqlCeConnection(Storage.ConnectionString))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно установить соединение с базой данных!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SqlCeCommand command = new SqlCeCommand(sql, conn);
                    command.ExecuteScalar();
                }
            }
        }
    }
}