using CreditSales.Data.Repository;
using System;
using System.Windows.Forms;

namespace CreditSales.Interface
{
    public partial class ClientInfo : Form
    {
        private BlackListRepository _blackListRepository = new BlackListRepository();
        private Data.Models.BlackList _user;

        public ClientInfo()
        {
            InitializeComponent();
        }

        public ClientInfo(Data.Models.BlackList user) : this()
        {
            _user = user;

            tbPhone.Text = user.Phone;
            tbFIO.Text = user.Client;
            tbAdr.Text = user.Address;
            tbDoc.Text = user.Document;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_user == null) _user = new Data.Models.BlackList();
            if (string.IsNullOrEmpty(tbFIO.Text))
            {
                MessageBox.Show("Введите имя клиента!", "Введите имя клиента!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _user.Address = tbAdr.Text;
            _user.Phone = tbPhone.Text;
            _user.Document = tbDoc.Text;
            _user.Client = tbFIO.Text;

            _blackListRepository.AddOrUpdate(_user);

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}