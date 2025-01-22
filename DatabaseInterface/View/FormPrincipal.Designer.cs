using DatabaseInterface.Controller;
using DatabaseInterface.Model;
using System.Collections.Generic;

namespace DatabaseInterface
{
    partial class formPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrincipalDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSaveTemp = new System.Windows.Forms.Button();
            this.buttonRevertAll = new System.Windows.Forms.Button();
            this.saveSelectedButton = new System.Windows.Forms.Button();
            this.buttonDeleteSelected = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.revertSelectedButton = new System.Windows.Forms.Button();
            this.comboBoxCargarDatos = new System.Windows.Forms.ComboBox();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.labelDatabase = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelDataType = new System.Windows.Forms.Label();
            this.comboBoxDataType = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrincipalDataGridView)).BeginInit();
            this.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1105, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.AccessibleDescription = "Menú de opciones para el archivo actual";
            this.archivoToolStripMenuItem.AccessibleName = "Menú Archivo";
            this.archivoToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.buscarToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.imprimirToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 19);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.AccessibleDescription = "Menú para crear un nuevo usuario";
            this.nuevoToolStripMenuItem.AccessibleName = "Menú nuevo";
            this.nuevoToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.nuevoToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.New_Menu_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.AccessibleDescription = "Menú para buscar un usuario";
            this.buscarToolStripMenuItem.AccessibleName = "Menú buscar";
            this.buscarToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.buscarToolStripMenuItem.Text = "Buscar";
            this.buscarToolStripMenuItem.Click += new System.EventHandler(this.Search_Menu_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.AccessibleDescription = "Menú para guardar todo los cambios no guardados";
            this.guardarToolStripMenuItem.AccessibleName = "Menú guardar todo";
            this.guardarToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.guardarToolStripMenuItem.Enabled = false;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.guardarToolStripMenuItem.Text = "Guardar Todo";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.saveAll_Menu_Click);
            // 
            // imprimirToolStripMenuItem
            // 
            this.imprimirToolStripMenuItem.AccessibleDescription = "Menú para abrir la vista de impresión de todos los usuarios";
            this.imprimirToolStripMenuItem.AccessibleName = "Menú vista impresión";
            this.imprimirToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.imprimirToolStripMenuItem.Name = "imprimirToolStripMenuItem";
            this.imprimirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.imprimirToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.imprimirToolStripMenuItem.Text = "Imprimir";
            this.imprimirToolStripMenuItem.Click += new System.EventHandler(this.Print_Menu_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.AccessibleDescription = "Menú para salir del programa";
            this.salirToolStripMenuItem.AccessibleName = "Menú salir";
            this.salirToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.Exit_Menu_Click);
            // 
            // ediciónToolStripMenuItem
            // 
            this.ediciónToolStripMenuItem.AccessibleName = "Menú Edición";
            this.ediciónToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cortarToolStripMenuItem,
            this.copiarToolStripMenuItem,
            this.pegarToolStripMenuItem});
            this.ediciónToolStripMenuItem.Enabled = false;
            this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
            this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.ediciónToolStripMenuItem.Text = "Edición";
            this.ediciónToolStripMenuItem.Visible = false;
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.AccessibleDescription = "Corta el texto en el portapapeles";
            this.cortarToolStripMenuItem.AccessibleName = "Cortar";
            this.cortarToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cortarToolStripMenuItem.Text = "Cortar";
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.AccessibleDescription = "Copia el texto en el portapapeles";
            this.copiarToolStripMenuItem.AccessibleName = "Copiar";
            this.copiarToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.copiarToolStripMenuItem.Text = "Copiar";
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.AccessibleDescription = "Pega el texto en el portapapeles";
            this.pegarToolStripMenuItem.AccessibleName = "Pegar";
            this.pegarToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.pegarToolStripMenuItem.Text = "Pegar";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.AccessibleDescription = "Menú de opciones para alterar la vista actual de la ventana";
            this.verToolStripMenuItem.AccessibleName = "Menú Ver";
            this.verToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maximizarToolStripMenuItem});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(35, 19);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // maximizarToolStripMenuItem
            // 
            this.maximizarToolStripMenuItem.AccessibleDescription = "Maximiza la aplicación";
            this.maximizarToolStripMenuItem.AccessibleName = "Maximizar";
            this.maximizarToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.maximizarToolStripMenuItem.Name = "maximizarToolStripMenuItem";
            this.maximizarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.maximizarToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.maximizarToolStripMenuItem.Text = "Maximizar";
            this.maximizarToolStripMenuItem.Click += new System.EventHandler(this.maximizarToolStrip_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.AccessibleDescription = "Menú de información";
            this.ayudaToolStripMenuItem.AccessibleName = "Menú Ayuda";
            this.ayudaToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 19);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // PrincipalDataGridView
            // 
            this.PrincipalDataGridView.AccessibleDescription = "Vista de la información de los usuarios cargados en celdas";
            this.PrincipalDataGridView.AccessibleName = "Vista de usuarios en celdas";
            this.PrincipalDataGridView.AllowUserToAddRows = false;
            this.PrincipalDataGridView.AllowUserToDeleteRows = false;
            this.PrincipalDataGridView.AllowUserToResizeRows = false;
            this.PrincipalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PrincipalDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.PrincipalDataGridView.Location = new System.Drawing.Point(12, 105);
            this.PrincipalDataGridView.Name = "PrincipalDataGridView";
            this.PrincipalDataGridView.Size = new System.Drawing.Size(1081, 419);
            this.PrincipalDataGridView.TabIndex = 14;
            // 
            // buttonSaveTemp
            // 
            this.buttonSaveTemp.AccessibleDescription = "Botón para guardar todos los cambios temporales";
            this.buttonSaveTemp.AccessibleName = "Botón Guardar Cambios Temporales";
            this.buttonSaveTemp.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonSaveTemp.Enabled = false;
            this.buttonSaveTemp.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonSaveTemp.Location = new System.Drawing.Point(724, 598);
            this.buttonSaveTemp.Name = "buttonSaveTemp";
            this.buttonSaveTemp.Size = new System.Drawing.Size(124, 62);
            this.buttonSaveTemp.TabIndex = 7;
            this.buttonSaveTemp.Text = "Guardar Modificaciones Temporales";
            this.buttonSaveTemp.UseVisualStyleBackColor = true;
            this.buttonSaveTemp.Click += new System.EventHandler(this.buttonSaveAll_Click);
            // 
            // buttonRevertAll
            // 
            this.buttonRevertAll.AccessibleDescription = "Revertir todos los cambios no guardados";
            this.buttonRevertAll.AccessibleName = "Botón revertir todo";
            this.buttonRevertAll.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonRevertAll.Enabled = false;
            this.buttonRevertAll.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonRevertAll.Location = new System.Drawing.Point(12, 598);
            this.buttonRevertAll.Name = "buttonRevertAll";
            this.buttonRevertAll.Size = new System.Drawing.Size(132, 62);
            this.buttonRevertAll.TabIndex = 3;
            this.buttonRevertAll.Text = "Revertir Todo";
            this.buttonRevertAll.UseVisualStyleBackColor = true;
            this.buttonRevertAll.Click += new System.EventHandler(this.buttonRevertAll_Click);
            // 
            // saveSelectedButton
            // 
            this.saveSelectedButton.AccessibleDescription = "Botón para guardar los objetos temporales seleccionados";
            this.saveSelectedButton.AccessibleName = "Botón guardar seleccionados";
            this.saveSelectedButton.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.saveSelectedButton.Enabled = false;
            this.saveSelectedButton.Font = new System.Drawing.Font("Arial", 12F);
            this.saveSelectedButton.Location = new System.Drawing.Point(586, 598);
            this.saveSelectedButton.Name = "saveSelectedButton";
            this.saveSelectedButton.Size = new System.Drawing.Size(132, 62);
            this.saveSelectedButton.TabIndex = 6;
            this.saveSelectedButton.Text = "Guardar Modificaciones Seleccionadas";
            this.saveSelectedButton.UseVisualStyleBackColor = true;
            this.saveSelectedButton.Click += new System.EventHandler(this.saveSelectedButton_Click);
            // 
            // buttonDeleteSelected
            // 
            this.buttonDeleteSelected.AccessibleDescription = "Borrar los usuarios que estén seleccionados";
            this.buttonDeleteSelected.AccessibleName = "Botón borrar seleccionados";
            this.buttonDeleteSelected.Enabled = false;
            this.buttonDeleteSelected.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonDeleteSelected.Location = new System.Drawing.Point(150, 598);
            this.buttonDeleteSelected.Name = "buttonDeleteSelected";
            this.buttonDeleteSelected.Size = new System.Drawing.Size(132, 62);
            this.buttonDeleteSelected.TabIndex = 4;
            this.buttonDeleteSelected.Text = "Borrar Seleccionados";
            this.buttonDeleteSelected.UseVisualStyleBackColor = true;
            this.buttonDeleteSelected.Click += new System.EventHandler(this.deleteSelectedButton_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.AccessibleDescription = "Botón para modificar el usuario seleccionado";
            this.buttonModify.AccessibleName = "Botón modificar seleccionados";
            this.buttonModify.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonModify.Enabled = false;
            this.buttonModify.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonModify.Location = new System.Drawing.Point(360, 598);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(132, 62);
            this.buttonModify.TabIndex = 5;
            this.buttonModify.Text = "Modificar Seleccionado";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // revertSelectedButton
            // 
            this.revertSelectedButton.AccessibleDescription = "Revertir los cambios no guardados que estén seleccionados";
            this.revertSelectedButton.AccessibleName = "Botón revertir seleccionados";
            this.revertSelectedButton.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.revertSelectedButton.Enabled = false;
            this.revertSelectedButton.Font = new System.Drawing.Font("Arial", 12F);
            this.revertSelectedButton.Location = new System.Drawing.Point(12, 530);
            this.revertSelectedButton.Name = "revertSelectedButton";
            this.revertSelectedButton.Size = new System.Drawing.Size(132, 62);
            this.revertSelectedButton.TabIndex = 2;
            this.revertSelectedButton.Text = "Revertir Seleccionados";
            this.revertSelectedButton.UseVisualStyleBackColor = true;
            this.revertSelectedButton.Click += new System.EventHandler(this.revertSelectedButton_Click);
            // 
            // comboBoxCargarDatos
            // 
            this.comboBoxCargarDatos.AccessibleDescription = "Combo Box Carga Datos";
            this.comboBoxCargarDatos.AccessibleName = "Combo Box Carga Datos";
            this.comboBoxCargarDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.comboBoxCargarDatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCargarDatos.FormattingEnabled = true;
            this.comboBoxCargarDatos.Location = new System.Drawing.Point(656, 61);
            this.comboBoxCargarDatos.Name = "comboBoxCargarDatos";
            this.comboBoxCargarDatos.Size = new System.Drawing.Size(319, 32);
            this.comboBoxCargarDatos.TabIndex = 15;
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.AccessibleDescription = "Botón para guardar todos los cambios a un archivo";
            this.buttonSaveToFile.AccessibleName = "Botón Guardar a archivo";
            this.buttonSaveToFile.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonSaveToFile.Enabled = false;
            this.buttonSaveToFile.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonSaveToFile.Location = new System.Drawing.Point(961, 598);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(132, 62);
            this.buttonSaveToFile.TabIndex = 8;
            this.buttonSaveToFile.Text = "Guardar a Archivo";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.AccessibleDescription = "Botón para cargar datos desde archivo";
            this.buttonLoadData.AccessibleName = "Botón Cargar desde Archivo";
            this.buttonLoadData.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonLoadData.Enabled = false;
            this.buttonLoadData.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonLoadData.Location = new System.Drawing.Point(981, 55);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(112, 44);
            this.buttonLoadData.TabIndex = 1;
            this.buttonLoadData.Text = "Cargar datos";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
            // 
            // labelDatabase
            // 
            this.labelDatabase.AutoSize = true;
            this.labelDatabase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatabase.Location = new System.Drawing.Point(12, 27);
            this.labelDatabase.Name = "labelDatabase";
            this.labelDatabase.Size = new System.Drawing.Size(232, 21);
            this.labelDatabase.TabIndex = 16;
            this.labelDatabase.Text = "INFO_DatabaseNotInitialized";
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(541, 64);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(109, 24);
            this.labelFile.TabIndex = 17;
            this.labelFile.Text = "LABEL_File";
            this.labelFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDataType
            // 
            this.labelDataType.AutoSize = true;
            this.labelDataType.Location = new System.Drawing.Point(12, 64);
            this.labelDataType.Name = "labelDataType";
            this.labelDataType.Size = new System.Drawing.Size(158, 24);
            this.labelDataType.TabIndex = 18;
            this.labelDataType.Text = "LABEL_DataType";
            this.labelDataType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxDataType
            // 
            this.comboBoxDataType.AccessibleDescription = "Combo Box Carga Tipo de Datos";
            this.comboBoxDataType.AccessibleName = "Combo Box Carga Tipo";
            this.comboBoxDataType.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.comboBoxDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataType.FormattingEnabled = true;
            this.comboBoxDataType.Location = new System.Drawing.Point(176, 61);
            this.comboBoxDataType.Name = "comboBoxDataType";
            this.comboBoxDataType.Size = new System.Drawing.Size(185, 32);
            this.comboBoxDataType.TabIndex = 19;
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 672);
            this.Controls.Add(this.comboBoxDataType);
            this.Controls.Add(this.labelDataType);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.labelDatabase);
            this.Controls.Add(this.buttonLoadData);
            this.Controls.Add(this.buttonSaveToFile);
            this.Controls.Add(this.comboBoxCargarDatos);
            this.Controls.Add(this.revertSelectedButton);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.buttonDeleteSelected);
            this.Controls.Add(this.saveSelectedButton);
            this.Controls.Add(this.buttonRevertAll);
            this.Controls.Add(this.buttonSaveTemp);
            this.Controls.Add(this.PrincipalDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formPrincipal";
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.formPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrincipalDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ediciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.DataGridView PrincipalDataGridView;
        private System.Windows.Forms.Button buttonSaveTemp;
        private System.Windows.Forms.Button buttonRevertAll;
        private System.Windows.Forms.Button saveSelectedButton;
        private System.Windows.Forms.Button buttonDeleteSelected;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button revertSelectedButton;
        private System.Windows.Forms.ComboBox comboBoxCargarDatos;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.Label labelDatabase;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelDataType;
        private System.Windows.Forms.ComboBox comboBoxDataType;
    }
}

