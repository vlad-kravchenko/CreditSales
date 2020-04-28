using CreditSales.Data.Models;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace CreditSales.Data.Repository
{
    public class MainInfoRepository
    {
        public MainInfo GetMainInfo()
        {
            List<MainInfo> infos = new List<MainInfo>();

            string sql = "SELECT * FROM MainInfo";
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
                        infos.Add(new MainInfo
                        {
                            Id = (int)reader[0],
                            Name = reader[1].ToString(),
                            INN = reader[2].ToString(),
                            Document = reader[3].ToString(),
                            Phone = reader[4].ToString(),
                            City = reader[5].ToString(),
                            UridAddress = reader[6].ToString(),
                            OfficeAddress = reader[7].ToString(),
                            Bank = reader[8].ToString(),
                            Chief = reader[9].ToString()
                        });
                    }
                }
            }
            
            return infos[0];
        }

        public void UpdateMainInfo(MainInfo info)
        {
            string sql = "UPDATE MainInfo SET " +
                         "Name='" + info.Name +
                         "',INN='" + info.INN +
                         "',Document='" + info.Document +
                         "',Phone='" + info.Phone +
                         "',City='" + info.City +
                         "',UridAddress='" + info.UridAddress +
                         "',OfficeAddress='" + info.OfficeAddress +
                         "',Bank='" + info.Bank +
                         "',Chief='" + info.Chief +
                         "' WHERE Id=" + info.Id;
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