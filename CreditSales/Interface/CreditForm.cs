using CreditSales.Data;
using CreditSales.Data.Models;
using CreditSales.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CreditSales.Interface
{
    public partial class CreditForm : Form
    {
        private ProductRepository _productRepository = new ProductRepository();
        private ScheduleRepository _scheduleRepository = new ScheduleRepository();
        private CreditRepository _creditRepository = new CreditRepository();
        private BaseRepository _baseRepository = new BaseRepository();
        private SoldProductsRepository _soldProductsRepository = new SoldProductsRepository();
        private BlackListRepository _blackListRepository = new BlackListRepository();

        private Credit CurrentCredit;
        private Schedule CurrentPayment;
        private SoldProduct CurrentProduct;
        private Base BaseInfo;

        public CreditForm()
        {
            InitializeComponent();

            #region Help

            toolTip.SetToolTip(tbContractId, "Номер договора кредитования. Для нового договора формируется автоматически.");
            toolTip.SetToolTip(dateContract, "Дата заключения договора кредитования.");
            toolTip.SetToolTip(cbSeller, "Ф.И.О. продавца, оформляющего договор. Выберите из выпадающего меню или введите вручную.");
            toolTip.SetToolTip(btnSave, "Сохранить и закрыть");
            toolTip.SetToolTip(btnClose, "Закрыть без сохранения");
            toolTip.SetToolTip(tbClient, "Ф.И.О. покупателя");
            toolTip.SetToolTip(tbClientAdr, "Адрес покупателя");
            toolTip.SetToolTip(tbClientDoc, "Документ удостоверяющий личность покупателя");
            toolTip.SetToolTip(tbClientPhone, "Телефон покупателя");
            toolTip.SetToolTip(cbProduct, "Выберите товар. Также можно воспользоваться кнопкой справа.");
            toolTip.SetToolTip(btnChooseProduct, "Выберите товар");
            toolTip.SetToolTip(tbPrice, "Стоимость товара");
            toolTip.SetToolTip(tbAdd, "Процент наценки на товар");
            toolTip.SetToolTip(tbDiscount, "Процент скидки на товар");
            toolTip.SetToolTip(tbTotalForTovar, "Окончательная цена товара для покупателя");
            toolTip.SetToolTip(btnAdd, "Добавить товар в список");
            toolTip.SetToolTip(btnEdit, "Изменить выбранный товар в списке");
            toolTip.SetToolTip(btnDelete, "Удалить выбранный товар из списка");
            toolTip.SetToolTip(gridProducts, "Список всех приобретаемых товаров");
            toolTip.SetToolTip(gridSchedule, "График платежей");
            toolTip.SetToolTip(tbTotalSum, "Цена заказанных товаров");
            toolTip.SetToolTip(tbTotalAdd, "Процент наценки для всего заказа");
            toolTip.SetToolTip(tbTotalDiscount, "Процент скидки для всего заказа");
            toolTip.SetToolTip(tbTotalPrice, "Итоговая стоимость заказа для клиента");
            toolTip.SetToolTip(tbFirstPayment, "Сумма первоначального взноса, уплачиваемого клиентом в день оформления кредита");
            toolTip.SetToolTip(tbMonths, "Количество месяцев кредитования (рассрочки)");
            toolTip.SetToolTip(tbPercentYear, "Процентная ставка (годовых) за пользование коммерческим кредитом");
            toolTip.SetToolTip(cbPaymentDay, "День месяца, до которого необходимо уплатить взносы");
            toolTip.SetToolTip(cbCountAuto, "Включить (отключить) автоматический рассчёт графика платежей");

            #endregion

            BaseInfo = _baseRepository.GetBaseFinanceInfo();
            if (BaseInfo == null)
            {
                MessageBox.Show("Не удалось получить базовую финансовую информацию. Проверьте подключение к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var products = _productRepository.GetProducts();

            if (products.Count == 0)
            {
                MessageBox.Show("В базе данных отсутствуют товары!", "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            foreach (var prod in products)
            {
                cbProduct.Items.Add(prod);
            }

            cbProduct.DisplayMember = "Name";
            cbProduct.SelectedItem = cbProduct.Items[0];
            tbTotalAdd.Text = "0";
            tbTotalDiscount.Text = "0";

            if (CurrentCredit == null)
            {
                tbMonths.Text = BaseInfo.Term.ToString();
                tbPercentYear.Text = BaseInfo.PercentYear.ToString("#.00");
                cbPaymentDay.SelectedItem = BaseInfo.DayPayment.ToString();
                tbContractId.Text = (BaseInfo.LastCredit + 1).ToString();
            }

            List<string> consults = new List<string>();
            _creditRepository.GetCredits().ForEach(c => consults.Add(c.Consult));
            consults = consults.Distinct().ToList();
            consults.ForEach(c => cbSeller.Items.Add(c));
        }

        public CreditForm(Credit currentCredit) : this()
        {
            CurrentCredit = currentCredit;
            var products = _soldProductsRepository.GetSoldProducts().Where(p => p.CreditId == CurrentCredit.Id).ToList();
            var payments = _scheduleRepository.GetPayments().Where(p => p.CreditId == CurrentCredit.Id).ToList();

            gridProducts.Rows.Clear();
            foreach (var prod in products)
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

            gridSchedule.Rows.Clear();
            foreach (var pay in payments)
            {
                var row = new DataGridViewRow();
                row.Tag = pay;
                for (int j = 0; j < 6; j++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = pay.DatePayment.ToShortDateString();
                row.Cells[1].Value = pay.Rest.ToString("#.00");
                row.Cells[2].Value = pay.PaymentAmount.ToString("#.00");
                row.Cells[3].Value = pay.SumPercent.ToString("#.00");
                row.Cells[4].Value = pay.SumTotal.ToString("#.00");
                row.Cells[5].Value = pay.Comment;
                gridSchedule.Rows.Add(row);
            }

            tbMonths.Text = currentCredit.Term.ToString();
            tbPercentYear.Text = currentCredit.PercentYear.ToString("#.00");
            tbTotalAdd.Text = currentCredit.AddPercent.ToString("#.00");
            tbTotalDiscount.Text = currentCredit.DiscPercent.ToString("#.00");
            tbContractId.Text = currentCredit.Number.ToString();
            dateContract.Value = currentCredit.Data;
            cbSeller.Text = currentCredit.Consult;
            tbClient.Text = currentCredit.ClientFIO;
            tbClientAdr.Text = currentCredit.ClientAdr;
            tbClientDoc.Text = currentCredit.ClientDoc;
            tbClientPhone.Text = currentCredit.ClientPhone;
            tbTotalSum.Text = currentCredit.TotalClean.ToString("#.00");
            tbTotalPrice.Text = currentCredit.Total.ToString("#.00");
            tbFirstPayment.Text = currentCredit.FirstPayment.ToString("#.00");

            cbPaymentDay.SelectedItem = currentCredit.DayPayment.ToString();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            #region Check

            if (string.IsNullOrEmpty(tbContractId.Text))
            {
                MessageBox.Show("Введите номер договора!", "Не все данные введены", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cbSeller.Text.ToString()))
            {
                MessageBox.Show("Введите имя продавца!", "Не все данные введены", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbClient.Text))
            {
                MessageBox.Show("Введите имя клиента!", "Не все данные введены", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbClientAdr.Text))
            {
                MessageBox.Show("Введите адрес клиента!", "Не все данные введены", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbClientDoc.Text))
            {
                MessageBox.Show("Введите документ клиента!", "Не все данные введены", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridProducts.Rows.Count == 0)
            {
                MessageBox.Show("Заказ пуст!", "Не все данные введены", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridSchedule.Rows.Count == 0)
            {
                MessageBox.Show("Платежи по разписанию отсутствуют!", "Не все данные введены", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var blackList = _blackListRepository.GetBlackList();
            foreach (var user in blackList)
            {
                if (user.Client == tbClient.Text && user.Address == tbClientAdr.Text && user.Document == tbClientDoc.Text && user.Phone == tbClientPhone.Text)
                {
                    if (MessageBox.Show("Внимание! Данный пользователь в чёрном списке. Вы точно желаете заключить с ним договор?",
                            "Неблагонадёжный клиент", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            #endregion

            //credit
            if (CurrentCredit == null)
            {
                CurrentCredit = new Credit();
                CurrentCredit.Id = -1;
            }
            else
            {
                _creditRepository.Delete(CurrentCredit, false);
            }
            CurrentCredit.Number = string.IsNullOrEmpty(tbContractId.Text) ? 0 : Convert.ToInt32(tbContractId.Text);
            CurrentCredit.Term = string.IsNullOrEmpty(tbMonths.Text) ? 0 : Convert.ToInt32(tbMonths.Text);
            CurrentCredit.DayPayment = string.IsNullOrEmpty(cbPaymentDay.Text) ? 0 : Convert.ToInt32(cbPaymentDay.Text);
            CurrentCredit.Data = dateContract.Value;
            CurrentCredit.Consult = cbSeller.Text;
            CurrentCredit.ClientFIO = tbClient.Text;
            CurrentCredit.ClientAdr = tbClientAdr.Text;
            CurrentCredit.ClientDoc = tbClientDoc.Text;
            CurrentCredit.ClientPhone = tbClientPhone.Text;
            CurrentCredit.TotalClean = string.IsNullOrEmpty(tbTotalSum.Text) ? 0 : Convert.ToDecimal(tbTotalSum.Text);
            CurrentCredit.DiscPercent = string.IsNullOrEmpty(tbTotalDiscount.Text) ? 0 : Convert.ToDecimal(tbTotalDiscount.Text);
            CurrentCredit.AddPercent = string.IsNullOrEmpty(tbTotalAdd.Text) ? 0 : Convert.ToDecimal(tbTotalAdd.Text);
            CurrentCredit.Total = string.IsNullOrEmpty(tbTotalPrice.Text) ? 0 : Convert.ToDecimal(tbTotalPrice.Text);
            CurrentCredit.FirstPayment = string.IsNullOrEmpty(tbFirstPayment.Text) ? 0 : Convert.ToDecimal(tbFirstPayment.Text);
            CurrentCredit.PercentYear = string.IsNullOrEmpty(tbPercentYear.Text) ? 0 : Convert.ToDecimal(tbPercentYear.Text);
            CurrentCredit.IsActive = true;
            _creditRepository.AddOrUpdate(CurrentCredit);
            int id = 0;
            if (CurrentCredit.Id == -1)
            {
                id = _creditRepository.GetLastId();
            }
            else
            {
                id = CurrentCredit.Id;
            }
            //soldProducts
            List<SoldProduct> soldProducts = new List<SoldProduct>();
            foreach (DataGridViewRow row in gridProducts.Rows)
            {
                soldProducts.Add(row.Tag as SoldProduct);
            }
            soldProducts.ForEach(p =>
            {
                p.CreditId = id;
                _soldProductsRepository.AddOrUpdate(p);
            });
            //schedule
            List<Schedule> schedules = new List<Schedule>();
            foreach (DataGridViewRow row in gridSchedule.Rows)
            {
                schedules.Add(row.Tag as Schedule);
            }
            schedules.ForEach(s =>
            {
                s.CreditId = id;
                _scheduleRepository.AddOrUpdate(s);
            });

            Close();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (CurrentProduct == null) return;

            var productInGrid = new SoldProduct
            {
                Id = -1,
                CategoryId = CurrentProduct.CategoryId,
                CreditId = CurrentCredit == null ? -1 : CurrentCredit.Id,
                Name = CurrentProduct.Name,
                AddAmount = string.IsNullOrEmpty(tbAdd.Text) ? 0 : Convert.ToDecimal(tbAdd.Text.Replace('.', ',')),
                Total = string.IsNullOrEmpty(tbTotalForTovar.Text) ? 0 : Convert.ToDecimal(tbTotalForTovar.Text.Replace('.', ',')),
                Price = string.IsNullOrEmpty(tbPrice.Text) ? 0 : Convert.ToDecimal(tbPrice.Text.Replace('.', ',')),
                Discount = string.IsNullOrEmpty(tbDiscount.Text) ? 0 : Convert.ToDecimal(tbDiscount.Text.Replace('.', ','))
            };

            var row = new DataGridViewRow();
            row.Tag = productInGrid;
            for (int i = 0; i < 5; i++) row.Cells.Add(new DataGridViewTextBoxCell());
            row.Cells[0].Value = productInGrid.Name;
            row.Cells[1].Value = productInGrid.Price.ToString("#.00");
            row.Cells[2].Value = productInGrid.AddAmount.ToString("#.00");
            row.Cells[3].Value = productInGrid.Discount.ToString("#.00");
            row.Cells[4].Value = productInGrid.Total.ToString("#.00");
            gridProducts.Rows.Add(row);
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (gridProducts.SelectedRows.Count == 0) return;

            CurrentProduct = gridProducts.SelectedRows[0].Tag as SoldProduct;
            if (CurrentProduct != null)
            {
                DisplayCurrentProduct();
                cbProduct.SelectedItem = cbProduct.Items.Cast<Product>().FirstOrDefault(p => p.Name == CurrentProduct.Name);
                gridProducts.Rows.Remove(gridProducts.SelectedRows[0]);
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (gridProducts.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Вы уверенны, что хотите удалить товар " + (gridProducts.SelectedRows[0].Tag as SoldProduct).Name + " из списка?", "Удаление товара", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gridProducts.Rows.Remove(gridProducts.SelectedRows[0]);
            }
        }

        private void menuStripNewPayment_Click(object sender, System.EventArgs e)
        {
            decimal debt = Convert.ToDecimal(tbTotalPrice.Text.Replace('.', ',')) - Convert.ToDecimal(tbFirstPayment.Text.Replace('.', ','));
            foreach (DataGridViewRow row in gridSchedule.Rows)
            {
                debt -= (row.Tag as Schedule).PaymentAmount;
            }

            var form = new SchedulePayment(debt);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                if (Storage.CreatedSchedulePayment != null)
                {
                    var row = new DataGridViewRow();
                    row.Tag = Storage.CreatedSchedulePayment;
                    for (int j = 0; j < 6; j++) row.Cells.Add(new DataGridViewTextBoxCell());
                    row.Cells[0].Value = Storage.CreatedSchedulePayment.DatePayment.ToShortDateString();
                    row.Cells[1].Value = Storage.CreatedSchedulePayment.Rest.ToString("#.00");
                    row.Cells[2].Value = Storage.CreatedSchedulePayment.PaymentAmount.ToString("#.00");
                    row.Cells[3].Value = Storage.CreatedSchedulePayment.SumPercent.ToString("#.00");
                    row.Cells[4].Value = Storage.CreatedSchedulePayment.SumTotal.ToString("#.00");
                    row.Cells[5].Value = Storage.CreatedSchedulePayment.Comment;
                    gridSchedule.Rows.Add(row);
                    RecountLastRow();
                }
            }
        }

        private void menuStripEditPayment_Click(object sender, System.EventArgs e)
        {
            if (CurrentPayment == null) return;

            var form = new SchedulePayment(CurrentPayment);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                List<Schedule> payments = new List<Schedule>();
                foreach (DataGridViewRow row in gridSchedule.Rows)
                {
                    payments.Add(row.Tag as Schedule);
                }
                gridSchedule.Rows.Clear();
                foreach (var pay in payments)
                {
                    var row = new DataGridViewRow();
                    row.Tag = pay;
                    for (int j = 0; j < 6; j++) row.Cells.Add(new DataGridViewTextBoxCell());
                    row.Cells[0].Value = pay.DatePayment.ToShortDateString();
                    row.Cells[1].Value = pay.Rest.ToString("#.00");
                    row.Cells[2].Value = pay.PaymentAmount.ToString("#.00");
                    row.Cells[3].Value = pay.SumPercent.ToString("#.00");
                    row.Cells[4].Value = pay.SumTotal.ToString("#.00");
                    row.Cells[5].Value = pay.Comment;
                    gridSchedule.Rows.Add(row);
                }
                RecountLastRow();
            }
        }

        private void RecountLastRow()
        {
            try
            {
                decimal totalOrder = string.IsNullOrEmpty(tbTotalPrice.Text) ? 0 : Convert.ToDecimal(tbTotalPrice.Text.Replace('.', ','));
                decimal firstPayment = string.IsNullOrEmpty(tbFirstPayment.Text) ? 0 : Convert.ToDecimal(tbFirstPayment.Text.Replace('.', ','));

                decimal sum = 0, percents = 0;
                foreach (DataGridViewRow row in gridSchedule.Rows)
                {
                    sum += (row.Tag as Schedule).PaymentAmount;
                    percents += (row.Tag as Schedule).SumPercent;
                }

                tbTotalDebt.Text = (totalOrder - firstPayment).ToString("#.00");
                tbTotalPay.Text = sum.ToString("#.00");
                tbTotalPercent.Text = percents.ToString("#.00");
                tbTotal.Text = (sum + percents).ToString("#.00");
            }
            catch
            {
                //nothing to do, wait for the next user actions
            }
        }

        private void menuStripDeletePayment_Click(object sender, System.EventArgs e)
        {
            if (CurrentPayment == null) return;

            if (MessageBox.Show("Вы уверенны, что хотите удалить плановый платёж от " + CurrentPayment.DatePayment.ToShortDateString() + "?", "Удаление платежа", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _scheduleRepository.Delete(CurrentPayment);
                List<Schedule> payments = new List<Schedule>();
                foreach (DataGridViewRow row in gridSchedule.Rows)
                {
                    payments.Add(row.Tag as Schedule);
                }
                payments.Remove(CurrentPayment);
                gridSchedule.Rows.Clear();
                foreach (var pay in payments)
                {
                    var row = new DataGridViewRow();
                    row.Tag = pay;
                    for (int j = 0; j < 6; j++) row.Cells.Add(new DataGridViewTextBoxCell());
                    row.Cells[0].Value = pay.DatePayment.ToShortDateString();
                    row.Cells[1].Value = pay.Rest.ToString("#.00");
                    row.Cells[2].Value = pay.PaymentAmount.ToString("#.00");
                    row.Cells[3].Value = pay.SumPercent.ToString("#.00");
                    row.Cells[4].Value = pay.SumTotal.ToString("#.00");
                    row.Cells[5].Value = pay.Comment;
                    gridSchedule.Rows.Add(row);
                }
                CurrentPayment = null;
            }
        }

        private void gridProducts_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverRow = gridProducts.HitTest(e.X, e.Y).RowIndex;
                    CurrentProduct = gridSchedule.Rows[currentMouseOverRow].Tag as SoldProduct;
                    if (CurrentProduct != null)
                    {
                        gridContextMenu.Show(gridProducts, e.Location);
                    }
                }
            }
            catch
            {
                //nothing to do, wait for the next user actions
            }
        }

        private void gridSchedule_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverRow = gridSchedule.HitTest(e.X, e.Y).RowIndex;
                    CurrentPayment = gridSchedule.Rows[currentMouseOverRow].Tag as Schedule;
                    if (CurrentPayment != null)
                    {
                        gridContextMenu.Show(gridSchedule, e.Location);
                    }
                }
            }
            catch
            {
                //nothing to do, wait for the next user actions
            }
        }

        private void tbPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal price = string.IsNullOrEmpty(tbPrice.Text) ? 0 : Convert.ToDecimal(tbPrice.Text.Replace('.', ','));
                decimal add = string.IsNullOrEmpty(tbAdd.Text) ? 0 : Convert.ToDecimal(tbAdd.Text.Replace('.', ','));
                decimal disc = string.IsNullOrEmpty(tbDiscount.Text) ? 0 : Convert.ToDecimal(tbDiscount.Text.Replace('.', ','));
                decimal total = price * ((100 + add - disc) / 100);
                tbTotalForTovar.Text = total.ToString("#.00");
            }
            catch
            {
                //nothing to do, wait for the next user actions
            }
        }

        private void tbTotalSum_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal price = string.IsNullOrEmpty(tbTotalSum.Text) ? 0 : Convert.ToDecimal(tbTotalSum.Text.Replace('.', ','));
                decimal add = string.IsNullOrEmpty(tbTotalAdd.Text) ? 0 : Convert.ToDecimal(tbTotalAdd.Text.Replace('.', ','));
                decimal disc = string.IsNullOrEmpty(tbTotalDiscount.Text) ? 0 : Convert.ToDecimal(tbTotalDiscount.Text.Replace('.', ','));
                decimal total = price * ((100 + add - disc) / 100);
                tbTotalPrice.Text = total.ToString("#.00");

                tbFirstPayment.Text = (total * (BaseInfo.FirstPaymentPercent / 100)).ToString("#.00");
            }
            catch
            {
                //nothing to do, wait for the next user actions
            }
        }

        private void tbFirstPayment_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbCountAuto.Checked)
            {
                RecountPayments();
            }
        }

        private void cbPaymentDay_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (cbCountAuto.Checked)
            {
                RecountPayments();
            }
        }

        private void cbCountAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCountAuto.Checked)
            {
                RecountPayments();
            }
        }

        private void RecountPayments()
        {
            try
            {
                gridSchedule.Rows.Clear();
                decimal totalOrder = string.IsNullOrEmpty(tbTotalPrice.Text) ? 0 : Convert.ToDecimal(tbTotalPrice.Text.Replace('.', ','));
                decimal firstPayment = string.IsNullOrEmpty(tbFirstPayment.Text) ? 0 : Convert.ToDecimal(tbFirstPayment.Text.Replace('.', ','));
                decimal percentYear = string.IsNullOrEmpty(tbPercentYear.Text) ? 0 : Convert.ToDecimal(tbPercentYear.Text.Replace('.', ','));
                int term = string.IsNullOrEmpty(tbMonths.Text) ? 0 : Convert.ToInt32(tbMonths.Text);
                int paymentDay = Convert.ToInt32(cbPaymentDay.Text);
                decimal withoutFirst = totalOrder - firstPayment;

                decimal generalMust = 0, generalPercent = 0;
                decimal singlePayment = withoutFirst / term;
                
                for (int i = 0; i < term; i++)
                {
                    Schedule pay = new Schedule();
                    pay.Comment = (i + 1) + " взнос";
                    pay.CreditId = CurrentCredit == null ? -1 : CurrentCredit.Id;

                    int addMonth = 0;
                    if (dateContract.Value.Day >= paymentDay)
                    {
                        addMonth = 1;
                    }

                    if (dateContract.Value.Month + i + addMonth > 12)
                    {
                        pay.DatePayment = new DateTime(dateContract.Value.Year + 1, dateContract.Value.Month + i + addMonth - 12, paymentDay);
                    }
                    else
                    {
                        if (DateTime.DaysInMonth(dateContract.Value.Year, dateContract.Value.Month + i + addMonth) == 31)
                        {
                            pay.DatePayment = new DateTime(dateContract.Value.Year, dateContract.Value.Month + i + addMonth, paymentDay);
                        }
                        else if (DateTime.DaysInMonth(dateContract.Value.Year, dateContract.Value.Month + i + addMonth) == 30)
                        {
                            if (paymentDay > 29)
                                pay.DatePayment = new DateTime(dateContract.Value.Year, dateContract.Value.Month + i + addMonth, 30);
                            else
                                pay.DatePayment = new DateTime(dateContract.Value.Year, dateContract.Value.Month + i + addMonth, paymentDay);
                        }
                        else if (DateTime.DaysInMonth(dateContract.Value.Year, dateContract.Value.Month + i + addMonth) == 29)
                        {
                            if (paymentDay > 28)
                                pay.DatePayment = new DateTime(dateContract.Value.Year, dateContract.Value.Month + i + addMonth, 29);
                            else
                                pay.DatePayment = new DateTime(dateContract.Value.Year, dateContract.Value.Month + i + addMonth, paymentDay);
                        }
                        else if (DateTime.DaysInMonth(dateContract.Value.Year, dateContract.Value.Month + i + addMonth) == 28)
                        {
                            if (paymentDay > 27)
                                pay.DatePayment = new DateTime(dateContract.Value.Year, dateContract.Value.Month + i + addMonth, 28);
                            else
                                pay.DatePayment = new DateTime(dateContract.Value.Year, dateContract.Value.Month + i + addMonth, paymentDay);
                        }
                    }

                    if (BaseInfo.Round != 0)
                    {
                        if (i == term - 1)
                        {
                            pay.Rest = withoutFirst;
                            pay.PaymentAmount = withoutFirst;
                            pay.SumPercent = (pay.Rest * (percentYear / 100) / 12);
                            pay.SumTotal = pay.Rest + pay.SumPercent;
                        }
                        else
                        {
                            pay.Rest = withoutFirst;
                            pay.PaymentAmount = singlePayment;
                            pay.SumPercent = (pay.Rest * (percentYear / 100) / 12);

                            decimal rest = withoutFirst;
                            decimal sumPercent = (rest * (percentYear / 100) / 12);
                            decimal pay1 = singlePayment + sumPercent;
                            decimal pay2 = RoundToIncrement(pay1, BaseInfo.Round);
                            decimal diff = pay2 - pay1;

                            withoutFirst = withoutFirst - singlePayment - diff;

                            pay.SumTotal = pay2;
                            pay.PaymentAmount += diff;
                        }
                    }
                    else
                    {
                        pay.Rest = withoutFirst;
                        pay.PaymentAmount = singlePayment;
                        pay.SumPercent = (pay.Rest * (percentYear / 100) / 12);
                        pay.SumTotal = pay.PaymentAmount + pay.SumPercent;
                        withoutFirst -= singlePayment;
                    }

                    var row = new DataGridViewRow();
                    row.Tag = pay;
                    for (int j = 0; j < 6; j++) row.Cells.Add(new DataGridViewTextBoxCell());
                    row.Cells[0].Value = pay.DatePayment.ToShortDateString();
                    row.Cells[1].Value = pay.Rest.ToString("#.00");
                    row.Cells[2].Value = pay.PaymentAmount.ToString("#.00");
                    row.Cells[3].Value = pay.SumPercent.ToString("#.00");
                    row.Cells[4].Value = pay.SumTotal.ToString("#.00");
                    row.Cells[5].Value = pay.Comment;
                    gridSchedule.Rows.Add(row);

                    generalMust += pay.PaymentAmount;
                    generalPercent += pay.SumPercent;
                }

                tbTotalDebt.Text = (totalOrder - firstPayment).ToString("#.00");
                tbTotalPay.Text = generalMust.ToString("#.00");
                tbTotalPercent.Text = generalPercent.ToString("#.00");
                tbTotal.Text = (generalMust + generalPercent).ToString("#.00");
            }
            catch
            {
                //nothing to do, wait for the next user actions
            }
        }

        private decimal RoundToIncrement(decimal x, decimal m)
        {
            return Math.Round(x / m) * m;
        }

        private void btnChooseProduct_Click(object sender, EventArgs e)
        {
            var form = new Interface.Products(true);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                if (Storage.SelectedProduct != null)
                {
                    cbProduct.SelectedItem = cbProduct.Items.Cast<Product>().FirstOrDefault(p => p.Id == Storage.SelectedProduct.Id);

                    CurrentProduct = new SoldProduct();
                    CurrentProduct.AddAmount = Storage.SelectedProduct.AddAmount;
                    CurrentProduct.CategoryId = Storage.SelectedProduct.CategoryId;
                    CurrentProduct.CreditId = CurrentCredit == null ? -1 : CurrentCredit.Id;
                    CurrentProduct.Discount = Storage.SelectedProduct.Discount;
                    CurrentProduct.Id = Storage.SelectedProduct.Id;
                    CurrentProduct.Price = Storage.SelectedProduct.Price;
                    CurrentProduct.Total = Storage.SelectedProduct.Total;
                    CurrentProduct.Name = Storage.SelectedProduct.Name;
                }
            }
            DisplayCurrentProduct();
        }

        private void cbProduct_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbProduct.SelectedItem is Product)
            {
                var tempProduct = cbProduct.SelectedItem as Product;
                CurrentProduct = new SoldProduct();
                CurrentProduct.AddAmount = tempProduct.AddAmount;
                CurrentProduct.CategoryId = tempProduct.CategoryId;
                CurrentProduct.CreditId = CurrentCredit == null ? -1 : CurrentCredit.Id;
                CurrentProduct.Discount = tempProduct.Discount;
                CurrentProduct.Id = tempProduct.Id;
                CurrentProduct.Price = tempProduct.Price;
                CurrentProduct.Total = tempProduct.Total;
                CurrentProduct.Name = tempProduct.Name;
            }
            DisplayCurrentProduct();
        }

        private void DisplayCurrentProduct()
        {
            if (CurrentProduct == null) return;

            tbPrice.Text = CurrentProduct.Price.ToString("#.00");
            tbAdd.Text = CurrentProduct.AddAmount.ToString("#.00");
            tbDiscount.Text = CurrentProduct.Discount.ToString("#.00");
            tbTotalForTovar.Text = CurrentProduct.Total.ToString("#.00");
        }

        private void gridProducts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowCount > 0) RecountTotalForOrder();
        }

        private void gridProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowCount > 0) RecountTotalForOrder();
        }

        private void RecountTotalForOrder()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in gridProducts.Rows)
            {
                total = total + (row.Tag as SoldProduct).Total;
            }

            tbTotalSum.Text = total.ToString("#.00");
            tbTotalSum_KeyUp(this, null);

            RecountPayments();
        }

        private void tbTotalPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal total = string.IsNullOrEmpty(tbTotalPrice.Text) ? 0 : Convert.ToDecimal(tbTotalPrice.Text.Replace('.', ','));
                tbFirstPayment.Text = (total * (BaseInfo.FirstPaymentPercent / 100)).ToString("#.00");
            }
            catch
            {
                //nothing to do, wait for the next user actions
            }
        }

        private void gridSchedule_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (e.RowCount != 0)
            {
                RecountLastRow();
            }
        }

        private void gridSchedule_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowCount != 0)
            {
                RecountLastRow();
            }
        }

        private void tbContractId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }
    }
}