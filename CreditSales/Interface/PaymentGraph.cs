using System;
using System.Drawing;
using System.Windows.Forms;
using CreditSales.Data.Models;
using CreditSales.Data.Repository;

namespace CreditSales.Interface
{
    public partial class PaymentGraph : Form
    {
        private BaseRepository _baseRepository = new BaseRepository();
        private Base _baseInfo;

        public PaymentGraph()
        {
            InitializeComponent();
            toolTip.SetToolTip(tbFirstPayment, "Процент от суммы покупки для уплаты при покупке товара. Первоначальный взнос. По умолчанию.");
            toolTip.SetToolTip(tbMonths, "Количество месяцев рассрочки по погашению кредита (рассрочки). По умолчанию.");
            toolTip.SetToolTip(tbPercent, "Процентная ставка (годовых) за пользование коммерческим кредитом. По умолчанию.");
            toolTip.SetToolTip(cbPaymentDay, "День месяца, до которого необходимо вносить платёж. По умолчанию.");
            toolTip.SetToolTip(tbPenaltyPercent, "Процент пени за просрочку платежа (в сотых долях процента). По умолчанию.");
            toolTip.SetToolTip(cbRound, "Степень округления платежа по кредиту (рассрочке). Например, 0 - не округлять, 1 - округлять до рублей, 10 - до десятков рублей, 100 - до сотен рублей.");
            toolTip.SetToolTip(tbLastCreditNumber, "Последний номер договора. Автоматическая нумерация договоров продолжится с данного номера. Например, если номер последнего договора 10, номер следующего созданного будет 11.");
            toolTip.SetToolTip(btnSave, "Сохранить");

            _baseInfo = _baseRepository.GetBaseFinanceInfo();
            if (_baseInfo == null) return;

            tbFirstPayment.Text = _baseInfo.FirstPaymentPercent.ToString();
            tbPercent.Text = _baseInfo.PercentYear.ToString();
            tbPenaltyPercent.Text = _baseInfo.PercentPenalty.ToString();
            cbPaymentDay.SelectedItem = _baseInfo.DayPayment.ToString();
            tbMonths.Text = _baseInfo.Term.ToString();
            cbRound.SelectedItem = _baseInfo.Round.ToString();
            tbLastCreditNumber.Text = _baseInfo.LastCredit.ToString();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            decimal temp;
            foreach (var control in Controls)
            {
                if (control is TextBox)
                {
                    if ((string.IsNullOrEmpty((control as TextBox).Text)) || !decimal.TryParse((control as TextBox).Text.Replace('.', ','), out temp))
                    {
                        MessageBox.Show("Проверьте, все ли данные введены!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            _baseInfo.DayPayment = Convert.ToInt32(cbPaymentDay.SelectedItem.ToString());
            _baseInfo.PercentPenalty = Convert.ToDecimal(tbPenaltyPercent.Text.Replace('.', ','));
            _baseInfo.PercentYear = Convert.ToDecimal(tbPercent.Text.Replace('.', ','));
            _baseInfo.Term = Convert.ToInt32(tbMonths.Text);
            _baseInfo.FirstPaymentPercent = Convert.ToDecimal(tbFirstPayment.Text.Replace('.', ','));
            _baseInfo.Round = Convert.ToInt32(cbRound.Text.Replace('.',','));
            _baseInfo.LastCredit = Convert.ToInt32(tbLastCreditNumber.Text);
            _baseRepository.UpdateBaseFinanceInfo(_baseInfo);
            Close();
        }

        private void cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                e.DrawBackground();
                if (e.Index >= 0)
                {
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;
                    Brush brush = new SolidBrush(cbx.ForeColor);
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    {
                        brush = SystemBrushes.HighlightText;
                    }
                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }

        private void tbFirstPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }
    }
}