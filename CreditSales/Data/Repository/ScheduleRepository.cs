using CreditSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows.Forms;

namespace CreditSales.Data.Repository
{
    class ScheduleRepository
    {
        public List<Schedule> GetPayments()
        {
            List<Schedule> payments = new List<Schedule>();

            string sql = "SELECT * FROM Schedule";
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
                        payments.Add(new Schedule
                        {
                            Id = (int)reader[0],
                            CreditId = (int)reader[1],
                            Rest = (decimal)reader[2],
                            PaymentAmount = (decimal)reader[3],
                            SumPercent = (decimal)reader[4],
                            SumTotal = (decimal)reader[5],
                            DatePayment = (DateTime)reader[6],
                            Comment = reader[7].ToString()
                        });
                    }
                }
            }

            return payments;
        }

        public void Delete(Schedule payment)
        {
            string sql = "DELETE FROM Schedule WHERE Id=" + payment.Id;
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

        public void AddOrUpdate(Schedule payment)
        {
            if (GetPayments().Any(u => u.Id == payment.Id))
            {
                string sql = "UPDATE Schedule SET " +
                             "CreditId=" + payment.CreditId +
                             ",Rest='" + payment.Rest.ToString().Replace(',', '.') +
                             "',Payment='" + payment.PaymentAmount.ToString().Replace(',', '.') +
                             "',SumPercent='" + payment.SumPercent.ToString().Replace(',', '.') +
                             "',SumTotal='" + payment.SumTotal.ToString().Replace(',', '.') +
                             "',DatePayment='" + payment.DatePayment.ToString("yyyy-MM-dd HH:mm:ss") +
                             "',Comment='" + payment.Comment +
                             "' WHERE Id=" + payment.Id;
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
                string sql = "INSERT INTO Schedule (CreditId, Rest, Payment, SumPercent, SumTotal, DatePayment, Comment) Values (" +
                             payment.CreditId + ",'" +
                             payment.Rest.ToString().Replace(',', '.') + "','" +
                             payment.PaymentAmount.ToString().Replace(',', '.') + "','" +
                             payment.SumPercent.ToString().Replace(',', '.') + "','" +
                             payment.SumTotal.ToString().Replace(',', '.') + "','" +
                             payment.DatePayment.ToString("yyyy-MM-dd HH:mm:ss") + "','" +
                             payment.Comment + "')";
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
