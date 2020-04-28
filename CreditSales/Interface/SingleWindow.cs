using CreditSales.Data;
using CreditSales.Data.Models;
using CreditSales.Data.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CreditSales.Tools;

namespace CreditSales.Interface
{
    public partial class SingleWindow : Form
    {
        private CreditRepository _creditRepository = new CreditRepository();
        private BlackListRepository _blackListRepository = new BlackListRepository();
        private PaymentRepository _paymentRepository = new PaymentRepository();
        private ScheduleRepository _scheduleRepository = new ScheduleRepository();
        private BaseRepository _baseRepository = new BaseRepository();
        private MainInfoRepository _mainInfoRepository = new MainInfoRepository();
        private SoldProductsRepository _soldProductsRepository = new SoldProductsRepository();
        private ProductRepository _productRepository = new ProductRepository();

        private Data.Models.MainInfo _mainInfo;
        private Base _base;

        private RichTextBox _richTextBox = new RichTextBox();

        public List<Credit> Credits { get; set; }
        public Credit CurrentCredit { get; set; }

        public DataGridView CreditsGrid { get { return creditsGrid; } }
        public TabControl Tab { get { return tabControl1; } }

        public SingleWindow()
        {
            InitializeComponent();
            toolTip.SetToolTip(tbCreditNumber, "Можете указать для поиска номер договора кредита. Возможна комбинация критериев поиска.");
            toolTip.SetToolTip(cbClient, "Можете указать или выбрать для поиска Ф.И.О. клиента. Возможна комбинация критериев поиска.");
            toolTip.SetToolTip(cbConsult, "Можете указать или выбрать для поиска Ф.И.О. сотрудника, выдавшего кредит. Возможна комбинация критериев поиска.");
            toolTip.SetToolTip(cbActive, "Искать только непогашенные договора.");
            toolTip.SetToolTip(cbDebts, "Искать только среди кредитов с задолженостью на данный момент.");
            toolTip.SetToolTip(btnSearch, "Искать");
            toolTip.SetToolTip(btnShowAll, "Показать все договоры");

            LoadGrid();
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(creditsPage);
            _base = _baseRepository.GetBaseFinanceInfo();
            _mainInfo = _mainInfoRepository.GetMainInfo();
            if (_base == null || _mainInfo == null)
            {
                MessageBox.Show("Не удалось получить базовую информацию. Проверьте подключение к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadGrid(List<Credit> credits = null)
        {
            List<string> cli = new List<string>();
            List<string> cons = new List<string>();

            if (credits == null) credits = _creditRepository.GetCredits().ToList();
            Credits = credits;
            creditsGrid.Rows.Clear();
            foreach (var credit in credits)
            {
                DisplayCredit(credit);
            }

            foreach (var credit in _creditRepository.GetCredits())
            {
                cli.Add(credit.ClientFIO);
                cons.Add(credit.Consult);
            }
            cbConsult.Items.Clear();
            cbClient.Items.Clear();
            cli = cli.Distinct().ToList();
            cons = cons.Distinct().ToList();
            cli.ForEach(c => cbClient.Items.Add(c));
            cons.ForEach(c => cbConsult.Items.Add(c));
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverRow = creditsGrid.HitTest(e.X, e.Y).RowIndex;
                    CurrentCredit = creditsGrid.Rows[currentMouseOverRow].Tag as Credit;
                    if (CurrentCredit != null)
                    {
                        gridContextMenu.Show(creditsGrid, e.Location);
                    }
                }
            }
            catch
            {
                //nothing to do, wait for the next user actions
            }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            creditsGrid.Rows.Clear();
            Credits = _creditRepository.GetCredits().Where(c => c.Data >= date1.Value && c.Data <= date2.Value).ToList();
            if (cbActive.Checked)
            {
                Credits = Credits.Where(c => c.IsActive).ToList();
            }
            List<Credit> next = new List<Credit>();
            if (cbDebts.Checked)
            {
                foreach (var credit in Credits)
                {
                    var payments = _paymentRepository.GetPayments().Where(p => p.CreditId == credit.Id).ToList();
                    var schedule = _scheduleRepository.GetPayments().Where(p => p.CreditId == credit.Id && p.DatePayment < DateTime.Now).ToList();
                    decimal done = 0;
                    payments.ForEach(p =>
                    {
                        done += p.PaymentAmount;
                    });
                    decimal mustPayAlready = 0;
                    schedule.ForEach(s => { mustPayAlready += s.PaymentAmount; });
                    if (done < mustPayAlready) next.Add(credit);
                }
            }
            else
            {
                next = Credits;
            }

            if (!string.IsNullOrEmpty(tbCreditNumber.Text))
            {
                next = next.Where(c => c.Number == Convert.ToInt32(tbCreditNumber.Text)).ToList();
            }
            if (!string.IsNullOrEmpty(cbClient.Text))
            {
                next = next.Where(c => c.ClientFIO == cbClient.Text).ToList();
            }
            if (!string.IsNullOrEmpty(cbConsult.Text))
            {
                next = next.Where(c => c.Consult == cbConsult.Text).ToList();
            }
            LoadGrid(next);
        }

        private void menuStripNew_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[0] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_productRepository.GetProducts().Count == 0)
            {
                MessageBox.Show("В базе данных отсутствуют товары!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = new CreditForm();
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void menuStripEdit_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[1] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CurrentCredit == null) return;

            var form = new CreditForm(CurrentCredit);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void menuStripDelete_Click(object sender, System.EventArgs e)
        {
            if (Storage.CurrentUser.Access[2] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CurrentCredit == null) return;

            if (MessageBox.Show("Вы уверенны, что хотите удалить договор №" + CurrentCredit.Number + 
                                " и все связанные данные?", "Удаление договора", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _creditRepository.Delete(CurrentCredit);
                LoadGrid();
            }
        }

        private void menuStripAdd_Click(object sender, System.EventArgs e)
        {
            if (Storage.CurrentUser.Access[12] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CurrentCredit == null) return;

            if (!CurrentCredit.IsActive)
            {
                MessageBox.Show("Данный договор уже закрыт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new DonePayment(CurrentCredit);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void menuStripInfo_Click(object sender, System.EventArgs e)
        {
            if (Storage.CurrentUser.Access[13] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CurrentCredit == null) return;

            var form = new InfoAboutPayments(CurrentCredit);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void menuStripAddToBlackList_Click(object sender, System.EventArgs e)
        {
            if (Storage.CurrentUser.Access[7] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CurrentCredit == null) return;

            _blackListRepository.AddToBlackListFromCredit(CurrentCredit);
        }

        private void SingleWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                (MdiParent as MainForm).DeleteMenuItem(Text);
            }
            catch
            {
                MessageBox.Show("Не удаётся закрыть окно. Пожалуйста, попробуйте ещё раз.", "Ошибка закрытия окна", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DisplayAllCreidts()
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(creditsPage);
        }

        public void DisplayPayments()
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(paymentsPage);

            var payments = _paymentRepository.GetPayments();
            payments.ToList().Sort((x, y) => x.DatePayment.CompareTo(y.DatePayment));
            payments.Reverse();
            paymentsGrid.Rows.Clear();
            foreach (var pay in payments)
            {
                var credit = Credits.FirstOrDefault(c => c.Id == pay.CreditId);
                if (credit == null) continue;
                var row = new DataGridViewRow();
                row.Tag = pay;
                for (int i = 0; i < 10; i++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = pay.DatePayment.ToShortDateString();
                row.Cells[1].Value = pay.Id;
                row.Cells[2].Value = credit.Data.ToShortDateString();
                row.Cells[3].Value = credit.Number;
                row.Cells[4].Value = credit.ClientFIO;
                row.Cells[5].Value = credit.Consult;
                row.Cells[6].Value = pay.PaymentAmount;
                row.Cells[7].Value = pay.SumPercent;
                row.Cells[8].Value = pay.SumPenalty;
                row.Cells[9].Value = pay.PaymentAmount + pay.SumPercent + pay.SumPenalty;
                paymentsGrid.Rows.Add(row);
            }
        }

        public void DisplayAwaitablePayments()
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(awaitablePage);

            var payments = _scheduleRepository.GetPayments();
            payments.ToList().Sort((x, y) => x.DatePayment.CompareTo(y.DatePayment));
            payments.Reverse();
            awaitableGrid.Rows.Clear();
            foreach (var pay in payments)
            {
                var credit = Credits.FirstOrDefault(c => c.Id == pay.CreditId);
                if (credit == null) continue;
                var row = new DataGridViewRow();
                row.Tag = pay;
                for (int i = 0; i < 7; i++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = pay.DatePayment.ToShortDateString();
                row.Cells[1].Value = pay.Id;
                row.Cells[2].Value = credit.Data.ToShortDateString();
                row.Cells[3].Value = credit.Number;
                row.Cells[4].Value = credit.ClientFIO;
                row.Cells[5].Value = credit.Consult;
                row.Cells[6].Value = pay.PaymentAmount + pay.SumPercent;
                awaitableGrid.Rows.Add(row);
            }
        }

        private void btnFilterPayments_Click(object sender, EventArgs e)
        {
            var payments = _paymentRepository.GetPayments().Where(c => c.DatePayment > date1Payments.Value && c.DatePayment < date2Payments.Value).ToList();
            payments.ToList().Sort((x, y) => x.DatePayment.CompareTo(y.DatePayment));
            payments.Reverse();
            paymentsGrid.Rows.Clear();
            foreach (var pay in payments)
            {
                var credit = Credits.FirstOrDefault(c => c.Id == pay.CreditId);
                if (credit == null) continue;
                var row = new DataGridViewRow();
                row.Tag = pay;
                for (int i = 0; i < 10; i++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = pay.DatePayment.ToShortDateString();
                row.Cells[1].Value = pay.Id;
                row.Cells[2].Value = credit.Data.ToShortDateString();
                row.Cells[3].Value = credit.Number;
                row.Cells[4].Value = credit.ClientFIO;
                row.Cells[5].Value = credit.Consult;
                row.Cells[6].Value = pay.PaymentAmount;
                row.Cells[7].Value = pay.SumPercent;
                row.Cells[8].Value = pay.SumPenalty;
                row.Cells[9].Value = pay.PaymentAmount + pay.SumPercent + pay.SumPenalty;
                paymentsGrid.Rows.Add(row);
            }
        }

        private void btnFilterAwaitablePayments_Click(object sender, EventArgs e)
        {
            var payments = _scheduleRepository.GetPayments().Where(c => c.DatePayment.Date == dateAwaitablePayments.Value.Date).ToList();
            payments.ToList().Sort((x, y) => x.DatePayment.CompareTo(y.DatePayment));
            payments.Reverse();
            awaitableGrid.Rows.Clear();
            foreach (var pay in payments)
            {
                var credit = Credits.FirstOrDefault(c => c.Id == pay.CreditId);
                if (credit == null) continue;
                var row = new DataGridViewRow();
                row.Tag = pay;
                for (int i = 0; i < 7; i++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = pay.DatePayment.ToShortDateString();
                row.Cells[1].Value = pay.Id;
                row.Cells[2].Value = credit.Data.ToShortDateString();
                row.Cells[3].Value = credit.Number;
                row.Cells[4].Value = credit.ClientFIO;
                row.Cells[5].Value = credit.Consult;
                row.Cells[6].Value = pay.PaymentAmount + pay.SumPercent;
                awaitableGrid.Rows.Add(row);
            }
        }

        private void menuStripClose_Click(object sender, EventArgs e)
        {
            if (CurrentCredit == null) return;
            decimal done = _paymentRepository.GetPayments().Where(p => p.CreditId == CurrentCredit.Id).Sum(p => p.PaymentAmount);
            if (done >= CurrentCredit.Total - CurrentCredit.FirstPayment)
            {
                _creditRepository.CloseCredit(CurrentCredit.Id);
                LoadGrid();
            }
            else
            {
                MessageBox.Show("По этому договору долг ещё не погашен!", "Невозможно закрыть договор", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void menuStripReopen_Click(object sender, EventArgs e)
        {
            if (CurrentCredit == null) return;
            if (!CurrentCredit.IsActive)
            {
                _creditRepository.ReopenCredit(CurrentCredit.Id);
                MessageBox.Show("Внимание! Вы переоткрыли уже закрытый договор. Проверьте платежи и долг по нему!", "Необходима проверка!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LoadGrid();
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            Credits = _creditRepository.GetCredits().ToList();
            creditsGrid.Rows.Clear();
            foreach (var credit in Credits)
            {
                DisplayCredit(credit);
            }
        }

        private void DisplayCredit(Credit credit)
        {
            var payments = _paymentRepository.GetPayments().Where(p => p.CreditId == credit.Id).ToList();
            var schedule = _scheduleRepository.GetPayments().Where(p => p.CreditId == credit.Id && p.DatePayment < DateTime.Now).ToList();
            decimal done = 0, donePercents = 0;
            payments.ForEach(p =>
            {
                done += p.PaymentAmount;
                donePercents += p.SumPercent;
            });

            decimal mustPayAlready = 0, debt = 0;
            schedule.ForEach(s => { mustPayAlready += s.PaymentAmount; });
            if (done < mustPayAlready) debt = mustPayAlready - done;

            var row = new DataGridViewRow();
            row.Tag = credit;
            for (int i = 0; i < 12; i++) row.Cells.Add(new DataGridViewTextBoxCell());
            row.Cells[0].Value = credit.Number;
            row.Cells[1].Value = credit.Data.ToShortDateString();
            row.Cells[2].Value = credit.ClientFIO;
            row.Cells[3].Value = credit.ClientAdr;
            row.Cells[4].Value = credit.ClientPhone;
            row.Cells[5].Value = credit.Consult;
            row.Cells[6].Value = credit.Total;
            row.Cells[7].Value = done + credit.FirstPayment;
            row.Cells[8].Value = donePercents;
            row.Cells[9].Value = credit.Total - credit.FirstPayment - done;
            if (debt > (decimal)0.02) row.Cells[10].Value = debt;

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

            penalty -= payments.Sum(p => p.SumPenalty);
            if (penalty > (decimal) 0.01)
            {
                row.DefaultCellStyle.BackColor = Color.AntiqueWhite;
            }
            if (!credit.IsActive)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }

            if (penalty > 0) row.Cells[11].Value = penalty.ToString("#.00");
            creditsGrid.Rows.Add(row);
        }

        private void tbCreditNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        #region Print

        private void menuStripPrintDoc_Click(object sender, System.EventArgs e)
        {
            PrintAgreement();
        }

        private void menuStripPrintGraph_Click(object sender, System.EventArgs e)
        {
            PrintSchedule();
        }

        private void menuStripPrintPlat_Click(object sender, System.EventArgs e)
        {
            PrintPayments();
        }

        public void PrintAgreement()
        {
            string target = "Договор №" + CurrentCredit.Number + ".doc";

            try
            {
                _richTextBox.LoadFile(Storage.AgreementTemplateFile, RichTextBoxStreamType.RichText);
            }
            catch (IOException)
            {
                MessageBox.Show("Не удалось найти файл шаблона или он занят другим процессом!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Replace("#nomer#", CurrentCredit.Number.ToString());
            Replace("#gorod#", _mainInfo.City);
            Replace("#data#", CurrentCredit.Data.ToShortDateString());
            Replace("#nameOrg#", _mainInfo.Name);
            Replace("#ruk#", _mainInfo.Chief);
            Replace("#osn#", _mainInfo.Document);
            Replace("#nameKlient#", CurrentCredit.ClientFIO);
            Replace("#docum#", CurrentCredit.ClientDoc);
            //tableProducts
            string final = string.Empty;
            if (CurrentCredit.AddPercent != 0 && CurrentCredit.DiscPercent != 0)
            {
                final = "Цена товара(ов) с учетом скидки в размере " + CurrentCredit.DiscPercent + "% и надбавки в размере " + CurrentCredit.AddPercent + "% составит " + CurrentCredit.Total + "руб.";
            }
            else if (CurrentCredit.AddPercent == 0 && CurrentCredit.DiscPercent != 0)
            {
                final = "Цена товара(ов) с учетом скидки в размере " + CurrentCredit.DiscPercent + "% составит " + CurrentCredit.Total + "руб.";
            }
            else if (CurrentCredit.AddPercent != 0 && CurrentCredit.DiscPercent == 0)
            {
                final = "Цена товара(ов) с учетом надбавки в размере " + CurrentCredit.AddPercent + "% составит " + CurrentCredit.Total + "руб.";
            }
            else
            {
                final = "";
            }
            Replace("#withadddisc#", final);
            Replace("#firstsumma#", CurrentCredit.FirstPayment.ToString() + " (" + RusCurrency.Str(Convert.ToDouble(CurrentCredit.FirstPayment)) + ")");
            Replace("#summalost#", (CurrentCredit.Total - CurrentCredit.FirstPayment).ToString() + " (" + RusCurrency.Str(Convert.ToDouble(CurrentCredit.Total - CurrentCredit.FirstPayment)) + ")");
            Replace("#adres#", _mainInfo.OfficeAddress);
            Replace("#prgod#", CurrentCredit.PercentYear.ToString());
            Replace("#peni#", _base.PercentPenalty.ToString());
            //tableSchedule
            var payments = _scheduleRepository.GetPayments().Where(p => p.CreditId == CurrentCredit.Id);
            Replace("#itogvznos#", payments.Sum(p => p.PaymentAmount).ToString());
            Replace("#itogpr#", payments.Sum(p => p.SumPercent).ToString());
            Replace("#itogsumma#", payments.Sum(p => p.SumTotal).ToString());
            Replace("#orgName#", _mainInfo.Name);
            Replace("#inn#", _mainInfo.INN);
            Replace("#street#", _mainInfo.UridAddress);
            Replace("#bank#", _mainInfo.Bank);
            Replace("#orgtel#", _mainInfo.Phone);
            Replace("#klientName#", CurrentCredit.ClientFIO);
            Replace("#pokadres#", CurrentCredit.ClientAdr);
            Replace("#poktel#", CurrentCredit.ClientPhone);

            _richTextBox.SaveFile(target);

            var soldProducts = _soldProductsRepository.GetSoldProducts().Where(p => p.CreditId == CurrentCredit.Id);
            StringBuilder sb = new StringBuilder();
            foreach (var prod in soldProducts)
            {
                sb.Append(@"{\rtf1\ansi\deff0 ");
                sb.Append(@"\trowd");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx6485 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx9562 ");
                sb.Append(ToRtf(prod.Name + @"\cell"));
                sb.Append(" " + prod.Total.ToString() + " (" + ToRtf(RusCurrency.Str(Convert.ToDouble(prod.Total)) + @")\cell"));
                sb.Append(@"}");
                sb.Append(@"\row ");
            }
            string str = File.ReadAllText(target);
            str = str.Replace("#tableProducts#", sb.ToString());
            File.WriteAllText(target, str);

            var schedule = _scheduleRepository.GetPayments().Where(p => p.CreditId == CurrentCredit.Id);
            sb = new StringBuilder();
            foreach (var pay in schedule)
            {
                sb.Append(@"{\rtf1\ansi\deff0 ");
                sb.Append(@"\trowd\qr");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx1650 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx3310 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx4972 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx6632 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx8293 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx9955 ");
                sb.Append(" " + pay.DatePayment.ToShortDateString() + @"\cell");
                sb.Append(" " + pay.Rest + @"\cell");
                sb.Append(" " + pay.PaymentAmount + @"\cell");
                sb.Append(" " + pay.SumPercent + @"\cell");
                sb.Append(" " + pay.SumTotal + @"\cell");
                sb.Append(" " + ToRtf(pay.Comment + @"\cell"));
                sb.Append(@"}");
                sb.Append(@"\row ");
            }

            str = File.ReadAllText(target);
            str = str.Replace("#tableSchedule#", sb.ToString());
            File.WriteAllText(target, str);

            MessageBox.Show("Формирование отчёта MS Word (.doc) по договору завершено!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void PrintSchedule()
        {
            string target = "График платежей для договора №" + CurrentCredit.Number + ".doc";

            try
            {
                _richTextBox.LoadFile(Storage.ScheduleTemplateFile, RichTextBoxStreamType.RichText);
            }
            catch (IOException)
            {
                MessageBox.Show("Не удалось найти файл шаблона или он занят другим процессом!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Replace("#nomer#", CurrentCredit.Number.ToString());
            Replace("#data#", CurrentCredit.Data.ToShortDateString());
            Replace("#fio#", CurrentCredit.ClientFIO);
            Replace("#adres#", CurrentCredit.ClientAdr);
            Replace("#docum#", CurrentCredit.ClientDoc);
            //tableProducts
            string final = string.Empty;
            if (CurrentCredit.AddPercent != 0 && CurrentCredit.DiscPercent != 0)
            {
                final = "Цена товара(ов) с учетом скидки в размере " + CurrentCredit.DiscPercent + "% и надбавки в размере " + CurrentCredit.AddPercent + "% составит " + CurrentCredit.Total + "руб.";
            }
            else if (CurrentCredit.AddPercent == 0 && CurrentCredit.DiscPercent != 0)
            {
                final = "Цена товара(ов) с учетом скидки в размере " + CurrentCredit.DiscPercent + "% составит " + CurrentCredit.Total + "руб.";
            }
            else if (CurrentCredit.AddPercent != 0 && CurrentCredit.DiscPercent == 0)
            {
                final = "Цена товара(ов) с учетом надбавки в размере " + CurrentCredit.AddPercent + "% составит " + CurrentCredit.Total + "руб.";
            }
            else
            {
                final = "";
            }
            Replace("#withadddisc#", final);
            var soldProducts = _soldProductsRepository.GetSoldProducts().Where(p => p.CreditId == CurrentCredit.Id);
            Replace("#titog#", soldProducts.Sum(p => p.Total).ToString());
            Replace("#firstsumma#", CurrentCredit.FirstPayment.ToString());
            Replace("#lastsumma#", (CurrentCredit.Total - CurrentCredit.FirstPayment).ToString());
            var payments = _scheduleRepository.GetPayments().Where(p => p.CreditId == CurrentCredit.Id);
            //tableSchedule
            Replace("#itogvznos#", payments.Sum(p => p.PaymentAmount).ToString());
            Replace("#itogpr#", payments.Sum(p => p.SumPercent).ToString());
            Replace("#itogsumma#", payments.Sum(p => p.SumTotal).ToString());
            Replace("#prodav#", CurrentCredit.Consult);
            Replace("#curdata#", DateTime.Today.ToShortDateString());
            
            _richTextBox.SaveFile(target);

            StringBuilder sb = new StringBuilder();
            foreach (var prod in soldProducts)
            {
                sb.Append(@"{\rtf1\ansi\deff0 ");
                sb.Append(@"\trowd");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx6485 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx9562 ");
                sb.Append(ToRtf(prod.Name + @"\cell"));
                sb.Append(" " + prod.Total.ToString() + " (" + ToRtf(RusCurrency.Str(Convert.ToDouble(prod.Total)) + @")\cell"));
                sb.Append(@"}");
                sb.Append(@"\row ");
            }
            string str = File.ReadAllText(target);
            str = str.Replace("#tableProducts#", sb.ToString());
            File.WriteAllText(target, str);

            var schedule = _scheduleRepository.GetPayments().Where(p => p.CreditId == CurrentCredit.Id);
            sb = new StringBuilder();
            foreach (var pay in schedule)
            {
                sb.Append(@"{\rtf1\ansi\deff0 ");
                sb.Append(@"\trowd\qr");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx1650 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx3310 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx4972 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx6632 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx8293 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx9955 ");
                sb.Append(" " + pay.DatePayment.ToShortDateString() + @"\cell");
                sb.Append(" " + pay.Rest + @"\cell");
                sb.Append(" " + pay.PaymentAmount + @"\cell");
                sb.Append(" " + pay.SumPercent + @"\cell");
                sb.Append(" " + pay.SumTotal + @"\cell");
                sb.Append(" " + ToRtf(pay.Comment + @"\cell"));
                sb.Append(@"}");
                sb.Append(@"\row ");
            }

            str = File.ReadAllText(target);
            str = str.Replace("#tableSchedule#", sb.ToString());
            File.WriteAllText(target, str);

            MessageBox.Show("Формирование отчёта MS Word (.doc) по графику платежей завершено!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void PrintPayments()
        {
            string target = "Сведения о платежах для договора №" + CurrentCredit.Number + ".doc";

            try
            {
                _richTextBox.LoadFile(Storage.PaymentsTemplateFile, RichTextBoxStreamType.RichText);
            }
            catch (IOException)
            {
                MessageBox.Show("Не удалось найти файл шаблона или он занят другим процессом!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Replace("#dognomer#", CurrentCredit.Number.ToString());
            Replace("#dogdata#", CurrentCredit.Data.ToShortDateString());
            Replace("#pokfio#", CurrentCredit.ClientFIO);
            Replace("#pokadres#", CurrentCredit.ClientAdr);
            Replace("#pokdok#", CurrentCredit.ClientDoc);
            Replace("#poktel#", CurrentCredit.ClientPhone);
            Replace("#alltovarsumma#", CurrentCredit.Total.ToString() + " (" + RusCurrency.Str(Convert.ToDouble(CurrentCredit.Total)) + ")");//
            Replace("#pradd#", CurrentCredit.AddPercent.ToString());
            Replace("#prmin#", CurrentCredit.DiscPercent.ToString());
            Replace("#firstsumma#", CurrentCredit.FirstPayment.ToString() + " (" + RusCurrency.Str(Convert.ToDouble(CurrentCredit.FirstPayment)) + ")");//
            Replace("#summalost#", (CurrentCredit.Total - CurrentCredit.FirstPayment).ToString() + " (" + RusCurrency.Str(Convert.ToDouble(CurrentCredit.Total - CurrentCredit.FirstPayment)) + ")");//
            Replace("#prgod#", CurrentCredit.PercentYear.ToString());
            var payments = _paymentRepository.GetPayments().Where(p => p.CreditId == CurrentCredit.Id);
            //tablePayments
            Replace("#ivsumma#", payments.Sum(p => p.PaymentAmount).ToString());
            Replace("#ivproch#", payments.Sum(p => p.SumPercent).ToString());
            Replace("#ivpeni#", payments.Sum(p => p.SumPenalty).ToString());
            Replace("#ivitog#",
                (payments.Sum(p => p.PaymentAmount) + payments.Sum(p => p.SumPercent) + payments.Sum(p => p.SumPenalty))
                .ToString());
            Replace("#lost#", (CurrentCredit.Total - CurrentCredit.FirstPayment - payments.Sum(p => p.PaymentAmount)).ToString() + " (" + RusCurrency.Str(Convert.ToDouble((CurrentCredit.Total - CurrentCredit.FirstPayment - payments.Sum(p => p.PaymentAmount)))) + ")");
            var schedule = _scheduleRepository.GetPayments().Where(p => p.CreditId == CurrentCredit.Id && p.DatePayment < DateTime.Now).ToList();
            decimal penalty = 0;
            while (true)
            {
                if (schedule.Count == 0) break;

                int days = (DateTime.Now - schedule.Last().DatePayment).Days;
                decimal sum = schedule.Sum(s => s.PaymentAmount);
                penalty += sum / 100 / 100 * 5 * days;
                schedule.Remove(schedule.Last());
            }
            penalty -= payments.Sum(p => p.SumPenalty);
            Replace("#curpeni#", penalty.ToString() + " (" + RusCurrency.Str(Convert.ToDouble(penalty)) + ")");
            Replace("#curdata#", DateTime.Today.ToShortDateString());
            
            _richTextBox.SaveFile(target);

            StringBuilder sb = new StringBuilder();
            foreach (var pay in payments)
            {
                sb.Append(@"{\rtf1\ansi\deff0 ");
                sb.Append(@"\trowd\qr");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx1916 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx3851 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx5771 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx7706 ");
                sb.Append(@"\clbrdrt\brdrs\clbrdrl\brdrs\clbrdrb\brdrs\clbrdrr\brdrs\cellx9627 ");
                sb.Append(" " + pay.DatePayment.ToShortDateString() + @"\cell");
                sb.Append(" " + pay.PaymentAmount + @"\cell");
                sb.Append(" " + pay.SumPercent + @"\cell");
                sb.Append(" " + pay.SumPenalty + @"\cell");
                sb.Append(" " + (pay.PaymentAmount + pay.SumPercent + pay.SumPenalty).ToString() + @"\cell");
                sb.Append(@"}");
                sb.Append(@"\row ");
            }

            string str = File.ReadAllText(target);
            str = str.Replace("#tablePayments#", sb.ToString());
            File.WriteAllText(target, str);

            MessageBox.Show("Формирование отчёта MS Word (.doc) по платежам завершено!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Replace(string from, string to)
        {
            int start = _richTextBox.Find(from, 0, RichTextBoxFinds.None);
            _richTextBox.Select(start, from.Length);
            _richTextBox.SelectedText = to;
        }

        public static string ToRtf(string value)
        {
            byte[] t = new byte[1];
            int j = 0;
            while (j < value.Length)
            {
                if (value[j] >= '\x7F')
                {
                    Encoding.GetEncoding(1251).GetBytes(value, j, 1, t, 0);
                    value = value.Replace(value[j].ToString(), "\\'" + t[0].ToString("x"));
                }
                j++;
            }
            value = value.Replace("\\n", "\\par;");
            return value;
        }

        #endregion
    }
}