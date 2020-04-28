using CreditSales.Data.Models;
using CreditSales.Data.Repository;
using System;
using System.Windows.Forms;
using CreditSales.Data;

namespace CreditSales.Interface
{
    public partial class SchedulePayment : Form
    {
        private Schedule _currentPayment;

        public SchedulePayment()
        {
            InitializeComponent();
            toolTip.SetToolTip(btnSave, "Сохранить и закрыть");
            toolTip.SetToolTip(btnClose, "Закрыть без сохранения");
            toolTip.SetToolTip(datePayment, "Дата платежа");
            toolTip.SetToolTip(tbMustPay, "Сумма платежа в погашение основного долга");
            toolTip.SetToolTip(tbPercents, "Сумма уплачиваемых процентов");
            toolTip.SetToolTip(tbPayment, "Итоговая сумма взноса");
            toolTip.SetToolTip(tbComment, "Комментарий");
        }

        public SchedulePayment(Schedule currentPayment) : this()
        {
            _currentPayment = currentPayment;

            tbDebt.Text = currentPayment.Rest.ToString("#.00");
            tbMustPay.Text = currentPayment.PaymentAmount.ToString("#.00");
            tbPercents.Text = currentPayment.SumPercent.ToString("#.00");
            tbPayment.Text = currentPayment.SumTotal.ToString("#.00");
            tbComment.Text = currentPayment.Comment;
            datePayment.Value = currentPayment.DatePayment;
        }

        public SchedulePayment(decimal debt) : this()
        {
            tbDebt.Text = debt.ToString("#.00");
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(tbMustPay.Text) || string.IsNullOrEmpty(tbPayment.Text)) return;

            if (_currentPayment == null) _currentPayment = new Schedule();

            _currentPayment.Rest = string.IsNullOrEmpty(tbDebt.Text) ? 0 : Convert.ToDecimal(tbDebt.Text);
            _currentPayment.PaymentAmount = string.IsNullOrEmpty(tbMustPay.Text) ? 0 : Convert.ToDecimal(tbMustPay.Text);
            _currentPayment.SumPercent = string.IsNullOrEmpty(tbPercents.Text) ? 0 : Convert.ToDecimal(tbPercents.Text);
            _currentPayment.SumTotal = string.IsNullOrEmpty(tbPayment.Text) ? 0 : Convert.ToDecimal(tbPayment.Text);
            _currentPayment.Comment = tbComment.Text;
            _currentPayment.DatePayment = datePayment.Value;

            Storage.CreatedSchedulePayment = _currentPayment;
            Close();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Storage.CreatedSchedulePayment = null;
            Close();
        }

        private void tbMustPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }
    }
}