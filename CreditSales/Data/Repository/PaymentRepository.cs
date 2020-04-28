using CreditSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace CreditSales.Data.Repository
{
    class PaymentRepository
    {
        public List<Payment> GetPayments()
        {
            List<Payment> payments = new List<Payment>();

            string sql = "SELECT * FROM Payments";
            using (SqlCeConnection conn = new SqlCeConnection(Storage.ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show("Невозможно установить соединение с базой данных!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return payments;
                }
                SqlCeCommand command = new SqlCeCommand(sql, conn);
                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        payments.Add(new Payment
                        {
                            Id = (int)reader[0],
                            CreditId = (int)reader[1],
                            PaymentAmount = (decimal)reader[2],
                            SumPercent = (decimal)reader[3],
                            SumPenalty = (decimal)reader[4],
                            DatePayment = (DateTime)reader[5]
                        });
                    }
                }
            }

            return payments;
        }

        public void Delete(Payment payment)
        {
            string sql = "DELETE FROM Payments WHERE Id=" + payment.Id;
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

        public void AddOrUpdate(Payment payment)
        {
            string sql = "INSERT INTO Payments (CreditId, Payment, SumPercent, SumPenalty, DatePayment) Values (" +
                         payment.CreditId + ",'" +
                         payment.PaymentAmount.ToString().Replace(',', '.') + "','" +
                         payment.SumPercent.ToString().Replace(',', '.') + "','" +
                         payment.SumPenalty.ToString().Replace(',', '.') + "','" +
                         payment.DatePayment.ToString("yyyy-MM-dd HH:mm:ss") + "')";
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