using System;
using System.Windows.Forms;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTexttitle.Text = "Inventory & Sales Management System";
        }

        private void lblTexttitle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Inventory System");
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            using (var frm = new SupplierForm())
            {
                frm.ShowDialog();
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            using (var frm = new ProductForm())
            {
                frm.ShowDialog();
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            using (var frm = new CategoryForm())
            {
                frm.ShowDialog();
            }
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            using (var frm = new StaffForm())
            {
                frm.ShowDialog();
            }
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            using (var frm = new StockForm())
            {
                frm.ShowDialog();
            }
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            using (var frm = new SalesForm())
            {
                frm.ShowDialog();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            using (var frm = new ReportForm())
            {
                frm.ShowDialog();
            }
        }
    }
}