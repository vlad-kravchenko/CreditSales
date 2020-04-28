using CreditSales.Data;
using CreditSales.Data.Models;
using CreditSales.Data.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CreditSales.Interface
{
    public partial class Products : Form
    {
        private ProductRepository _productRepository = new ProductRepository();
        private CategoryRepository _categoryRepository = new CategoryRepository();
        private Product _currentProduct;
        private Category _currentCategory;
        private bool selectProductMode;

        public Products()
        {
            InitializeComponent();

            LoadGrid();

            FillCategoriesCombo();
        }

        private void FillCategoriesCombo()
        {
            cbCategory.Items.Clear();
            cbCategory.Items.Add("Все");
            foreach (var cat in _categoryRepository.GetCategories())
            {
                cbCategory.Items.Add(cat.Name);
            }
        }

        public Products(bool select) : this()
        {
            selectProductMode = select;
        }

        private void LoadGrid()
        {
            gridProducts.Rows.Clear();
            var products = _productRepository.GetProducts();
            foreach (var product in products)
            {
                var row = new DataGridViewRow();
                row.Tag = product;
                for (int i = 0; i < 7; i++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = product.Number;
                row.Cells[1].Value = product.Name;
                row.Cells[2].Value = product.Category.Name;
                row.Cells[3].Value = product.Price;
                row.Cells[4].Value = product.AddAmount;
                row.Cells[5].Value = product.Discount;
                row.Cells[6].Value = product.Total;
                gridProducts.Rows.Add(row);
            }

            gridCategories.Rows.Clear();
            var categories = _categoryRepository.GetCategories();
            foreach (var cat in categories)
            {
                var row = new DataGridViewRow();
                row.Tag = cat;
                for (int i = 0; i < 1; i++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = cat.Name;
                gridCategories.Rows.Add(row);
            }

            FillCategoriesCombo();
        }

        private void gridProducts_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverRow = gridProducts.HitTest(e.X, e.Y).RowIndex;
                    _currentProduct = gridProducts.Rows[currentMouseOverRow].Tag as Product;
                    if (_currentProduct != null)
                    {
                        productsContextMenu.Show(gridProducts, e.Location);
                    }
                }
            }
            catch
            {
                //nothing to do, wait for next user actions
            }
        }

        private void gridCategories_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    int currentMouseOverRow = gridCategories.HitTest(e.X, e.Y).RowIndex;
                    _currentCategory = gridCategories.Rows[currentMouseOverRow].Tag as Category;
                    if (_currentCategory != null)
                    {
                        categoryContextMenu.Show(gridCategories, e.Location);
                    }
                }
                else
                {
                    int currentMouseOverRow = gridCategories.HitTest(e.X, e.Y).RowIndex;
                    if (gridCategories.Rows[currentMouseOverRow].Tag is Category)
                    {
                        _currentCategory = gridCategories.Rows[currentMouseOverRow].Tag as Category;
                    }
                }
            }
            catch
            {
                //nothing to do, wait for next user actions
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (selectProductMode && gridProducts.SelectedRows.Count == 1)
            {
                Storage.SelectedProduct = gridProducts.SelectedRows[0].Tag as Product;
                Close();
            }
            else
            {
                Close();
            }
        }

        private void menuStripNewProduct_Click(object sender, System.EventArgs e)
        {
            if (_categoryRepository.GetCategories().Count == 0)
            {
                MessageBox.Show("В базе данных отсутствуют категории!", "Создайте категорию!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = new AddProductForm();
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void menuStripEditProduct_Click(object sender, System.EventArgs e)
        {
            if (_currentProduct == null) return;

            var form = new AddProductForm(_currentProduct);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void menuStripDeleteProduct_Click(object sender, System.EventArgs e)
        {
            if (_currentProduct == null) return;

            if (MessageBox.Show("Вы уверенны, что хотите удалить товар " + _currentProduct.Name + "?", "Удаление товара", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _productRepository.Delete(_currentProduct);
                _currentProduct = null;
                LoadGrid();
            }
        }

        private void menuStripLoad_Click(object sender, System.EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.Cancel) return;

            string filename = dlg.FileName;
            if (!File.Exists(filename)) return;

            List<string> lines = File.ReadAllLines(filename).ToList();

            int count = 0;
            foreach (var line in lines)
            {
                var candidate = line.Split(';');
                try
                {
                    var product = new Product
                    {
                        Number = Convert.ToInt32(candidate[0]),
                        CategoryId = Convert.ToInt32(candidate[1]),
                        Name = candidate[2],
                        Price = Convert.ToDecimal(candidate[3].Replace('.', ',')),
                        AddAmount = Convert.ToDecimal(candidate[4].Replace('.', ',')),
                        Discount = Convert.ToDecimal(candidate[5].Replace('.', ',')),
                        Total = Convert.ToDecimal(candidate[6].Replace('.', ','))
                    };
                    _productRepository.AddOrUpdate(product);
                    count++;
                }
                catch
                {
                    //cannot parse product from the line
                }
            }

            if (count != 0)
            {
                MessageBox.Show("Загрузка " + count + " продуктов завершена. " + 
                                (lines.Count - count).ToString() + " линий пропущено. Проверьте корректность загруженных данных.", 
                    "Загрузка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadGrid();
        }

        private void toolStripNewCategory_Click(object sender, System.EventArgs e)
        {
            var form = new AddCategoryForm();
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void toolStripEditCategory_Click(object sender, System.EventArgs e)
        {
            if (_currentCategory == null) return;

            var form = new AddCategoryForm(_currentCategory);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void toolStripDeleteCategory_Click(object sender, System.EventArgs e)
        {
            if (_currentCategory == null) return;
            if (_productRepository.GetProducts().Any(p => p.CategoryId == _currentCategory.Id))
            {
                MessageBox.Show("Невозможно удалить категорию, так как есть принадлежащие к ней продукты!");
                return;
            }

            if (MessageBox.Show("Вы уверенны, что хотите удалить категорию " + _currentCategory.Name + "?", "Удаление категории", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _categoryRepository.Delete(_currentCategory);
                _currentCategory = null;
                LoadGrid();
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (gridCategories.SelectedRows.Count != 0)
            {
                _currentCategory = gridCategories.SelectedRows[0].Tag as Category;
            }
            else
            {
                return;
            }

            if (_currentCategory == null) return;

            if (_productRepository.GetProducts().Any(p => p.CategoryId == _currentCategory.Id))
            {
                MessageBox.Show("Невозможно удалить категорию, так как есть принадлежащие к ней продукты!");
                return;
            }
            if (MessageBox.Show("Вы уверенны, что хотите удалить категорию " + _currentCategory.Name + "?", "Удаление категории", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _categoryRepository.Delete(_currentCategory);
                _currentCategory = null;
                LoadGrid();
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (gridCategories.SelectedRows.Count != 0)
            {
                _currentCategory = gridCategories.SelectedRows[0].Tag as Category;
            }
            else
            {
                return;
            }
            if (_currentCategory == null) return;

            var form = new AddCategoryForm(_currentCategory);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            var form = new AddCategoryForm();
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridProducts.SelectedRows.Count != 0)
            {
                _currentProduct = gridProducts.SelectedRows[0].Tag as Product;
            }
            else
            {
                return;
            }
            if (MessageBox.Show("Вы уверенны, что хотите удалить " + gridProducts.SelectedRows.Count + " товара(-ов)?", "Удаление товаров", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = 0; i < gridProducts.SelectedRows.Count; i++)
                {
                    _productRepository.Delete(gridProducts.SelectedRows[i].Tag as Product);
                }
                _currentProduct = null;
                LoadGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridProducts.SelectedRows.Count != 0)
            {
                _currentProduct = gridProducts.SelectedRows[0].Tag as Product;
            }
            else
            {
                return;
            }

            var form = new AddProductForm(_currentProduct);
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_categoryRepository.GetCategories().Count == 0)
            {
                MessageBox.Show("В базе данных отсутствуют категории!", "Создайте категорию!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = new AddProductForm();
            if (form.ShowDialog() != DialogResult.Ignore)
            {
                LoadGrid();
            }
        }

        private void cbCategory_TextChanged(object sender, EventArgs e)
        {
            string selectedCat = cbCategory.SelectedItem.ToString();
            if (selectedCat == "Все")
            {
                LoadGrid();
                return;
            }
            var cat = _categoryRepository.GetCategories().FirstOrDefault(c => c.Name == selectedCat);
            if (cat == null) return;

            gridProducts.Rows.Clear();
            var products = _productRepository.GetProducts().Where(p => p.CategoryId == cat.Id);
            foreach (var product in products)
            {
                var row = new DataGridViewRow();
                row.Tag = product;
                for (int i = 0; i < 7; i++) row.Cells.Add(new DataGridViewTextBoxCell());
                row.Cells[0].Value = product.Number;
                row.Cells[1].Value = product.Name;
                row.Cells[2].Value = product.Category.Name;
                row.Cells[3].Value = product.Price;
                row.Cells[4].Value = product.AddAmount;
                row.Cells[5].Value = product.Discount;
                row.Cells[6].Value = product.Total;
                gridProducts.Rows.Add(row);
            }
        }
    }
}