using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using IPB2.Inventory_SalesManagementSystem.DB.Models;
using IPB2.Inventory_SalesManagementSystem.WindowForm.Services;

namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    public partial class SupplierForm : Form
    {
        private readonly ISupplierService _supplierService;

        public SupplierForm(ISupplierService supplierService)
        {
            InitializeComponent();
            _supplierService = supplierService;
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        // ================= LOAD SUPPLIERS =================
        private void LoadSuppliers()
        {
            var suppliers = _supplierService.GetAll() as IEnumerable<Supplier>;
            if (suppliers == null)
            {
                dgvSupplier.DataSource = null;
                return;
            }

            dgvSupplier.DataSource = suppliers
                .Select(s => new
                {
                    s.SupplierID,
                    s.CompanyName,
                    s.ContactName,
                    s.Phone,
                    s.Address
                })
                .ToList();
        }

        // ================= ADD SUPPLIER =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var supplier = new Supplier
            {
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                Phone = txtPhone.Text,
                Address = txtAddress.Text
            };

            _supplierService.Add(supplier);
            MessageBox.Show("Supplier Added!");
            LoadSuppliers();
            ClearForm();
        }

        // ================= UPDATE SUPPLIER =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.CurrentRow == null) return;

            var supplier = (Supplier)dgvSupplier.CurrentRow.DataBoundItem;

            supplier.CompanyName = txtCompanyName.Text;
            supplier.ContactName = txtContactName.Text;
            supplier.Phone = txtPhone.Text;
            supplier.Address = txtAddress.Text;

            _supplierService.Update(supplier);
            MessageBox.Show("Supplier Updated!");
            LoadSuppliers();
        }

        // ================= DELETE SUPPLIER =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSupplier.CurrentRow == null) return;

            var supplier = (Supplier)dgvSupplier.CurrentRow.DataBoundItem;

            _supplierService.Delete(supplier.SupplierID);
            MessageBox.Show("Supplier Deleted!");
            LoadSuppliers();
            ClearForm();
        }

        // ================= SELECT ROW =================
        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSupplier.CurrentRow == null) return;

            var s = (Supplier)dgvSupplier.CurrentRow.DataBoundItem;
            txtCompanyName.Text = s.CompanyName;
            txtContactName.Text = s.ContactName;
            txtPhone.Text = s.Phone;
            txtAddress.Text = s.Address;
        }

        // ================= CLEAR FORM =================
        private void ClearForm()
        {
            txtCompanyName.Clear();
            txtContactName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }
    }
}