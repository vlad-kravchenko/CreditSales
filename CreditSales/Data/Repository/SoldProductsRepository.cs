using CreditSales.Data.Models;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows.Forms;

namespace CreditSales.Data.Repository
{
    class SoldProductsRepository
    {
        public List<SoldProduct> GetSoldProducts()
        {
            List<SoldProduct> soldProducts = new List<SoldProduct>();

            string sql = "SELECT * FROM SoldProduct";
            using (SqlCeConnection conn = new SqlCeConnection(Storage.ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show("Невозможно установить соединение с базой данных!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return soldProducts;
                }
                SqlCeCommand command = new SqlCeCommand(sql, conn);
                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        soldProducts.Add(new SoldProduct
                        {
                            Id = (int)reader[0],
                            CategoryId = (int)reader[1],
                            CreditId = (int)reader[2],
                            Name = reader[3].ToString(),
                            Price = (decimal)reader[4],
                            AddAmount = (decimal)reader[5],
                            Discount = (decimal)reader[6],
                            Total = (decimal)reader[7]
                        });
                    }
                }
            }

            return soldProducts;
        }

        public void Delete(SoldProduct soldProduct)
        {
            string sql = "DELETE FROM SoldProduct WHERE Id=" + soldProduct.Id;
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

        public void AddOrUpdate(SoldProduct soldProduct)
        {
            if (GetSoldProducts().Any(p => p.Id == soldProduct.Id))
            {
                string sql = "UPDATE SoldProduct SET " +
                             "CategoryId=" + soldProduct.CategoryId +
                             ", CreditId='" + soldProduct.CreditId +
                             "',Name='" + soldProduct.Name +
                             "',Price='" + soldProduct.Price.ToString().Replace(',', '.') +
                             "',Discount='" + soldProduct.Discount.ToString().Replace(',', '.') +
                             "',Total='" + soldProduct.Total.ToString().Replace(',', '.') +
                             "',AddAmount='" + soldProduct.AddAmount.ToString().Replace(',', '.') +
                             "' WHERE Id=" + soldProduct.Id;
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
                string sql = "INSERT INTO SoldProduct (CategoryId, CreditId, Name, Price, AddAmount, Discount, Total) Values (" +
                             soldProduct.CategoryId + "," +
                             soldProduct.CreditId + ",'" +
                             soldProduct.Name + "','" +
                             soldProduct.Price.ToString().Replace(',', '.') + "','" +
                             soldProduct.AddAmount.ToString().Replace(',', '.') + "','" +
                             soldProduct.Discount.ToString().Replace(',', '.') + "','" +
                             soldProduct.Total.ToString().Replace(',', '.') + "')";
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