using CreditSales.Data.Models;
using CreditSales.Data.Repository;
using System.Windows.Forms;

namespace CreditSales.Interface
{
    public partial class AddCategoryForm : Form
    {
        private Category category;
        private CategoryRepository _categoryRepository = new CategoryRepository();

        public AddCategoryForm()
        {
            InitializeComponent();
            toolTip.SetToolTip(tbCategory, "Название категории");
            toolTip.SetToolTip(btnSave, "Сохранить");
            toolTip.SetToolTip(btnClose, "Отмена");
        }

        public AddCategoryForm(Category category) : this()
        {
            this.category = category;
            tbCategory.Text = category.Name;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCategory.Text))
            {
                MessageBox.Show("Введите название категории!", "Введите данные!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (category == null) category = new Category();
            category.Name = tbCategory.Text;
            _categoryRepository.AddOrUpdate(category);
            Close();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}