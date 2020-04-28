using System.Windows.Forms;

namespace CreditSales.Interface
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}