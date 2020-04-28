using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CreditSales.Data.Models;
using CreditSales.Data.Repository;

namespace CreditSales.Interface
{
    public partial class AddProductForm : Form
    {
        private Product product;
        private ProductRepository _productRepository = new ProductRepository();
        private CategoryRepository _categoryRepository = new CategoryRepository();
        private List<Category> _categories = new List<Category>();

        public AddProductForm()
        {
            InitializeComponent();
            toolTip.SetToolTip(cbCategory, "Категория товара. Если не выбрать, товар останется без категории.");
            toolTip.SetToolTip(tbNumber, "Уникальный идентификатор товара");
            toolTip.SetToolTip(tbProduct, "Название товара");
            toolTip.SetToolTip(tbPrice, "Стоимость товара");
            toolTip.SetToolTip(tbAdd, "Надбавка, в процентах");
            toolTip.SetToolTip(tbDisc, "Скидка, в процентах");
            toolTip.SetToolTip(tbTotal, "Итоговая цена");
            toolTip.SetToolTip(btnSave, "Сохранить");
            toolTip.SetToolTip(btnClose, "Отмена");

            _categories = _categoryRepository.GetCategories();
            if (_categories.Count == 0)
            {
                MessageBox.Show("В базе данных отсутствуют категории!", "Создайте категорию!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var cat in _categories)
            {
                cbCategory.Items.Add(cat.Name);
            }
        }

        public AddProductForm(Product product) : this()
        {
            this.product = product;
            cbCategory.SelectedItem = product.Category.Name;
            tbNumber.Text = product.Number.ToString();
            tbAdd.Text = product.AddAmount.ToString();
            tbDisc.Text = product.Discount.ToString();
            tbPrice.Text = product.Price.ToString();
            tbTotal.Text = product.Total.ToString();
            tbProduct.Text = product.Name;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию!", "Выберите категорию", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbProduct.Text))
            {
                MessageBox.Show("Введите название товара!", "Введите название товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbPrice.Text))
            {
                MessageBox.Show("Введите стоимость товара!", "Введите стоимость товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(tbNumber.Text))
            {
                MessageBox.Show("Введите идентификатор товара!", "Введите идентификатор товара", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_productRepository.GetProducts().Any(p => p.Number == Convert.ToInt32(tbNumber.Text)) && product == null)
            {
                MessageBox.Show("Товар с таким идентификатором уже есть в базе!", "Дубликат!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_productRepository.GetProducts().Any(p => p.Number == Convert.ToInt32(tbNumber.Text)) && 
                product != null && 
                product.Number != Convert.ToInt32(tbNumber.Text))
            {
                MessageBox.Show("Товар с таким идентификатором уже есть в базе!", "Дубликат!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (product == null) product = new Product();
            product.Number = Convert.ToInt32(tbNumber.Text);
            product.AddAmount = string.IsNullOrEmpty(tbAdd.Text) ? 0 : Convert.ToDecimal(tbAdd.Text.Replace('.', ','));
            product.Discount = string.IsNullOrEmpty(tbDisc.Text) ? 0 : Convert.ToDecimal(tbDisc.Text.Replace('.', ','));
            product.Name = tbProduct.Text;
            product.Price = string.IsNullOrEmpty(tbPrice.Text) ? 0 : Convert.ToDecimal(tbPrice.Text.Replace('.', ','));
            product.Total = string.IsNullOrEmpty(tbTotal.Text) ? 0 : Convert.ToDecimal(tbTotal.Text.Replace('.', ','));
            product.CategoryId = _categories.FirstOrDefault(c => c.Name == cbCategory.SelectedItem.ToString()).Id;
            _productRepository.AddOrUpdate(product);
            Close();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void tbPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal price = string.IsNullOrEmpty(tbPrice.Text)
                    ? 0
                    : Convert.ToDecimal(tbPrice.Text.Replace('.', ','));
                decimal add = string.IsNullOrEmpty(tbAdd.Text) ? 0 : Convert.ToDecimal(tbAdd.Text.Replace('.', ','));
                decimal disc = string.IsNullOrEmpty(tbDisc.Text) ? 0 : Convert.ToDecimal(tbDisc.Text.Replace('.', ','));
                decimal total = price * ((100 + add - disc) / 100);
                tbTotal.Text = total.ToString("#.00");
            }
            catch
            {
                //nothing to do, wait for next user actions
            }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }
    }
}