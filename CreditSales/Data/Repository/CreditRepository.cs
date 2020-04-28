using CreditSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows.Forms;

namespace CreditSales.Data.Repository
{
    public class CreditRepository
    {
        private ScheduleRepository _scheduleRepository = new ScheduleRepository();
        private SoldProductsRepository _soldProductsRepository = new SoldProductsRepository();
        private PaymentRepository _paymentRepository = new PaymentRepository();
        private BaseRepository _baseRepository = new BaseRepository();

        public List<Credit> GetCredits()
        {
            List<Credit> credits = new List<Credit>();

            string sql = "SELECT * FROM Credits";
            using (SqlCeConnection conn = new SqlCeConnection(Storage.ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show("Невозможно установить соединение с базой данных!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return credits;
                }
                SqlCeCommand command = new SqlCeCommand(sql, conn);
                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        credits.Add(new Credit
                        {
                            Id = (int)reader[0],
                            Number = (int)reader[1],
                            Data = (DateTime)reader[2],
                            Consult = reader[3].ToString(),
                            ClientFIO = reader[4].ToString(),
                            ClientAdr = reader[5].ToString(),
                            ClientDoc = reader[6].ToString(),
                            ClientPhone = reader[7].ToString(),
                            TotalClean = (decimal)reader[8],
                            DiscPercent = (decimal)reader[9],
                            AddPercent = (decimal)reader[10],
                            Total = (decimal)reader[11],
                            FirstPayment = (decimal)reader[12],
                            Term = (int)reader[13],
                            PercentYear = (decimal)reader[14],
                            DayPayment = (int)reader[15],
                            IsActive = (bool)reader[16]
                        });
                    }
                }
            }

            return credits;
        }

        public void Delete(Credit credit, bool deleteAll = true)
        {
            var products = _soldProductsRepository.GetSoldProducts().Where(p => p.CreditId == credit.Id).ToList();
            var schedule = _scheduleRepository.GetPayments().Where(s => s.CreditId == credit.Id).ToList();
            var payments = _paymentRepository.GetPayments().Where(p => p.CreditId == credit.Id).ToList();
            products.ForEach(p => _soldProductsRepository.Delete(p));
            schedule.ForEach(s => _scheduleRepository.Delete(s));
            if (deleteAll)
            {
                payments.ForEach(p => _paymentRepository.Delete(p));
                string sql = "DELETE FROM Credits WHERE Id=" + credit.Id;
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

        public void AddOrUpdate(Credit credit)
        {
            if (GetCredits().Any(c => c.Id == credit.Id))
            {
                string sql = "UPDATE Credits SET " +
                             "Number=" + credit.Number +
                             ",Data='" + credit.Data.ToString("yyyy-MM-dd HH:mm:ss") +
                             "',Consult='" + credit.Consult +
                             "',ClientFIO='" + credit.ClientFIO +
                             "',ClientAdr='" + credit.ClientAdr +
                             "',ClientDoc='" + credit.ClientDoc +
                             "',ClientPhone='" + credit.ClientPhone +
                             "',TotalClean='" + credit.TotalClean.ToString().Replace(',', '.') +
                             "',DiscPercent='" + credit.DiscPercent.ToString().Replace(',', '.') +
                             "',AddPercent='" + credit.AddPercent.ToString().Replace(',', '.') +
                             "',Total='" + credit.Total.ToString().Replace(',', '.') +
                             "',FirstPayment='" + credit.FirstPayment.ToString().Replace(',', '.') +
                             "',Term=" + credit.Term.ToString().Replace(',', '.') +
                             ",PercentYear='" + credit.PercentYear.ToString().Replace(',', '.') +
                             "',DayPayment=" + credit.DayPayment.ToString().Replace(',', '.') +
                             ",IsActive=" + (credit.IsActive ? "1" : "0") +
                             " WHERE Id=" + credit.Id;
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
                _baseRepository.IncreaseNumber(credit.Number);
                string sql = "INSERT INTO Credits (Number,Data,Consult,ClientFIO,ClientAdr,ClientDoc,ClientPhone,TotalClean,DiscPercent,AddPercent,Total,FirstPayment,Term,PercentYear,DayPayment,IsActive) Values (" +
                             credit.Number + ",'" +
                             credit.Data.ToString("yyyy-MM-dd HH:mm:ss") + "','" +
                             credit.Consult + "','" +
                             credit.ClientFIO + "','" +
                             credit.ClientAdr + "','" +
                             credit.ClientDoc + "','" +
                             credit.ClientPhone + "','" +
                             credit.TotalClean.ToString().Replace(',', '.') + "','" +
                             credit.DiscPercent.ToString().Replace(',', '.') + "','" +
                             credit.AddPercent.ToString().Replace(',', '.') + "','" +
                             credit.Total.ToString().Replace(',', '.') + "','" +
                             credit.FirstPayment.ToString().Replace(',', '.') + "'," +
                             credit.Term.ToString().Replace(',', '.') + ",'" +
                             credit.PercentYear.ToString().Replace(',', '.') + "'," +
                             credit.DayPayment + "," +
                             (credit.IsActive ? "1" : "0") + ")";
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

        public int GetLastId()
        {
            string sql = "SELECT max(Id) FROM Credits";
            using (SqlCeConnection conn = new SqlCeConnection(Storage.ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show("Невозможно установить соединение с базой данных!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                SqlCeCommand command = new SqlCeCommand(sql, conn);
                return (int)command.ExecuteScalar();
            }
        }

        public void CloseCredit(int creditId)
        {
            string sql = "UPDATE Credits SET IsActive=0 WHERE Id=" + creditId;
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

        public void ReopenCredit(int creditId)
        {
            string sql = "UPDATE Credits SET IsActive=1 WHERE Id=" + creditId;
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