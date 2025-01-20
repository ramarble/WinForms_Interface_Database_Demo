namespace DatabaseInterface.View
{
    partial class FormUser
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
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tbNIF = new System.Windows.Forms.MaskedTextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.lblSalary = new System.Windows.Forms.Label();
            this.numSalary = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alejarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cortarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            // buttonClear
            // 
            this.buttonClear.AccessibleDescription = "Botón para limpiar todas las cajas de texto";
            this.buttonClear.AccessibleName = "Botón Limpiar";
            this.buttonClear.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClear.Location = new System.Drawing.Point(284, 398);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(117, 40);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "Limpiar";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.AccessibleDescription = "Botón para guardar y enviar el Usuario del formulario";
            this.buttonSave.AccessibleName = "Botón Guardar";
            this.buttonSave.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonSave.Location = new System.Drawing.Point(534, 398);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(117, 40);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.SaveUserAsTemp);
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
            // buttonClose
            // 
            this.buttonClose.AccessibleDescription = "Botón para cerrar la aplicación";
            this.buttonClose.AccessibleName = "Botón Cerrar";
            this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(53, 398);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(117, 40);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Cerrar";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
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
            this.numSalary.Enter += new System.EventHandler(this.numSalary_Enter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ediciónToolStripMenuItem,
            this.verToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(704, 27);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 19);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nuevoToolStripMenuItem.Enabled = false;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Enabled = false;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Enabled = false;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.guardarToolStripMenuItem.Text = "Guardar Todo";
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.Enabled = false;
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // ediciónToolStripMenuItem
            // 
            this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cortarToolStripMenuItem,
            this.copiarToolStripMenuItem,
            this.pegarToolStripMenuItem});
            this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
            this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.ediciónToolStripMenuItem.Text = "Edición";
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.AccessibleDescription = "Cortar texto";
            this.cortarToolStripMenuItem.AccessibleName = "Cortar Texto";
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cortarToolStripMenuItem.Text = "Cortar";
            this.cortarToolStripMenuItem.Click += new System.EventHandler(this.cortarToolStripMenuItem_Click);
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.AccessibleDescription = "Copiar Texto";
            this.copiarToolStripMenuItem.AccessibleName = "Copiar Texto";
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.AccessibleDescription = "Pegar Texto";
            this.pegarToolStripMenuItem.AccessibleName = "Pegar Texto";
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pegarToolStripMenuItem.Text = "Pegar";
            this.pegarToolStripMenuItem.Click += new System.EventHandler(this.pegarToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercarToolStripMenuItem,
            this.alejarToolStripMenuItem});
            this.verToolStripMenuItem.Enabled = false;
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 19);
            this.verToolStripMenuItem.Text = "Ver";
            this.verToolStripMenuItem.Visible = false;
            // 
            // acercarToolStripMenuItem
            // 
            this.acercarToolStripMenuItem.Name = "acercarToolStripMenuItem";
            this.acercarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.acercarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.acercarToolStripMenuItem.Text = "Acercar";
            // 
            // alejarToolStripMenuItem
            // 
            this.alejarToolStripMenuItem.Name = "alejarToolStripMenuItem";
            this.alejarToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.alejarToolStripMenuItem.Text = "Alejar";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 19);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
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
            // cortarToolStripMenuItem1
            // 
            this.cortarToolStripMenuItem1.Name = "cortarToolStripMenuItem1";
            this.cortarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.cortarToolStripMenuItem1.Text = "Cortar";
            this.cortarToolStripMenuItem1.Click += new System.EventHandler(this.cortarToolStripMenuItem1_Click);
            // 
            // copiarToolStripMenuItem1
            // 
            this.copiarToolStripMenuItem1.Name = "copiarToolStripMenuItem1";
            this.copiarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copiarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.copiarToolStripMenuItem1.Text = "Copiar";
            this.copiarToolStripMenuItem1.Click += new System.EventHandler(this.copiarToolStripMenuItem1_Click);
            // 
            // pegarToolStripMenuItem1
            // 
            this.pegarToolStripMenuItem1.Name = "pegarToolStripMenuItem1";
            this.pegarToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.pegarToolStripMenuItem1.Text = "Pegar";
            this.pegarToolStripMenuItem1.Click += new System.EventHandler(this.pegarToolStripMenuItem1_Click);
            // 
            // FormUser
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.numSalary);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.tbNIF);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.tbApe2);
            this.Controls.Add(this.tbApe1);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lblNIF);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.lbl2doApellido);
            this.Controls.Add(this.lbl1erApellido);
            this.Controls.Add(this.lblNombre);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormUser";
            this.Text = "Create a new user";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserAdd_FormClosed);
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSalary)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.MaskedTextBox tbNIF;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.NumericUpDown numSalary;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ediciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alejarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem1;
    }
}