using System;
using System.Linq;
using System.Windows.Forms;
using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Services;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    public partial class ProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;

        public ProductForm(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            InitializeComponent();
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Load Products into DataGridView
            dgvProduct.DataSource = _productService.GetAll();

            // Load Categories
            cmbCategory.DataSource = _categoryService.GetAll();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";

            // Load Suppliers
            cmbSupplier.DataSource = _supplierService.GetAll();
            cmbSupplier.DisplayMember = "CompanyName";
            cmbSupplier.ValueMember = "SupplierID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new Product
                {
                    ProductName = txtProductName.Text,
                    CategoryID = (int)cmbCategory.SelectedValue,
                    SupplierID = (int)cmbSupplier.SelectedValue,
                    Price = decimal.Parse(txtPrice.Text),
                    QuantityInStock = int.Parse(txtQuantity.Text)
                };

                _productService.Add(product);
                MessageBox.Show("Product Added!");
                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow == null) return;

            var product = (Product)dgvProduct.CurrentRow.DataBoundItem;

            product.ProductName = txtProductName.Text;
            product.CategoryID = (int)cmbCategory.SelectedValue;
            product.SupplierID = (int)cmbSupplier.SelectedValue;
            product.Price = decimal.Parse(txtPrice.Text);
            product.QuantityInStock = int.Parse(txtQuantity.Text);

            _productService.Update(product);
            MessageBox.Show("Product Updated!");
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow == null) return;

            var product = (Product)dgvProduct.CurrentRow.DataBoundItem;

            _productService.Delete(product.ProductID);
            MessageBox.Show("Product Deleted!");
            LoadData();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduct.CurrentRow == null) return;

            var p = (Product)dgvProduct.CurrentRow.DataBoundItem;

            txtProductName.Text = p.ProductName;
            cmbCategory.SelectedValue = p.CategoryID;
            cmbSupplier.SelectedValue = p.SupplierID;
            txtPrice.Text = p.Price.ToString();
            txtQuantity.Text = p.QuantityInStock.ToString();
        }

        private void ClearForm()
        {
            txtProductName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }
    }
}