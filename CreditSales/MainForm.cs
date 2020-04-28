using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CreditSales.Data;
using CreditSales.Data.Models;
using CreditSales.Data.Repository;
using CreditSales.Interface;

namespace CreditSales
{
    public partial class MainForm : Form
    {
        private List<SingleWindow> _childWindows = new List<SingleWindow>();
        private CreditRepository _creditRepository = new CreditRepository();
        private ProductRepository _productRepository = new ProductRepository();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SingleWindow singleWindow = new SingleWindow();
            singleWindow.TopLevel = false;
            singleWindow.Location = new Point(10, 50);
            singleWindow.MdiParent = this;
            singleWindow.Text += " 1";
            singleWindow.Show();
            singleWindow.WindowState = FormWindowState.Maximized;
            menuStrip.BringToFront();
            toolStrip.BringToFront();

            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Text = singleWindow.Text;
            toolStripMenuItem.Click += delegate
            {
                singleWindow.Focus();
                foreach (var item in окноToolStripMenuItem.DropDownItems)
                {
                    if (item is ToolStripMenuItem)
                        (item as ToolStripMenuItem).Checked = false;
                }
                toolStripMenuItem.Checked = true;
            };
            окноToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
            _childWindows.Add(singleWindow);
        }

        private void новоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleWindow singleWindow = new SingleWindow();
            singleWindow.TopLevel = false;
            singleWindow.Location = new Point(10, 50);
            singleWindow.MdiParent = this;
            int max = 0;
            try
            {
                max = _childWindows.Where(w => w.Text != "").Max(c => Convert.ToInt32(c.Text.Split(' ')[2]));
            }
            catch
            {
                max = 0;
            }
            singleWindow.Text += " " + (max + 1);
            singleWindow.Show();
            singleWindow.WindowState = FormWindowState.Maximized;
            menuStrip.BringToFront();
            toolStrip.BringToFront();

            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Text = singleWindow.Text;
            toolStripMenuItem.Click += delegate
            {
                singleWindow.Focus();
                foreach (var item in окноToolStripMenuItem.DropDownItems)
                {
                    if (item is ToolStripMenuItem)
                        (item as ToolStripMenuItem).Checked = false;
                }
                toolStripMenuItem.Checked = true;
            };
            окноToolStripMenuItem.DropDownItems.Add(toolStripMenuItem);
            _childWindows.Add(singleWindow);
            foreach (var item in окноToolStripMenuItem.DropDownItems)
            {
                if (item is ToolStripMenuItem)
                    (item as ToolStripMenuItem).Checked = false;
            }
            toolStripMenuItem.Checked = true;
        }

        public void DeleteMenuItem(string text)
        {
            try
            {
                окноToolStripMenuItem.DropDownItems.Remove(окноToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().FirstOrDefault(i=>i.Text == text));
                _childWindows.Remove(_childWindows.FirstOrDefault(w => w.Text == text));
            }
            catch
            {
                //nothing to do, wait for the next user actions
            }
        }

        private void каскадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
            каскадToolStripMenuItem.Checked = true;
            черепицаToolStripMenuItem.Checked = false;
        }

        private void черепицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
            каскадToolStripMenuItem.Checked = false;
            черепицаToolStripMenuItem.Checked = true;
        }

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView grid = (ActiveMdiChild as SingleWindow).Tab.TabPages[0].Controls[0].Controls.OfType<DataGridView>().First();

            if (grid.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта!", "Ошибка экспорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fileCSV = "";
            for (int i = 0; i <= grid.ColumnCount - 2; i++)
            {
                fileCSV += grid.Columns[i].HeaderText + ";";
            }
            fileCSV += "\t\n";
            for (int i = 0; i < grid.RowCount; i++)
            {
                for (int j = 0; j < grid.ColumnCount - 2; j++)
                {
                    fileCSV += grid[j, i].Value + ";";
                }
                fileCSV += "\t\n";
            }
            StreamWriter wr = new StreamWriter("CSVReport.csv", false, Encoding.GetEncoding("utf-8"));
            wr.Write(fileCSV);
            wr.Close();

            MessageBox.Show("Экспорт таблицы в файл CSVReport.csv завершён!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null) ActiveMdiChild.Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newCredit_Click(object sender, EventArgs e)
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
                if (ActiveMdiChild == null) return;
                (ActiveMdiChild as SingleWindow).LoadGrid();
            }
        }

        private void editCredit_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[1] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ActiveMdiChild == null) return;
            var activeChild = ActiveMdiChild as SingleWindow;
            if (activeChild == null || 
                activeChild.CreditsGrid.SelectedRows.Count != 1 ||
                !(activeChild.CreditsGrid.SelectedRows[0].Tag is Credit))
            {
                return;
            }

            var form = new CreditForm(activeChild.CreditsGrid.SelectedRows[0].Tag as Credit);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                activeChild.LoadGrid();
            }
        }

        private void deleteCredit_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[2] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ActiveMdiChild == null) return;
            if ((ActiveMdiChild as SingleWindow).CreditsGrid.SelectedRows.Count != 1) return;

            if (MessageBox.Show("Вы уверенны, что хотите удалить договор №" + 
                                ((ActiveMdiChild as SingleWindow).CreditsGrid.SelectedRows[0].Tag as Credit).Number + 
                                " и все связанные данные?", "Удаление договора", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _creditRepository.Delete((ActiveMdiChild as SingleWindow).CreditsGrid.SelectedRows[0].Tag as Credit);
                (ActiveMdiChild as SingleWindow).LoadGrid();
            }
        }

        private void addPayment_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[12] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ActiveMdiChild == null) return;
            var activeChild = ActiveMdiChild as SingleWindow;
            if (activeChild == null ||
                activeChild.CreditsGrid.SelectedRows.Count != 1 ||
                !(activeChild.CreditsGrid.SelectedRows[0].Tag is Credit))
            {
                return;
            }
            if (!(activeChild.CreditsGrid.SelectedRows[0].Tag as Credit).IsActive)
            {
                MessageBox.Show("Данный договор уже закрыт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new DonePayment(activeChild.CreditsGrid.SelectedRows[0].Tag as Credit);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                activeChild.LoadGrid();
            }
        }

        private void allPayments_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[13] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ActiveMdiChild == null) return;
            var activeChild = ActiveMdiChild as SingleWindow;
            if (activeChild == null ||
                activeChild.CreditsGrid.SelectedRows.Count != 1 ||
                !(activeChild.CreditsGrid.SelectedRows[0].Tag is Credit))
            {
                return;
            }

            var form = new InfoAboutPayments(activeChild.CreditsGrid.SelectedRows[0].Tag as Credit);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                activeChild.LoadGrid();
            }
        }

        private void printCredit_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
            var activeChild = ActiveMdiChild as SingleWindow;
            if (activeChild == null ||
                activeChild.CreditsGrid.SelectedRows.Count != 1 ||
                !(activeChild.CreditsGrid.SelectedRows[0].Tag is Credit))
            {
                return;
            }

            activeChild.CurrentCredit = activeChild.CreditsGrid.SelectedRows[0].Tag as Credit;
            activeChild.PrintAgreement();
        }

        private void printSchedule_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
            var activeChild = ActiveMdiChild as SingleWindow;
            if (activeChild == null ||
                activeChild.CreditsGrid.SelectedRows.Count != 1 ||
                !(activeChild.CreditsGrid.SelectedRows[0].Tag is Credit))
            {
                return;
            }

            activeChild.CurrentCredit = activeChild.CreditsGrid.SelectedRows[0].Tag as Credit;
            activeChild.PrintSchedule();
        }

        private void printPayments_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild == null) return;
            var activeChild = ActiveMdiChild as SingleWindow;
            if (activeChild == null ||
                activeChild.CreditsGrid.SelectedRows.Count != 1 ||
                !(activeChild.CreditsGrid.SelectedRows[0].Tag is Credit))
            {
                return;
            }

            activeChild.CurrentCredit = activeChild.CreditsGrid.SelectedRows[0].Tag as Credit;
            activeChild.PrintPayments();
        }

        private void about_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void справочникТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[4] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new Products().ShowDialog();
        }

        private void справочникОсновныхСведенийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[3] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new Interface.MainInfo().ShowDialog();
        }

        private void справочникГрафикаКредитованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[5] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new PaymentGraph().ShowDialog();
        }

        private void справочникПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[6] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new UsersForm().ShowDialog();
        }

        private void чёрныйСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[7] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new Interface.BlackList().ShowDialog();
        }

        private void выданныеКредитыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[9] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < _childWindows.Count; i++)
            {
                _childWindows[i].Close();
            }
            новоеToolStripMenuItem_Click(this, null);
            if (ActiveMdiChild == null) return;

            (ActiveMdiChild as SingleWindow).DisplayAllCreidts();

            ShowMenu();
        }

        private void поступленияПоКредитамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[10] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < _childWindows.Count; i++)
            {
                _childWindows[i].Close();
            }
            новоеToolStripMenuItem_Click(this, null);
            if (ActiveMdiChild == null) return;

            (ActiveMdiChild as SingleWindow).DisplayPayments();

            ShowMenu();
        }

        private void ожидаемыеПоступленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[11] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < _childWindows.Count; i++)
            {
                _childWindows[i].Close();
            }
            новоеToolStripMenuItem_Click(this, null);
            if (ActiveMdiChild == null) return;

            (ActiveMdiChild as SingleWindow).DisplayAwaitablePayments();

            ShowMenu();
        }

        private void ShowMenu()
        {
            журналКредитовToolStripMenuItem.Visible = true;
            редактированиеToolStripMenuItem.Visible = false;
            видToolStripMenuItem.Visible = false;
            окноToolStripMenuItem.Visible = false;
            toolStrip.Visible = false;
        }

        private void панелиИнструментовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (панелиИнструментовToolStripMenuItem.Checked)
            {
                панелиИнструментовToolStripMenuItem.Checked = false;
                toolStrip.Visible = false;
            }
            else
            {
                панелиИнструментовToolStripMenuItem.Checked = true;
                toolStrip.Visible = true;
            }
        }

        private void регистрацияПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Storage.CurrentUser.Access[8] == '0')
            {
                MessageBox.Show("Вы не имеете прав на данное действие!\nЕсли вам необходимо выполнять данную работу, измените права пользователя в справочнике пользователей!", "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new Registration().ShowDialog();
        }

        private void журналКредитовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _childWindows.Count; i++)
            {
                _childWindows[i].Close();
            }
            редактированиеToolStripMenuItem.Visible = true;
            видToolStripMenuItem.Visible = true;
            окноToolStripMenuItem.Visible = true;
            toolStrip.Visible = true;
            журналКредитовToolStripMenuItem.Visible = false;

            новоеToolStripMenuItem_Click(this, null);
        }
    }
}