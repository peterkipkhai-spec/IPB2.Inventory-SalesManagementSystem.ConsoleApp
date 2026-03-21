using System;
using System.Linq;
using System.Windows.Forms;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Data;
using Microsoft.EntityFrameworkCore;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.ReadOnly = true;
        }

        // ================= LOW STOCK =================
        private void btnLowStock_Click(object sender, EventArgs e)
        {
            using (var db = AppDbContextFactory.Create())
            {
                var lowStock = db.Products
                    .Where(p => p.QuantityInStock < 10)
                    .Select(p => new
                    {
                        p.ProductID,
                        p.ProductName,
                        p.QuantityInStock,
                        p.Price
                    })
                    .ToList();

                dgvReport.DataSource = lowStock;
            }
        }

        // ================= SALES REPORT =================
        private void btnSaleReport_Click(object sender, EventArgs e)
        {
            using (var db = AppDbContextFactory.Create())
            {
                var sales = db.Sales
                    .Include(s => s.Staff)
                    .Select(s => new
                    {
                        s.SaleID,
                        s.SaleDate,
                        StaffName = s.Staff.StaffName,
                        s.TotalAmount
                    })
                    .ToList();

                dgvReport.DataSource = sales;
            }
        }

        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional (not required)
        }
    }
}