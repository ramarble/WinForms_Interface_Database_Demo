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
            this.components = new System.ComponentModel.Container();
            this.ReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comboboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComboBox_ReportSelect = new System.Windows.Forms.ComboBox();
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.labelLoadData = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportViewer
            // 
            this.ReportViewer.LocalReport.ReportEmbeddedResource = "RA4_Ejercicios.View.Report1.rdlc";
            this.ReportViewer.Location = new System.Drawing.Point(125, 69);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.ServerReport.BearerToken = null;
            this.ReportViewer.Size = new System.Drawing.Size(1282, 636);
            this.ReportViewer.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboboxToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 26);
            // 
            // comboboxToolStripMenuItem
            // 
            this.comboboxToolStripMenuItem.Name = "comboboxToolStripMenuItem";
            this.comboboxToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.comboboxToolStripMenuItem.Text = "combobox";
            // 
            // ComboBox_ReportSelect
            // 
            this.ComboBox_ReportSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_ReportSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_ReportSelect.FormattingEnabled = true;
            this.ComboBox_ReportSelect.Location = new System.Drawing.Point(125, 31);
            this.ComboBox_ReportSelect.Name = "ComboBox_ReportSelect";
            this.ComboBox_ReportSelect.Size = new System.Drawing.Size(536, 32);
            this.ComboBox_ReportSelect.TabIndex = 2;
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.AccessibleDescription = "Botón para cargar datos desde archivo";
            this.buttonLoadData.AccessibleName = "Botón Cargar desde Archivo";
            this.buttonLoadData.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonLoadData.Enabled = false;
            this.buttonLoadData.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonLoadData.Location = new System.Drawing.Point(667, 31);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(112, 32);
            this.buttonLoadData.TabIndex = 3;
            this.buttonLoadData.Text = "Cargar datos";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            // 
            // labelLoadData
            // 
            this.labelLoadData.AutoSize = true;
            this.labelLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoadData.Location = new System.Drawing.Point(785, 34);
            this.labelLoadData.Name = "labelLoadData";
            this.labelLoadData.Size = new System.Drawing.Size(301, 24);
            this.labelLoadData.TabIndex = 4;
            this.labelLoadData.Text = "Carga datos de la lista desplegable";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 664);
            this.Controls.Add(this.labelLoadData);
            this.Controls.Add(this.buttonLoadData);
            this.Controls.Add(this.ComboBox_ReportSelect);
            this.Controls.Add(this.ReportViewer);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem comboboxToolStripMenuItem;
        private System.Windows.Forms.ComboBox ComboBox_ReportSelect;
        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.Label labelLoadData;
    }
}