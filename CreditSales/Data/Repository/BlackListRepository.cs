using CreditSales.Data.Models;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows.Forms;

namespace CreditSales.Data.Repository
{
    public class BlackListRepository
    {
        public List<BlackList> GetBlackList()
        {
            List<BlackList> users = new List<BlackList>();

            string sql = "SELECT * FROM BlackList";
            using (SqlCeConnection conn = new SqlCeConnection(Storage.ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    MessageBox.Show("Невозможно установить соединение с базой данных!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return users;
                }
                SqlCeCommand command = new SqlCeCommand(sql, conn);
                using (SqlCeDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new BlackList
                        {
                            Id = (int)reader[0],
                            Client = reader[1].ToString(),
                            Address = reader[2].ToString(),
                            Document = reader[3].ToString(),
                            Phone = reader[4].ToString()
                        });
                    }
                }
            }

            return users;
        }

        public void Delete(BlackList userBlackList)
        {
            string sql = "DELETE FROM BlackList WHERE Id=" + userBlackList.Id;
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

        public void AddOrUpdate(BlackList userBlackList)
        {
            if (GetBlackList().Any(u => u.Id == userBlackList.Id))
            {
                string sql = "UPDATE BlackList SET " +
                             "Client='" + userBlackList.Client +
                             "',Address='" + userBlackList.Address +
                             "',Document='" + userBlackList.Document +
                             "',Phone='" + userBlackList.Phone +
                             "' WHERE Id=" + userBlackList.Id;
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
                string sql = "INSERT INTO BlackList (Client, Address, Phone, Document) Values ('" +
                             userBlackList.Client + "','" +
                             userBlackList.Address + "','" +
                             userBlackList.Phone + "','" +
                             userBlackList.Document + "')";
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

        public void AddToBlackListFromCredit(Credit currentCredit)
        {
            string sql = "INSERT INTO BlackList (Client, Address, Phone, Document) Values ('" +
                         currentCredit.ClientFIO + "','" +
                         currentCredit.ClientAdr + "','" +
                         currentCredit.ClientPhone + "','" +
                         currentCredit.ClientDoc + "')";
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