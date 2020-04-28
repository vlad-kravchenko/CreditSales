using CreditSales.Data;
using CreditSales.Data.Models;
using CreditSales.Data.Repository;
using System.Windows.Forms;

namespace CreditSales.Interface
{
    public partial class UsersForm : Form
    {
        private UserRepository _userRepository = new UserRepository();

        public UsersForm()
        {
            InitializeComponent();
            toolTip.SetToolTip(btnAdd, "Добавить нового пользователя");
            toolTip.SetToolTip(btnEdit, "Редактировать выбранного пользователя");
            toolTip.SetToolTip(btnDelete, "Удалить выбранного пользователя");
            toolTip.SetToolTip(btnSave, "Сохранить");

            LoadGrid();
        }

        private void LoadGrid()
        {
            gridUsers.Rows.Clear();
            var users = _userRepository.GetUsers();
            foreach (var user in users)
            {
                var row = new DataGridViewRow();
                row.Tag = user;
                for (int i = 0; i < 4; i++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = user.Login;
                row.Cells[1].Value = user.UserFIO;
                row.Cells[2].Value = user.Address;
                row.Cells[3].Value = user.Phone;
                gridUsers.Rows.Add(row);
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var form = new AddUserForm();
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (gridUsers.SelectedRows.Count == 0) return;

            var user = gridUsers.SelectedRows[0].Tag as User;
            if (user == null) return;

            var form = new AddUserForm(user);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (gridUsers.SelectedRows.Count == 0) return;

            var user = gridUsers.SelectedRows[0].Tag as User;
            if (user == null) return;

            if (user.Login == "Admin")
            {
                MessageBox.Show("Невозможно удалить администратора!");
                return;
            }
            if (user.Login == Storage.CurrentUser.Login)
            {
                MessageBox.Show("Невозможно удалить активного пользователя!");
                return;
            }

            if (MessageBox.Show("Вы уверенны, что хотите удалить пользователя " + user.Login + "?", "Удаление пользователя", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _userRepository.Delete(user);
                LoadGrid();
            }
        }
    }
}