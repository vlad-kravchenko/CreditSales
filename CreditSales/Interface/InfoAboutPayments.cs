using CreditSales.Data.Models;
using CreditSales.Data.Repository;
using System.Linq;
using System.Windows.Forms;

namespace CreditSales.Interface
{
    public partial class InfoAboutPayments : Form
    {
        private SoldProductsRepository _productRepository = new SoldProductsRepository();
        private ScheduleRepository _scheduleRepository = new ScheduleRepository();
        private PaymentRepository _paymentRepository = new PaymentRepository();
        private Credit _currentCredit;

        public InfoAboutPayments()
        {
            InitializeComponent();
            toolTip.SetToolTip(btnAddPayment, "Добавить платёж");
            toolTip.SetToolTip(btnDeletePayment, "Удалить платёж");
            toolTip.SetToolTip(btnOK, "Закрыть окно");
        }

        public InfoAboutPayments(Credit currentCredit) : this()
        {
            _currentCredit = currentCredit;

            LoadMainInfo();
            LoadProducts();
            LoadSchedule();
            LoadPayments();
        }

        private void LoadPayments()
        {
            var payments = _paymentRepository.GetPayments().Where(p => p.CreditId == _currentCredit.Id).ToList();
            foreach (var pay in payments)
            {
                var row = new DataGridViewRow();
                row.Tag = pay;
                for (int j = 0; j < 5; j++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = pay.DatePayment.ToShortDateString();
                row.Cells[1].Value = pay.PaymentAmount.ToString("#.00");
                row.Cells[2].Value = pay.SumPercent.ToString("#.00");
                row.Cells[3].Value = pay.SumPenalty.ToString("#.00");
                row.Cells[4].Value = (pay.PaymentAmount + pay.SumPercent + pay.SumPenalty).ToString("#.00");
                gridPayments.Rows.Add(row);
            }

            tbCurrentDebt.Text = (_currentCredit.Total - _currentCredit.FirstPayment - payments.Sum(p => p.PaymentAmount)).ToString("#.00");
            tbFinished.Text = payments.Sum(p => p.PaymentAmount).ToString("#.00");
            tbPercentFinished.Text = payments.Sum(p => p.SumPercent).ToString("#.00");
            tbCurrentPenalty.Text = payments.Sum(p => p.SumPenalty).ToString("#.00");
            tbTotal.Text = (payments.Sum(p => p.PaymentAmount) + payments.Sum(p => p.SumPercent) + payments.Sum(p => p.SumPenalty)).ToString("#.00");
        }

        private void LoadSchedule()
        {
            var schedule = _scheduleRepository.GetPayments().Where(p => p.CreditId == _currentCredit.Id).ToList();
            foreach (var pay in schedule)
            {
                var row = new DataGridViewRow();
                row.Tag = pay;
                for (int j = 0; j < 5; j++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = pay.DatePayment.ToShortDateString();
                row.Cells[1].Value = pay.PaymentAmount.ToString("#.00");
                row.Cells[2].Value = pay.SumPercent.ToString("#.00");
                row.Cells[3].Value = pay.SumTotal.ToString("#.00");
                row.Cells[4].Value = pay.Comment;
                gridSchedule.Rows.Add(row);
            }

            tbFirstPayment.Text = _currentCredit.FirstPayment.ToString("#.00");
            tbDebt.Text = (_currentCredit.Total - _currentCredit.FirstPayment).ToString("#.00");
            tbPercent.Text = schedule.Sum(s => s.SumPercent).ToString("#.00");
            tbTotalSumPayments.Text = (_currentCredit.Total - _currentCredit.FirstPayment + schedule.Sum(s => s.SumPercent)).ToString("#.00");
        }

        private void LoadProducts()
        {
            foreach (var prod in _productRepository.GetSoldProducts().Where(p => p.CreditId == _currentCredit.Id))
            {
                var row = new DataGridViewRow();
                row.Tag = prod;
                for (int i = 0; i < 5; i++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = prod.Name;
                row.Cells[1].Value = prod.Price.ToString("#.00");
                row.Cells[2].Value = prod.AddAmount.ToString("#.00");
                row.Cells[3].Value = prod.Discount.ToString("#.00");
                row.Cells[4].Value = prod.Total.ToString("#.00");
                gridProducts.Rows.Add(row);
            }

            tbTotalSum.Text = _currentCredit.TotalClean.ToString("#.00");
            tbTotalAdd.Text = _currentCredit.AddPercent.ToString("#.00");
            tbTotalDiscount.Text = _currentCredit.DiscPercent.ToString("#.00");
            tbTotalPrice.Text = _currentCredit.Total.ToString("#.00");
        }

        private void LoadMainInfo()
        {
            tbCreditNumber.Text = _currentCredit.Number.ToString();
            tbCreditDate.Text = _currentCredit.Data.ToShortDateString();
            tbCreditClientPhone.Text = _currentCredit.ClientPhone;
            tbCreditClient.Text = _currentCredit.ClientFIO;
            tbCreditClientAdr.Text = _currentCredit.ClientAdr;
            tbCreditClientDoc.Text = _currentCredit.ClientDoc;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnAddPayment_Click(object sender, System.EventArgs e)
        {
            var form = new DonePayment(_currentCredit);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                gridPayments.Rows.Clear();
                LoadPayments();
            }
        }

        private void btnDeletePayment_Click(object sender, System.EventArgs e)
        {
            if (gridPayments.SelectedRows.Count == 0) return;
            Payment currentPayment = gridPayments.SelectedRows[0].Tag as Payment;
            if (currentPayment == null) return;

            if (MessageBox.Show("Вы уверенны, что хотите удалить платёж от " + currentPayment.DatePayment.ToShortDateString() + "?", "Удаление платежа", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _paymentRepository.Delete(currentPayment);
                gridPayments.Rows.Clear();
                LoadPayments();
            }
        }
    }
}