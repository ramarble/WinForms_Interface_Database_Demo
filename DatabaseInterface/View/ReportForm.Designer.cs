namespace DatabaseInterfaceDemo.View
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.buttonUpdateFilters = new System.Windows.Forms.Button();
            this.CategoryFilterCheckedBoxes = new System.Windows.Forms.CheckedListBox();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RA4_Ejercicios.View.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(600, 379);
            this.reportViewer1.TabIndex = 0;
            // 
            // buttonUpdateFilters
            // 
            this.buttonUpdateFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateFilters.Location = new System.Drawing.Point(517, 500);
            this.buttonUpdateFilters.Name = "buttonUpdateFilters";
            this.buttonUpdateFilters.Size = new System.Drawing.Size(192, 44);
            this.buttonUpdateFilters.TabIndex = 1;
            this.buttonUpdateFilters.Text = "Filtrar por categoría";
            this.buttonUpdateFilters.UseVisualStyleBackColor = true;
            this.buttonUpdateFilters.Click += new System.EventHandler(this.button1_Click);
            // 
            // CategoryFilterCheckedBoxes
            // 
            this.CategoryFilterCheckedBoxes.FormattingEnabled = true;
            this.CategoryFilterCheckedBoxes.Location = new System.Drawing.Point(12, 500);
            this.CategoryFilterCheckedBoxes.Name = "CategoryFilterCheckedBoxes";
            this.CategoryFilterCheckedBoxes.Size = new System.Drawing.Size(120, 49);
            this.CategoryFilterCheckedBoxes.TabIndex = 3;
            // 
            // nudStock
            // 
            this.nudStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudStock.Location = new System.Drawing.Point(138, 524);
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(124, 26);
            this.nudStock.TabIndex = 4;
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStock.Location = new System.Drawing.Point(138, 500);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(124, 20);
            this.labelStock.TabIndex = 6;
            this.labelStock.Text = "Stock superior a";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(287, 500);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(127, 20);
            this.labelPrice.TabIndex = 7;
            this.labelPrice.Text = "Precio superior a";
            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrice.Location = new System.Drawing.Point(290, 524);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(124, 26);
            this.nudPrice.TabIndex = 8;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.nudStock);
            this.Controls.Add(this.CategoryFilterCheckedBoxes);
            this.Controls.Add(this.buttonUpdateFilters);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button buttonUpdateFilters;
        private System.Windows.Forms.CheckedListBox CategoryFilterCheckedBoxes;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.NumericUpDown nudPrice;
    }
}