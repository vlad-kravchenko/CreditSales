using System;
using System.Linq;
using System.Windows.Forms;
using CreditSales.Data.Models;
using CreditSales.Data.Repository;

namespace CreditSales.Interface
{
    public partial class DonePayment : Form
    {
        private ScheduleRepository _scheduleRepository = new ScheduleRepository();
        private PaymentRepository _paymentRepository = new PaymentRepository();
        private CreditRepository _creditRepository = new CreditRepository();
        private Credit _credit;

        public DonePayment()
        {
            InitializeComponent();
            toolTip.SetToolTip(datePayment, "Дата платежа");
            toolTip.SetToolTip(tbTotal, "Итоговая сумма платежа");
            toolTip.SetToolTip(btnSave, "Сохранить");
            toolTip.SetToolTip(btnClose, "Отмена");
        }

        public DonePayment(Credit credit) : this()
        {
            _credit = credit;

            label5.Text = "Договор №" + credit.Number + " от " + credit.Data.ToShortDateString();
            label6.Text = "Клиент: " + credit.ClientFIO + ", паспортные данные: " + credit.ClientDoc;
            label7.Text = "Адрес: " + credit.ClientAdr;
            label8.Text = "Телефон: " + credit.ClientPhone;

            var payments = _paymentRepository.GetPayments().Where(p => p.CreditId == credit.Id).ToList();
            var schedule = _scheduleRepository.GetPayments().Where(p => p.CreditId == credit.Id).ToList();
            decimal done = payments.Sum(p => p.PaymentAmount);

            tbDebt.Text = (credit.Total - credit.FirstPayment).ToString();
            tbPayments.Text = done.ToString();
            tbRest.Text = (credit.Total - credit.FirstPayment - done).ToString();
            tbPenalty.Text = "0";

            Schedule reccomendedPayment = null;
            var pastSchedule = schedule.Where(s => s.DatePayment < DateTime.Now).ToList();
            try
            {
                if (pastSchedule.Sum(s => s.PaymentAmount) > done)
                {
                    pastSchedule.ToList().Sort((x, y) => x.DatePayment.CompareTo(y.DatePayment));
                    reccomendedPayment = pastSchedule.Last();
                }
                else
                {
                    pastSchedule = schedule.Where(s => s.DatePayment >= DateTime.Now).ToList();
                    pastSchedule.Sort((x, y) => x.DatePayment.CompareTo(y.DatePayment));
                    reccomendedPayment = pastSchedule.First();
                }
            }
            catch
            {
                decimal sum = 0;
                schedule.ToList().Sort((x, y) => x.DatePayment.CompareTo(y.DatePayment));
                foreach (var pay in schedule)
                {
                    sum += pay.PaymentAmount;
                    if (sum > done)
                    {
                        reccomendedPayment = pay;
                        break;
                    }
                }
            }

            if (reccomendedPayment == null)
            {
                MessageBox.Show("Что-то пошло не так. Невозможно определить рекоммендуемый платёж!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            groupBox3.Text += " " + reccomendedPayment.Comment + " от " + reccomendedPayment.DatePayment.ToShortDateString();
            
            tbPaymentDebt.Text = reccomendedPayment.PaymentAmount.ToString("#.00");
            tbPaymentSumPercent.Text = reccomendedPayment.SumPercent.ToString("#.00");

            schedule = schedule.Where(s => s.DatePayment < DateTime.Now).ToList();
            schedule.Sort((x, y) => x.DatePayment.CompareTo(y.DatePayment));
            decimal penalty = 0;
            while (true)
            {
                if (schedule.Count == 0) break;

                int days = (DateTime.Now - schedule.Last().DatePayment).Days;
                decimal sum = schedule.Sum(s => s.PaymentAmount);
                penalty += sum / 100 / 100 * 5 * days;
                schedule.Remove(schedule.Last());
            }

            tbPaymentPenalty.Text = penalty.ToString("#.00");
            tbTotal.Text = (reccomendedPayment.PaymentAmount + reccomendedPayment.SumPercent + penalty).ToString("#.00");
            tbLeft.Text = (credit.Total - credit.FirstPayment - done - Convert.ToDecimal(tbPaymentDebt.Text.Replace('.', ','))).ToString("#.00");
        }

        private void tbTotal_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal canPay = Convert.ToDecimal(tbTotal.Text.Replace('.', ','));
                decimal perc = Convert.ToDecimal(tbPaymentSumPercent.Text.Replace('.', ','));
                decimal penalty = Convert.ToDecimal(tbPaymentPenalty.Text.Replace('.', ','));
                tbPaymentDebt.Text = (canPay - perc - penalty).ToString("#.00");

                tbLeft.Text = (_credit.Total - _credit.FirstPayment - Convert.ToDecimal(tbPayments.Text.Replace('.', ',')) - Convert.ToDecimal(tbPaymentDebt.Text.Replace('.', ','))).ToString();
            }
            catch
            {
                //nothing to do, wait for next user actions
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            decimal temp = 0;
            if (string.IsNullOrEmpty(tbTotal.Text) || !decimal.TryParse(tbTotal.Text, out temp))
            {
                MessageBox.Show("Введите итоговую суммму!", "Введите итоговую суммму!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbLeft.Text)) tbLeft.Text = "0";

            decimal left = Convert.ToDecimal(tbLeft.Text.Replace('.', ','));
            if (left < 0)
            {
                decimal offer = Convert.ToDecimal(tbTotal.Text.Replace('.', ',')) + left;
                MessageBox.Show("Внимание! Сумма погашения основного долга больше остатка по платежам! Рекомендуемый взнос: " + offer,
                    "Переплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTotal.Text = offer.ToString("#.00");
                tbLeft.Text = "0";
                return;
            }

            Payment payment = new Payment
            {
                CreditId = _credit.Id,
                DatePayment = datePayment.Value,
                SumPenalty = Convert.ToDecimal(tbPaymentPenalty.Text.Replace('.', ',')),
                SumPercent = Convert.ToDecimal(tbPaymentSumPercent.Text.Replace('.', ',')),
                PaymentAmount = Convert.ToDecimal(tbTotal.Text.Replace('.', ',')) - 
                                Convert.ToDecimal(tbPaymentPenalty.Text.Replace('.', ',')) - 
                                Convert.ToDecimal(tbPaymentSumPercent.Text.Replace('.', ','))
            };

            _paymentRepository.AddOrUpdate(payment);

            temp = 0;
            if (decimal.TryParse(tbLeft.Text, out temp))
            {
                if (temp <= 0)
                {
                    MessageBox.Show("Внимание! Ввиду погашения долга договор закрыт.", "Закрытие договора", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _creditRepository.CloseCredit(_credit.Id);
                }
            }
            else if (string.IsNullOrEmpty(tbLeft.Text))
            {
                MessageBox.Show("Внимание! Ввиду погашения долга договор закрыт.", "Закрытие договора", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                _creditRepository.CloseCredit(_credit.Id);
            }

            Close();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void tbTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }
    }
}