namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    partial class SupplierForm
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
            lblCompanyName = new Label();
            label2 = new Label();
            lblPhone = new Label();
            lblAddress = new Label();
            txtCompanyName = new TextBox();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtContactName = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvSupplier = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).BeginInit();
            SuspendLayout();
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Location = new Point(232, 53);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(199, 32);
            lblCompanyName.TabIndex = 0;
            lblCompanyName.Text = "Company Name :";
            lblCompanyName.Click += lblCompanyName_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(232, 109);
            label2.Name = "label2";
            label2.Size = new Size(179, 32);
            label2.TabIndex = 1;
            label2.Text = "Contact Name :";
            label2.Click += label2_Click;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(232, 179);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(94, 32);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone :";
            lblPhone.Click += lblPhone_Click;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(232, 240);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(110, 32);
            lblAddress.TabIndex = 3;
            lblAddress.Text = "Address :";
            lblAddress.Click += lblAddress_Click;
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(474, 53);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(200, 39);
            txtCompanyName.TabIndex = 4;
            txtCompanyName.TextChanged += txtCompanyName_TextChanged;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(474, 240);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(200, 39);
            txtAddress.TabIndex = 5;
            txtAddress.TextChanged += txtAddress_TextChanged;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(474, 176);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 39);
            txtPhone.TabIndex = 6;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtContactName
            // 
            txtContactName.Location = new Point(474, 109);
            txtContactName.Name = "txtContactName";
            txtContactName.Size = new Size(200, 39);
            txtContactName.TabIndex = 7;
            txtContactName.TextChanged += txtContactName_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(87, 309);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 46);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "ADD";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(358, 309);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 46);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(626, 309);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 46);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvSupplier
            // 
            dgvSupplier.AllowUserToAddRows = false;
            dgvSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSupplier.Location = new Point(12, 376);
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.ReadOnly = true;
            dgvSupplier.RowHeadersVisible = false;
            dgvSupplier.RowHeadersWidth = 82;
            dgvSupplier.Size = new Size(776, 134);
            dgvSupplier.TabIndex = 11;
            dgvSupplier.CellContentClick += dgvSupplier_CellContentClick;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 522);
            Controls.Add(dgvSupplier);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtContactName);
            Controls.Add(txtPhone);
            Controls.Add(txtAddress);
            Controls.Add(txtCompanyName);
            Controls.Add(lblAddress);
            Controls.Add(lblPhone);
            Controls.Add(label2);
            Controls.Add(lblCompanyName);
            Name = "SupplierForm";
            Text = "SupplierForm";
            Load += SupplierForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtContactName_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblAddress_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblPhone_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblCompanyName_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label lblCompanyName;
        private Label label2;
        private Label lblPhone;
        private Label lblAddress;
        private TextBox txtCompanyName;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtContactName;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvSupplier;
    }
}