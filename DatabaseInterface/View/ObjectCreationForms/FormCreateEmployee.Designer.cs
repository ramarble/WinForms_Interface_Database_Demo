namespace DatabaseInterfaceDemo.View.ObjectCreationForms
{
    partial class FormCreateEmployee
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
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.tbApe2 = new System.Windows.Forms.TextBox();
            this.tbApe1 = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblNIF = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.lbl2doApellido = new System.Windows.Forms.Label();
            this.lbl1erApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbNIF = new System.Windows.Forms.MaskedTextBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.numSalary = new System.Windows.Forms.NumericUpDown();
            this.cortarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.AccessibleDescription = "Entrada de Fecha de Nacimiento";
            this.dtpFechaNacimiento.AccessibleName = "Fecha de Nacimiento";
            this.dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(284, 211);
            this.dtpFechaNacimiento.Margin = new System.Windows.Forms.Padding(6);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(367, 29);
            this.dtpFechaNacimiento.TabIndex = 5;
            // 
            // tbApe2
            // 
            this.tbApe2.AccessibleDescription = "Introduce el Segundo Apellido";
            this.tbApe2.AccessibleName = "Caja Texto Segundo Apellido";
            this.tbApe2.Location = new System.Drawing.Point(284, 137);
            this.tbApe2.Margin = new System.Windows.Forms.Padding(11);
            this.tbApe2.Name = "tbApe2";
            this.tbApe2.Size = new System.Drawing.Size(367, 29);
            this.tbApe2.TabIndex = 3;
            // 
            // tbApe1
            // 
            this.tbApe1.AccessibleDescription = "Introduce el apellido";
            this.tbApe1.AccessibleName = "Caja Texto Apellido";
            this.tbApe1.Location = new System.Drawing.Point(284, 99);
            this.tbApe1.Margin = new System.Windows.Forms.Padding(11);
            this.tbApe1.Name = "tbApe1";
            this.tbApe1.Size = new System.Drawing.Size(367, 29);
            this.tbApe1.TabIndex = 2;
            // 
            // tbNombre
            // 
            this.tbNombre.AccessibleDescription = "Introduce el nombre";
            this.tbNombre.AccessibleName = "Caja Texto Nombre";
            this.tbNombre.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.tbNombre.Location = new System.Drawing.Point(284, 63);
            this.tbNombre.Margin = new System.Windows.Forms.Padding(11);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(367, 29);
            this.tbNombre.TabIndex = 1;
            // 
            // lblNIF
            // 
            this.lblNIF.AutoSize = true;
            this.lblNIF.Font = new System.Drawing.Font("Arial", 14F);
            this.lblNIF.Location = new System.Drawing.Point(49, 252);
            this.lblNIF.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblNIF.Name = "lblNIF";
            this.lblNIF.Size = new System.Drawing.Size(41, 22);
            this.lblNIF.TabIndex = 18;
            this.lblNIF.Text = "NIF";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Font = new System.Drawing.Font("Arial", 14F);
            this.lblFechaNac.Location = new System.Drawing.Point(49, 215);
            this.lblFechaNac.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(162, 22);
            this.lblFechaNac.TabIndex = 17;
            this.lblFechaNac.Text = "Fecha Nacimiento";
            // 
            // lbl2doApellido
            // 
            this.lbl2doApellido.AutoSize = true;
            this.lbl2doApellido.Font = new System.Drawing.Font("Arial", 14F);
            this.lbl2doApellido.Location = new System.Drawing.Point(49, 140);
            this.lbl2doApellido.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lbl2doApellido.Name = "lbl2doApellido";
            this.lbl2doApellido.Size = new System.Drawing.Size(160, 22);
            this.lbl2doApellido.TabIndex = 16;
            this.lbl2doApellido.Text = "Segundo Apellido";
            // 
            // lbl1erApellido
            // 
            this.lbl1erApellido.AutoSize = true;
            this.lbl1erApellido.Font = new System.Drawing.Font("Arial", 14F);
            this.lbl1erApellido.Location = new System.Drawing.Point(49, 102);
            this.lbl1erApellido.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lbl1erApellido.Name = "lbl1erApellido";
            this.lbl1erApellido.Size = new System.Drawing.Size(139, 22);
            this.lbl1erApellido.TabIndex = 15;
            this.lbl1erApellido.Text = "Primer Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 14F);
            this.lblNombre.Location = new System.Drawing.Point(49, 66);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(78, 22);
            this.lblNombre.TabIndex = 14;
            this.lblNombre.Text = "Nombre";
            // 
            // tbNIF
            // 
            this.tbNIF.AccessibleDescription = "Introduce el NIF";
            this.tbNIF.AccessibleName = "Caja NIF";
            this.tbNIF.Location = new System.Drawing.Point(284, 249);
            this.tbNIF.Mask = "00000000";
            this.tbNIF.Name = "tbNIF";
            this.tbNIF.Size = new System.Drawing.Size(367, 29);
            this.tbNIF.TabIndex = 6;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Arial", 14F);
            this.lblSalary.Location = new System.Drawing.Point(49, 177);
            this.lblSalary.Margin = new System.Windows.Forms.Padding(11, 0, 11, 0);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(68, 22);
            this.lblSalary.TabIndex = 28;
            this.lblSalary.Text = "Salario";
            // 
            // numSalary
            // 
            this.numSalary.AccessibleDescription = "Introduce el Salario";
            this.numSalary.AccessibleName = "Caja Salario";
            this.numSalary.DecimalPlaces = 2;
            this.numSalary.Location = new System.Drawing.Point(284, 175);
            this.numSalary.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numSalary.Name = "numSalary";
            this.numSalary.Size = new System.Drawing.Size(120, 29);
            this.numSalary.TabIndex = 4;
            // 
            // cortarToolStripMenuItem1
            // 
            this.cortarToolStripMenuItem1.Name = "cortarToolStripMenuItem1";
            this.cortarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.cortarToolStripMenuItem1.Text = "Cortar";
            // 
            // copiarToolStripMenuItem1
            // 
            this.copiarToolStripMenuItem1.Name = "copiarToolStripMenuItem1";
            this.copiarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copiarToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.copiarToolStripMenuItem1.Text = "Copiar";
            // 
            // pegarToolStripMenuItem1
            // 
            this.pegarToolStripMenuItem1.Name = "pegarToolStripMenuItem1";
            this.pegarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.pegarToolStripMenuItem1.Text = "Pegar";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cortarToolStripMenuItem1,
            this.copiarToolStripMenuItem1,
            this.pegarToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(152, 70);
            // 
            // FormCreateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.numSalary);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.tbNIF);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.tbApe2);
            this.Controls.Add(this.tbApe1);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lblNIF);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.lbl2doApellido);
            this.Controls.Add(this.lbl1erApellido);
            this.Controls.Add(this.lblNombre);
            this.Name = "FormCreateEmployee";
            this.Controls.SetChildIndex(this.lblNombre, 0);
            this.Controls.SetChildIndex(this.lbl1erApellido, 0);
            this.Controls.SetChildIndex(this.lbl2doApellido, 0);
            this.Controls.SetChildIndex(this.lblFechaNac, 0);
            this.Controls.SetChildIndex(this.lblNIF, 0);
            this.Controls.SetChildIndex(this.tbNombre, 0);
            this.Controls.SetChildIndex(this.tbApe1, 0);
            this.Controls.SetChildIndex(this.tbApe2, 0);
            this.Controls.SetChildIndex(this.dtpFechaNacimiento, 0);
            this.Controls.SetChildIndex(this.tbNIF, 0);
            this.Controls.SetChildIndex(this.lblSalary, 0);
            this.Controls.SetChildIndex(this.numSalary, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.TextBox tbApe2;
        private System.Windows.Forms.TextBox tbApe1;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lblNIF;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lbl2doApellido;
        private System.Windows.Forms.Label lbl1erApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.MaskedTextBox tbNIF;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.NumericUpDown numSalary;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}