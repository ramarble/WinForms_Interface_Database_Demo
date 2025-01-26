namespace DatabaseInterfaceDemo.View.ObjectCreationForms
{
    partial class FormCreateProduct
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cortarContextStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarContextStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarContextStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nudPricePerUnit = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblTypeOfUnit = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.nudID = new System.Windows.Forms.NumericUpDown();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.comboBoxUnitType = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudID)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cortarContextStripMenuItem,
            this.copiarContextStripMenuItem,
            this.pegarContextStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 70);
            // 
            // cortarContextStripMenuItem
            // 
            this.cortarContextStripMenuItem.Name = "cortarContextStripMenuItem";
            this.cortarContextStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarContextStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cortarContextStripMenuItem.Text = "Cortar";
            // 
            // copiarContextStripMenuItem
            // 
            this.copiarContextStripMenuItem.Name = "copiarContextStripMenuItem";
            this.copiarContextStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copiarContextStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.copiarContextStripMenuItem.Text = "Copiar";
            // 
            // pegarContextStripMenuItem
            // 
            this.pegarContextStripMenuItem.Name = "pegarContextStripMenuItem";
            this.pegarContextStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarContextStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.pegarContextStripMenuItem.Text = "Pegar";
            // 
            // nudPricePerUnit
            // 
            this.nudPricePerUnit.AccessibleDescription = "Introduce el Precio";
            this.nudPricePerUnit.AccessibleName = "Caja Precio";
            this.nudPricePerUnit.DecimalPlaces = 2;
            this.nudPricePerUnit.Location = new System.Drawing.Point(284, 160);
            this.nudPricePerUnit.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPricePerUnit.Name = "nudPricePerUnit";
            this.nudPricePerUnit.Size = new System.Drawing.Size(120, 29);
            this.nudPricePerUnit.TabIndex = 34;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Arial", 14F);
            this.lblPrice.Location = new System.Drawing.Point(49, 163);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(65, 22);
            this.lblPrice.TabIndex = 42;
            this.lblPrice.Text = "Precio";
            // 
            // tbNombre
            // 
            this.tbNombre.AccessibleDescription = "Introduce el nombre";
            this.tbNombre.AccessibleName = "Caja Texto Nombre";
            this.tbNombre.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbNombre.Location = new System.Drawing.Point(284, 49);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(11);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(367, 29);
            this.tbNombre.TabIndex = 31;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Arial", 14F);
            this.lblID.Location = new System.Drawing.Point(49, 238);
            this.lblID.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(115, 22);
            this.lblID.TabIndex = 41;
            this.lblID.Text = "Identificador";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Arial", 14F);
            this.lblStock.Location = new System.Drawing.Point(49, 201);
            this.lblStock.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(58, 22);
            this.lblStock.TabIndex = 40;
            this.lblStock.Text = "Stock";
            // 
            // lblTypeOfUnit
            // 
            this.lblTypeOfUnit.AutoSize = true;
            this.lblTypeOfUnit.Font = new System.Drawing.Font("Arial", 14F);
            this.lblTypeOfUnit.Location = new System.Drawing.Point(49, 126);
            this.lblTypeOfUnit.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblTypeOfUnit.Name = "lblTypeOfUnit";
            this.lblTypeOfUnit.Size = new System.Drawing.Size(138, 22);
            this.lblTypeOfUnit.TabIndex = 39;
            this.lblTypeOfUnit.Text = "Tipo de Unidad";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Arial", 14F);
            this.lblCategory.Location = new System.Drawing.Point(49, 88);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(92, 22);
            this.lblCategory.TabIndex = 38;
            this.lblCategory.Text = "Categoria";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 14F);
            this.lblNombre.Location = new System.Drawing.Point(49, 52);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(78, 22);
            this.lblNombre.TabIndex = 37;
            this.lblNombre.Text = "Nombre";
            // 
            // nudStock
            // 
            this.nudStock.AccessibleDescription = "Introduce el Stock";
            this.nudStock.AccessibleName = "Caja Stock";
            this.nudStock.Location = new System.Drawing.Point(284, 198);
            this.nudStock.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(120, 29);
            this.nudStock.TabIndex = 43;
            // 
            // nudID
            // 
            this.nudID.AccessibleDescription = "Introduce el ID";
            this.nudID.AccessibleName = "Caja ID";
            this.nudID.Location = new System.Drawing.Point(284, 235);
            this.nudID.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudID.Name = "nudID";
            this.nudID.Size = new System.Drawing.Size(120, 29);
            this.nudID.TabIndex = 44;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(284, 84);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(179, 32);
            this.comboBoxCategory.TabIndex = 45;
            // 
            // comboBoxUnitType
            // 
            this.comboBoxUnitType.FormattingEnabled = true;
            this.comboBoxUnitType.Location = new System.Drawing.Point(284, 122);
            this.comboBoxUnitType.Name = "comboBoxUnitType";
            this.comboBoxUnitType.Size = new System.Drawing.Size(179, 32);
            this.comboBoxUnitType.TabIndex = 46;
            // 
            // FormCreateProduct
            // 
            this.AcceptButton = null;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = null;
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.comboBoxUnitType);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.nudID);
            this.Controls.Add(this.nudStock);
            this.Controls.Add(this.nudPricePerUnit);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblTypeOfUnit);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblNombre);
            this.Name = "FormCreateProduct";
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.lblCategory, 0);
            this.Controls.SetChildIndex(this.lblTypeOfUnit, 0);
            this.Controls.SetChildIndex(this.lblStock, 0);
            this.Controls.SetChildIndex(this.lblID, 0);
            this.Controls.SetChildIndex(this.tbNombre, 0);
            this.Controls.SetChildIndex(this.lblPrice, 0);
            this.Controls.SetChildIndex(this.nudPricePerUnit, 0);
            this.Controls.SetChildIndex(this.nudStock, 0);
            this.Controls.SetChildIndex(this.nudID, 0);
            this.Controls.SetChildIndex(this.comboBoxCategory, 0);
            this.Controls.SetChildIndex(this.comboBoxUnitType, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudPricePerUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cortarContextStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarContextStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarContextStripMenuItem;
        private System.Windows.Forms.NumericUpDown nudPricePerUnit;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblTypeOfUnit;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.NumericUpDown nudID;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.ComboBox comboBoxUnitType;
    }
}