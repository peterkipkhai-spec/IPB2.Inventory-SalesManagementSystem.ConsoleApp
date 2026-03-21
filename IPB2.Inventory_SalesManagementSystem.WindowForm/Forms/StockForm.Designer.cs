namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    partial class StockForm
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
            lblProduct = new Label();
            lblQuantity = new Label();
            btnStockIn = new Button();
            btnStockOut = new Button();
            dgvStock = new DataGridView();
            cmbProduct = new ComboBox();
            txtQuantity = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            SuspendLayout();
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(183, 41);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(108, 32);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Product :";
            lblProduct.Click += lblProduct_Click;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(183, 114);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(118, 32);
            lblQuantity.TabIndex = 1;
            lblQuantity.Text = "Quantity :";
            lblQuantity.Click += lblQuantity_Click;
            // 
            // btnStockIn
            // 
            btnStockIn.Location = new Point(183, 206);
            btnStockIn.Name = "btnStockIn";
            btnStockIn.Size = new Size(150, 46);
            btnStockIn.TabIndex = 2;
            btnStockIn.Text = "Stock In";
            btnStockIn.UseVisualStyleBackColor = true;
            btnStockIn.Click += btnStockIn_Click;
            // 
            // btnStockOut
            // 
            btnStockOut.Location = new Point(401, 206);
            btnStockOut.Name = "btnStockOut";
            btnStockOut.Size = new Size(150, 46);
            btnStockOut.TabIndex = 3;
            btnStockOut.Text = "Stock Out";
            btnStockOut.UseVisualStyleBackColor = true;
            btnStockOut.Click += btnStockOut_Click;
            // 
            // dgvStock
            // 
            dgvStock.AllowUserToAddRows = false;
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Location = new Point(12, 282);
            dgvStock.Name = "dgvStock";
            dgvStock.ReadOnly = true;
            dgvStock.RowHeadersVisible = false;
            dgvStock.RowHeadersWidth = 82;
            dgvStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStock.Size = new Size(776, 128);
            dgvStock.TabIndex = 4;
            dgvStock.CellContentClick += dgvStock_CellContentClick;
            // 
            // cmbProduct
            // 
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(391, 41);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(242, 40);
            cmbProduct.TabIndex = 5;
            cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(391, 111);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(200, 39);
            txtQuantity.TabIndex = 6;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // StockForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtQuantity);
            Controls.Add(cmbProduct);
            Controls.Add(dgvStock);
            Controls.Add(btnStockOut);
            Controls.Add(btnStockIn);
            Controls.Add(lblQuantity);
            Controls.Add(lblProduct);
            Name = "StockForm";
            Text = "StockForm";
            Load += StockForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblQuantity_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblProduct_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label lblProduct;
        private Label lblQuantity;
        private Button btnStockIn;
        private Button btnStockOut;
        private DataGridView dgvStock;
        private ComboBox cmbProduct;
        private TextBox txtQuantity;
    }
}