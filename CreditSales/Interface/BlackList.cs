using System;
using System.Drawing;
using System.Windows.Forms;
using CreditSales.Data.Repository;

namespace CreditSales.Interface
{
    public partial class BlackList : Form
    {
        private BlackListRepository _blackListRepository = new BlackListRepository();
        private Data.Models.BlackList CurrentUser;

        public BlackList()
        {
            InitializeComponent();

            LoadGrid();
        }

        private void LoadGrid()
        {
            gridUsers.Rows.Clear();
            var users = _blackListRepository.GetBlackList();
            foreach (var user in users)
            {
                var row = new DataGridViewRow();
                row.Tag = user;
                for (int i = 0; i < 4; i++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = user.Client;
                row.Cells[1].Value = user.Address;
                row.Cells[2].Value = user.Document;
                row.Cells[3].Value = user.Phone;
                gridUsers.Rows.Add(row);
            }
        }

        private void gridUsers_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverRow = gridUsers.HitTest(e.X, e.Y).RowIndex;
                    CurrentUser = gridUsers.Rows[currentMouseOverRow].Tag as Data.Models.BlackList;
                    if (CurrentUser != null)
                    {
                        gridContextMenu.Show(gridUsers, e.Location);
                    }
                }
            }
            catch
            {
                //nothing to do, wait for next user actions
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addUser_Click(object sender, EventArgs e)
        {
            var form = new ClientInfo();
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void editUser_Click(object sender, EventArgs e)
        {
            if (CurrentUser == null) return;
            var form = new ClientInfo(CurrentUser);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void deleteUser_Click(object sender, EventArgs e)
        {
            if (CurrentUser == null) return;
            if (MessageBox.Show("Вы уверенны, что хотите удалить клиента " + CurrentUser.Client + " из чёрного списка?", "Удаление клиента", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _blackListRepository.Delete(CurrentUser);
                CurrentUser = null;
                LoadGrid();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new ClientInfo();
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count != 0)
            {
                CurrentUser = gridUsers.SelectedRows[0].Tag as Data.Models.BlackList;
            }
            if (CurrentUser == null) return;
            var form = new ClientInfo(CurrentUser);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridUsers.SelectedRows.Count != 0)
            {
                CurrentUser = gridUsers.SelectedRows[0].Tag as Data.Models.BlackList;
            }
            if (CurrentUser == null) return;
            if (MessageBox.Show("Вы уверенны, что хотите удалить клиента " + CurrentUser.Client + " из чёрного списка?", "Удаление клиента", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _blackListRepository.Delete(CurrentUser);
                CurrentUser = null;
                LoadGrid();
            }
        }
    }
}