using CreditSales.Data;
using CreditSales.Data.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CreditSales.Data.Models;

namespace CreditSales
{
    public partial class LoginForm : Form
    {
        private UserRepository _userRepository = new UserRepository();
        private List<User> _users = new List<User>();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            _users = _userRepository.GetUsers();
            if (_users.Count > 0)
            {
                foreach (var user in _users)
                {
                    cbUsername.Items.Add(user.Login);
                }
            }
            else
            {
                MessageBox.Show("Не удаётся подключиться к базе данных или в ней отсутствуют пользователи!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbUsername.SelectedItem == null)
            {
                MessageBox.Show("Пользователь не выбран!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cbUsername.SelectedItem.ToString())) return;
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Введите пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string login = cbUsername.SelectedItem.ToString();
            string password = tbPassword.Text;

            foreach (var user in _users)
            {
                if (user.Login == login && user.Password == password)
                {
                    Storage.CurrentUser = user;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            if (DialogResult != DialogResult.OK)
            {
                DialogResult = DialogResult.No;
                MessageBox.Show("Ошибка аутентификации. Проверьте правильность введённых данных!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}