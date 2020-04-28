using System.Windows.Forms;
using CreditSales.Data.Models;
using CreditSales.Data.Repository;

namespace CreditSales.Interface
{
    public partial class AddUserForm : Form
    {
        private User _user;
        private UserRepository _userRepository = new UserRepository();

        public AddUserForm()
        {
            InitializeComponent();
            toolTip.SetToolTip(tbLogin, "Логин пользователя");
            toolTip.SetToolTip(tbPass, "Пароль пользователя");
            toolTip.SetToolTip(tbUser, "Фамилия, имя и отчество пользователя");
            toolTip.SetToolTip(tbUserAdr, "Адрес пользователя");
            toolTip.SetToolTip(tbUserPhone, "Телефон пользователя");
            toolTip.SetToolTip(cbAddCredit, "Разрешить (запретить) пользователю добавлять договора");
            toolTip.SetToolTip(cbEditCredit, "Разрешить (запретить) пользователю редактировать договора");
            toolTip.SetToolTip(cbDeleteCredit, "Разрешить (запретить) пользователю удалять договора");
            toolTip.SetToolTip(cbMainInfo, "Разрешить (запретить) пользователю доступ к информации о компании");
            toolTip.SetToolTip(cbProducts, "Разрешить (запретить) пользователю доступ к справочнику продуктов");
            toolTip.SetToolTip(cbSchedule, "Разрешить (запретить) пользователю доступ к графику платежей");
            toolTip.SetToolTip(cbUsers, "Разрешить (запретить) пользователю доступ к справочнику пользователей");
            toolTip.SetToolTip(cbBlackList, "Разрешить (запретить) пользователю доступ к чёрному списку клиентов");
            toolTip.SetToolTip(cbRegistration, "Разрешить (запретить) пользователю регистрацию программы");
            toolTip.SetToolTip(cbReportCredits, "Разрешить (запретить) пользователю доступ к отчётам о всех договорах");
            toolTip.SetToolTip(cbPayments, "Разрешить (запретить) пользователю доступ к платежам по кредитам");
            toolTip.SetToolTip(cbAwaitablePayments, "Разрешить (запретить) пользователю доступ к ожидаемым платежам");
            toolTip.SetToolTip(cbAddPayments, "Разрешить (запретить) пользователю добавлять платежи");
            toolTip.SetToolTip(cbPaymentsInfo, "Разрешить (запретить) пользователю удалять платежи");
            toolTip.SetToolTip(btnSave, "Сохранить");
            toolTip.SetToolTip(btnClose, "Отмена");
        }

        public AddUserForm(User user) : this()
        {
            _user = user;

            tbLogin.Text = user.Login;
            tbPass.Text = user.Password;
            tbUser.Text = user.Login;
            tbUserAdr.Text = user.Address;
            tbUserPhone.Text = user.Phone;

            cbAddCredit.Checked = user.Access[0] == '1';
            cbEditCredit.Checked = user.Access[1] == '1';
            cbDeleteCredit.Checked = user.Access[2] == '1';
            cbMainInfo.Checked = user.Access[3] == '1';
            cbProducts.Checked = user.Access[4] == '1';
            cbSchedule.Checked = user.Access[5] == '1';
            cbUsers.Checked = user.Access[6] == '1';
            cbBlackList.Checked = user.Access[7] == '1';
            cbRegistration.Checked = user.Access[8] == '1';
            cbReportCredits.Checked = user.Access[9] == '1';
            cbPayments.Checked = user.Access[10] == '1';
            cbAwaitablePayments.Checked = user.Access[11] == '1';
            cbAddPayments.Checked = user.Access[12] == '1';
            cbPaymentsInfo.Checked = user.Access[13] == '1';
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(tbPass.Text))
            {
                MessageBox.Show("Имя пользователя и пароль не могут быть пустыми!", "Введите данные!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_user == null) _user = new User();

            _user.Login = tbLogin.Text;
            _user.Password = tbPass.Text;
            _user.Address = tbUserAdr.Text;
            _user.Phone = tbUserPhone.Text;
            _user.UserFIO = tbUser.Text;

            string access = "";

            access += cbAddCredit.Checked ? "1" : "0";
            access += cbEditCredit.Checked ? "1" : "0";
            access += cbDeleteCredit.Checked ? "1" : "0";
            access += cbMainInfo.Checked ? "1" : "0";
            access += cbProducts.Checked ? "1" : "0";
            access += cbSchedule.Checked ? "1" : "0";
            access += cbUsers.Checked ? "1" : "0";
            access += cbBlackList.Checked ? "1" : "0";
            access += cbRegistration.Checked ? "1" : "0";
            access += cbReportCredits.Checked ? "1" : "0";
            access += cbPayments.Checked ? "1" : "0";
            access += cbAwaitablePayments.Checked ? "1" : "0";
            access += cbAddPayments.Checked ? "1" : "0";
            access += cbPaymentsInfo.Checked ? "1" : "0";

            _user.Access = access;

            _userRepository.AddOrUpdate(_user);
            Close();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}