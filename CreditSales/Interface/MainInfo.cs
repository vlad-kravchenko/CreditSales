using CreditSales.Data.Repository;
using System.Windows.Forms;

namespace CreditSales.Interface
{
    public partial class MainInfo : Form
    {
        private Data.Models.MainInfo mainInfo;
        private MainInfoRepository _mainInfoRepository = new MainInfoRepository();

        public MainInfo()
        {
            InitializeComponent();
            toolTip.SetToolTip(tbCompany, "Название организации");
            toolTip.SetToolTip(tbINN, "ИНН налогоплательщика, выданный ФНС при регистрации. Указывается в реквизитах договора кредитования (рассрочки).");
            toolTip.SetToolTip(tbChief, "Продолжите фразу договора 'Продавец в лице ...'. Например: директора Иванова Ивана Ивановича ...");
            toolTip.SetToolTip(tbBank, "Банковские реквизиты");
            toolTip.SetToolTip(tbCity, "Населённый пункт. Указывается в договоре кредитования (рассрочки). Например: г. Москва");
            toolTip.SetToolTip(tbDoc, "Продолжите фразу договора кредитования (рассрочки платежей) 'действующего на основании ...'. Например: свидетельства, серия №22222...");
            toolTip.SetToolTip(tbUrAdr, "Юридический адрес организации");
            toolTip.SetToolTip(tbFactAdr, "Адрес торгового объекта");
            toolTip.SetToolTip(tbPhone, "Контактный телефон");
            toolTip.SetToolTip(btnSave, "Сохранить");

            mainInfo = _mainInfoRepository.GetMainInfo();
            if (mainInfo == null) return;

            tbINN.Text = mainInfo.INN;
            tbBank.Text = mainInfo.Bank;
            tbChief.Text = mainInfo.Chief;
            tbCity.Text = mainInfo.City;
            tbCompany.Text = mainInfo.Name;
            tbDoc.Text = mainInfo.Document;
            tbFactAdr.Text = mainInfo.OfficeAddress;
            tbUrAdr.Text = mainInfo.UridAddress;
            tbPhone.Text = mainInfo.Phone;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control is TextBox)
                {
                    if (string.IsNullOrEmpty((control as TextBox).Text))
                    {
                        MessageBox.Show("Проверьте, все ли данные введены!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (string.IsNullOrEmpty(tbBank.Text) || string.IsNullOrEmpty(tbUrAdr.Text) || string.IsNullOrEmpty(tbFactAdr.Text))
            {
                MessageBox.Show("Проверьте, все ли данные введены!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mainInfo.Phone = tbPhone.Text;
            mainInfo.UridAddress = tbUrAdr.Text;
            mainInfo.OfficeAddress = tbFactAdr.Text;
            mainInfo.Document = tbDoc.Text;
            mainInfo.Name = tbCompany.Text;
            mainInfo.City = tbCity.Text;
            mainInfo.Chief = tbChief.Text;
            mainInfo.Bank = tbBank.Text;
            mainInfo.INN = tbINN.Text;

            _mainInfoRepository.UpdateMainInfo(mainInfo);
            Close();
        }
    }
}