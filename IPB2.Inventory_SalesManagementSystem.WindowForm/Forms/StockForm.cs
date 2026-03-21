using System;
using System.Linq;
using System.Windows.Forms;
using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Services;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    public partial class StockForm : Form
    {
        private readonly ProductService _productService = new ProductService();
        private readonly StockService _stockService = new StockService();

        public StockForm()
        {
            InitializeComponent();
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            RefreshGrid();
        }

        // ================= LOAD PRODUCTS =================
        private void LoadProducts()
        {
            cmbProduct.DataSource = _productService.GetAll();
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
        }

        // ================= STOCK IN =================
        private void btnStockIn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Enter a valid quantity!");
                return;
            }

            var product = (Product)cmbProduct.SelectedItem;

            _stockService.StockIn(product.ProductID, qty);
            MessageBox.Show("Stock Added!");
            RefreshGrid();
            txtQuantity.Clear();
        }

        // ================= STOCK OUT =================
        private void btnStockOut_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Enter a valid quantity!");
                return;
            }

            var product = (Product)cmbProduct.SelectedItem;

            if (qty > product.QuantityInStock)
            {
                MessageBox.Show("Not enough stock!");
                return;
            }

            _stockService.StockOut(product.ProductID, qty);
            MessageBox.Show("Stock Removed!");
            RefreshGrid();
            txtQuantity.Clear();
        }

        // ================= REFRESH DATAGRID =================
        private void RefreshGrid()
        {
            dgvStock.DataSource = null;
            dgvStock.DataSource = _productService.GetAll()
                .Select(p => new
                {
                    p.ProductID,
                    p.ProductName,
                    p.QuantityInStock,
                    p.Price
                }).ToList();
        }
    }
}