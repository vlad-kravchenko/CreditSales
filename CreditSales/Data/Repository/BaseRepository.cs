using CreditSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace CreditSales.Data.Repository
{
    public class BaseRepository
    {
        public Base GetBaseFinanceInfo()
        {
            List<Base> bases = new List<Base>();

            string sql = "SELECT * FROM Base";
            using (SqlCeConnection conn = new SqlCeConnection(Storage.ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show("Невозможно установить соединение с базой данных!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                SqlCeCommand command = new SqlCeCommand(sql, conn);
                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bases.Add(new Base
                        {
                            Id = (int)reader[0],
                            FirstPaymentPercent = Convert.ToDecimal(reader[1].ToString()),
                            Term = (int)reader[2],
                            PercentYear = Convert.ToDecimal(reader[3].ToString()),
                            DayPayment = (int)reader[4],
                            Round = Convert.ToInt32(reader[5].ToString()),
                            PercentPenalty = Convert.ToDecimal(reader[6].ToString()),
                            LastCredit = (int)reader[7]
                        });
                    }
                }
            }
            
            return bases[0];
        }

        public void UpdateBaseFinanceInfo(Base baseInfo)
        {
            string sql = "UPDATE Base SET " +
                         "FirstPaymentPercent='" + baseInfo.FirstPaymentPercent.ToString().Replace(',', '.') +
                         "',Term=" + baseInfo.Term.ToString().Replace(',', '.') +
                         ",PercentYear='" + baseInfo.PercentYear.ToString().Replace(',', '.') +
                         "',DayPayment=" + baseInfo.DayPayment.ToString().Replace(',', '.') +
                         ",Round=" + baseInfo.Round.ToString().Replace(',', '.') +
                         ",PercentPenalty='" + baseInfo.PercentPenalty.ToString().Replace(',','.') +
                         "',LastCredit=" + baseInfo.LastCredit.ToString().Replace(',', '.') +
                         " WHERE Id=" + baseInfo.Id;
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

        public void IncreaseNumber(int number)
        {
            string sql = "UPDATE Base SET LastCredit=" + number;
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