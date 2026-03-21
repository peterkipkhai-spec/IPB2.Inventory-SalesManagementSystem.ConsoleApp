namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProduct = new DataGridView();
            lblProductName = new Label();
            lblCategory = new Label();
            lblSupplier = new Label();
            lblPrice = new Label();
            lblQuantity = new Label();
            cmbCategory = new ComboBox();
            cmbSupplier = new ComboBox();
            txtProductName = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // dgvProduct
            // 
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduct.Location = new Point(12, 12);
            dgvProduct.Name = "dgvProduct";
            dgvProduct.ReadOnly = true;
            dgvProduct.RowHeadersWidth = 82;
            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduct.Size = new Size(776, 191);
            dgvProduct.TabIndex = 0;
            dgvProduct.CellContentClick += dgvProduct_CellContentClick;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(170, 220);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(167, 32);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            lblProductName.Click += lblProductName_Click;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(170, 265);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(110, 32);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Category";
            lblCategory.Click += lblCategory_Click;
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(170, 311);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(102, 32);
            lblSupplier.TabIndex = 3;
            lblSupplier.Text = "Supplier";
            lblSupplier.Click += lblSupplier_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(170, 357);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(65, 32);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            lblPrice.Click += lblPrice_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(170, 402);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(106, 32);
            lblQuantity.TabIndex = 5;
            lblQuantity.Text = "Quantity";
            lblQuantity.Click += lblQuantity_Click;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(421, 265);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(242, 40);
            cmbCategory.TabIndex = 6;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // cmbSupplier
            // 
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.FormattingEnabled = true;
            cmbSupplier.Location = new Point(421, 311);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(242, 40);
            cmbSupplier.TabIndex = 7;
            cmbSupplier.SelectedIndexChanged += cmbSupplier_SelectedIndexChanged;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(421, 220);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(200, 39);
            txtProductName.TabIndex = 8;
            txtProductName.TextChanged += txtProductName_TextChanged;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(421, 357);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 39);
            txtPrice.TabIndex = 9;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(421, 402);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(200, 39);
            txtQuantity.TabIndex = 10;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(97, 493);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 46);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(341, 493);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 46);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(614, 493);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 46);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 556);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtQuantity);
            Controls.Add(txtPrice);
            Controls.Add(txtProductName);
            Controls.Add(cmbSupplier);
            Controls.Add(cmbCategory);
            Controls.Add(lblQuantity);
            Controls.Add(lblPrice);
            Controls.Add(lblSupplier);
            Controls.Add(lblCategory);
            Controls.Add(lblProductName);
            Controls.Add(dgvProduct);
            Name = "ProductForm";
            Text = "ProductForm";
            Load += ProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblQuantity_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblSupplier_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblCategory_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private DataGridView dgvProduct;
        private Label lblProductName;
        private Label lblCategory;
        private Label lblSupplier;
        private Label lblPrice;
        private Label lblQuantity;
        private ComboBox cmbCategory;
        private ComboBox cmbSupplier;
        private TextBox txtProductName;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}