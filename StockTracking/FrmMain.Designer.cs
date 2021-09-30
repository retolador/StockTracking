
namespace StockTracking
{
    partial class FrmMain
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
            this.btnEmployee = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.butAddStock = new System.Windows.Forms.Button();
            this.butCategory = new System.Windows.Forms.Button();
            this.butDeleted = new System.Windows.Forms.Button();
            this.butCustomer = new System.Windows.Forms.Button();
            this.butProduct = new System.Windows.Forms.Button();
            this.butSales = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Image = global::StockTracking.Properties.Resources.employee_management;
            this.btnEmployee.Location = new System.Drawing.Point(640, 224);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(167, 195);
            this.btnEmployee.TabIndex = 7;
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // butExit
            // 
            this.butExit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butExit.Image = global::StockTracking.Properties.Resources.exit;
            this.butExit.Location = new System.Drawing.Point(331, 452);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(167, 195);
            this.butExit.TabIndex = 6;
            this.butExit.Text = "Exit";
            this.butExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butExit.UseVisualStyleBackColor = false;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butAddStock
            // 
            this.butAddStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.butAddStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAddStock.Image = global::StockTracking.Properties.Resources.addstock;
            this.butAddStock.Location = new System.Drawing.Point(31, 224);
            this.butAddStock.Name = "butAddStock";
            this.butAddStock.Size = new System.Drawing.Size(167, 195);
            this.butAddStock.TabIndex = 5;
            this.butAddStock.Text = "Add Stock";
            this.butAddStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butAddStock.UseVisualStyleBackColor = false;
            this.butAddStock.Click += new System.EventHandler(this.butAddStock_Click);
            // 
            // butCategory
            // 
            this.butCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCategory.Image = global::StockTracking.Properties.Resources.categoria;
            this.butCategory.Location = new System.Drawing.Point(229, 224);
            this.butCategory.Name = "butCategory";
            this.butCategory.Size = new System.Drawing.Size(167, 195);
            this.butCategory.TabIndex = 4;
            this.butCategory.Text = "Category";
            this.butCategory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butCategory.UseVisualStyleBackColor = false;
            this.butCategory.Click += new System.EventHandler(this.butCategory_Click);
            // 
            // butDeleted
            // 
            this.butDeleted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.butDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butDeleted.Image = global::StockTracking.Properties.Resources.papelera;
            this.butDeleted.Location = new System.Drawing.Point(442, 224);
            this.butDeleted.Name = "butDeleted";
            this.butDeleted.Size = new System.Drawing.Size(167, 195);
            this.butDeleted.TabIndex = 3;
            this.butDeleted.Text = "Deleted";
            this.butDeleted.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butDeleted.UseVisualStyleBackColor = false;
            this.butDeleted.Click += new System.EventHandler(this.butDeleted_Click);
            // 
            // butCustomer
            // 
            this.butCustomer.BackColor = System.Drawing.Color.Lime;
            this.butCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butCustomer.Image = global::StockTracking.Properties.Resources.customer;
            this.butCustomer.Location = new System.Drawing.Point(99, 23);
            this.butCustomer.Name = "butCustomer";
            this.butCustomer.Size = new System.Drawing.Size(167, 195);
            this.butCustomer.TabIndex = 2;
            this.butCustomer.Text = "Customer";
            this.butCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butCustomer.UseVisualStyleBackColor = false;
            this.butCustomer.Click += new System.EventHandler(this.butCustomer_Click);
            // 
            // butProduct
            // 
            this.butProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.butProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butProduct.ForeColor = System.Drawing.Color.Fuchsia;
            this.butProduct.Image = global::StockTracking.Properties.Resources.product;
            this.butProduct.Location = new System.Drawing.Point(319, 23);
            this.butProduct.Name = "butProduct";
            this.butProduct.Size = new System.Drawing.Size(167, 195);
            this.butProduct.TabIndex = 1;
            this.butProduct.Text = "Product";
            this.butProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butProduct.UseVisualStyleBackColor = false;
            this.butProduct.Click += new System.EventHandler(this.butProduct_Click);
            // 
            // butSales
            // 
            this.butSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.butSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSales.Image = global::StockTracking.Properties.Resources.sales1;
            this.butSales.Location = new System.Drawing.Point(530, 23);
            this.butSales.Name = "butSales";
            this.butSales.Size = new System.Drawing.Size(167, 195);
            this.butSales.TabIndex = 0;
            this.butSales.Text = "Sales";
            this.butSales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.butSales.UseVisualStyleBackColor = false;
            this.butSales.Click += new System.EventHandler(this.butSales_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 659);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butAddStock);
            this.Controls.Add(this.butCategory);
            this.Controls.Add(this.butDeleted);
            this.Controls.Add(this.butCustomer);
            this.Controls.Add(this.butProduct);
            this.Controls.Add(this.butSales);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Tracking";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butSales;
        private System.Windows.Forms.Button butProduct;
        private System.Windows.Forms.Button butCustomer;
        private System.Windows.Forms.Button butAddStock;
        private System.Windows.Forms.Button butCategory;
        private System.Windows.Forms.Button butDeleted;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button btnEmployee;
    }
}