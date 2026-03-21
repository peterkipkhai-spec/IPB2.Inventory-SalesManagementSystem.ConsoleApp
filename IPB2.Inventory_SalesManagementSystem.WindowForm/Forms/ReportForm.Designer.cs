namespace IPB2.Inventory_SalesManagementSystem.WindowForm.Forms
{
    partial class ReportForm
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
            btnLowStock = new Button();
            btnSaleReport = new Button();
            dgvReport = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // btnLowStock
            // 
            btnLowStock.Location = new Point(161, 57);
            btnLowStock.Name = "btnLowStock";
            btnLowStock.Size = new Size(150, 46);
            btnLowStock.TabIndex = 0;
            btnLowStock.Text = "Low Stock";
            btnLowStock.UseVisualStyleBackColor = true;
            btnLowStock.Click += btnLowStock_Click;
            // 
            // btnSaleReport
            // 
            btnSaleReport.Location = new Point(448, 57);
            btnSaleReport.Name = "btnSaleReport";
            btnSaleReport.Size = new Size(150, 46);
            btnSaleReport.TabIndex = 1;
            btnSaleReport.Text = "Sales Report";
            btnSaleReport.UseVisualStyleBackColor = true;
            btnSaleReport.Click += btnSaleReport_Click;
            // 
            // dgvReport
            // 
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(12, 154);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersWidth = 82;
            dgvReport.Size = new Size(776, 284);
            dgvReport.TabIndex = 2;
            dgvReport.CellContentClick += dgvReport_CellContentClick;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvReport);
            Controls.Add(btnSaleReport);
            Controls.Add(btnLowStock);
            Name = "ReportForm";
            Text = "ReportForm";
            Load += ReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLowStock;
        private Button btnSaleReport;
        private DataGridView dgvReport;
    }
}