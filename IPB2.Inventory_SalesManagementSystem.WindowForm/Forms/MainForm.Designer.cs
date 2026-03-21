namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    partial class MainForm
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
            lblTexttitle = new Label();
            btnSupplier = new Button();
            btnProduct = new Button();
            btnCategory = new Button();
            btnStaff = new Button();
            btnStock = new Button();
            btnSales = new Button();
            btnReport = new Button();
            SuspendLayout();
            // 
            // lblTexttitle
            // 
            lblTexttitle.AutoSize = true;
            lblTexttitle.Location = new Point(210, 32);
            lblTexttitle.Name = "lblTexttitle";
            lblTexttitle.Size = new Size(280, 32);
            lblTexttitle.TabIndex = 0;
            lblTexttitle.Text = "Inventory & Sales System  ";
            lblTexttitle.Click += lblTexttitle_Click;
            // 
            // btnSupplier
            // 
            btnSupplier.Location = new Point(262, 83);
            btnSupplier.Name = "btnSupplier";
            btnSupplier.Size = new Size(150, 46);
            btnSupplier.TabIndex = 1;
            btnSupplier.Text = "Supplier";
            btnSupplier.UseVisualStyleBackColor = true;
            btnSupplier.Click += btnSupplier_Click;
            // 
            // btnProduct
            // 
            btnProduct.Location = new Point(262, 135);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(150, 46);
            btnProduct.TabIndex = 2;
            btnProduct.Text = "Product";
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnCategory
            // 
            btnCategory.Location = new Point(262, 187);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(150, 46);
            btnCategory.TabIndex = 3;
            btnCategory.Text = "Category";
            btnCategory.UseVisualStyleBackColor = true;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnStaff
            // 
            btnStaff.Location = new Point(262, 239);
            btnStaff.Name = "btnStaff";
            btnStaff.Size = new Size(150, 46);
            btnStaff.TabIndex = 4;
            btnStaff.Text = "Staff";
            btnStaff.UseVisualStyleBackColor = true;
            btnStaff.Click += btnStaff_Click;
            // 
            // btnStock
            // 
            btnStock.Location = new Point(262, 291);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(150, 46);
            btnStock.TabIndex = 5;
            btnStock.Text = "Stock";
            btnStock.UseVisualStyleBackColor = true;
            btnStock.Click += btnStock_Click;
            // 
            // btnSales
            // 
            btnSales.Location = new Point(262, 343);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(150, 46);
            btnSales.TabIndex = 6;
            btnSales.Text = "Sales";
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;
            // 
            // btnReport
            // 
            btnReport.Location = new Point(262, 395);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(150, 46);
            btnReport.TabIndex = 7;
            btnReport.Text = "Report";
            btnReport.UseVisualStyleBackColor = true;
            btnReport.Click += btnReport_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReport);
            Controls.Add(btnSales);
            Controls.Add(btnStock);
            Controls.Add(btnStaff);
            Controls.Add(btnCategory);
            Controls.Add(btnProduct);
            Controls.Add(btnSupplier);
            Controls.Add(lblTexttitle);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTexttitle;
        private Button btnSupplier;
        private Button btnProduct;
        private Button btnCategory;
        private Button btnStaff;
        private Button btnStock;
        private Button btnSales;
        private Button btnReport;
    }
}