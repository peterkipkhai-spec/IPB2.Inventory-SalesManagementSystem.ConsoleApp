using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
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
            var frm = _serviceProvider.GetRequiredService<SupplierForm>();
            frm.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<ProductForm>();
            frm.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<CategoryForm>();
            frm.ShowDialog();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<StaffForm>();
            frm.ShowDialog();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<StockForm>();
            frm.ShowDialog();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<SaleForm>();
            frm.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<ReportForm>();
            frm.ShowDialog();
        }
    }
}