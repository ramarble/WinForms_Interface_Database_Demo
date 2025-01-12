using RA4_Ejercicios.Controller;
using RA4_Ejercicios.Model;
using System.Collections.Generic;

namespace RA4_Ejercicios
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
            this.userDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSaveAll = new System.Windows.Forms.Button();
            this.buttonRevertAll = new System.Windows.Forms.Button();
            this.saveSelectedButton = new System.Windows.Forms.Button();
            this.buttonDeleteSelected = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonRevertSelected = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(966, 27);
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
            this.maximizarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // userDataGridView
            // 
            this.userDataGridView.AccessibleDescription = "Vista de la información de los usuarios cargados en celdas";
            this.userDataGridView.AccessibleName = "Vista de usuarios en celdas";
            this.userDataGridView.AllowUserToAddRows = false;
            this.userDataGridView.AllowUserToDeleteRows = false;
            this.userDataGridView.AllowUserToResizeRows = false;
            this.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.userDataGridView.Location = new System.Drawing.Point(12, 30);
            this.userDataGridView.Name = "userDataGridView";
            this.userDataGridView.Size = new System.Drawing.Size(942, 419);
            this.userDataGridView.TabIndex = 14;
            // 
            // buttonSaveAll
            // 
            this.buttonSaveAll.AccessibleDescription = "Botón para guardar todos los cambios no guardados";
            this.buttonSaveAll.AccessibleName = "Botón Guardar Todo";
            this.buttonSaveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonSaveAll.Enabled = false;
            this.buttonSaveAll.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonSaveAll.Location = new System.Drawing.Point(822, 487);
            this.buttonSaveAll.Name = "buttonSaveAll";
            this.buttonSaveAll.Size = new System.Drawing.Size(132, 62);
            this.buttonSaveAll.TabIndex = 6;
            this.buttonSaveAll.Text = "Guardar Todo";
            this.buttonSaveAll.UseVisualStyleBackColor = true;
            this.buttonSaveAll.Click += new System.EventHandler(this.buttonSaveAll_Click);
            // 
            // buttonRevertAll
            // 
            this.buttonRevertAll.AccessibleDescription = "Revertir todos los cambios no guardados";
            this.buttonRevertAll.AccessibleName = "Botón revertir todo";
            this.buttonRevertAll.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonRevertAll.Enabled = false;
            this.buttonRevertAll.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonRevertAll.Location = new System.Drawing.Point(12, 487);
            this.buttonRevertAll.Name = "buttonRevertAll";
            this.buttonRevertAll.Size = new System.Drawing.Size(132, 62);
            this.buttonRevertAll.TabIndex = 1;
            this.buttonRevertAll.Text = "Revertir Todo";
            this.buttonRevertAll.UseVisualStyleBackColor = true;
            this.buttonRevertAll.Click += new System.EventHandler(this.buttonRevertAll_Click);
            // 
            // saveSelectedButton
            // 
            this.saveSelectedButton.AccessibleDescription = "Botón para guardar los usuarios seleccionados";
            this.saveSelectedButton.AccessibleName = "Botón guardar seleccionados";
            this.saveSelectedButton.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.saveSelectedButton.Enabled = false;
            this.saveSelectedButton.Font = new System.Drawing.Font("Arial", 12F);
            this.saveSelectedButton.Location = new System.Drawing.Point(684, 487);
            this.saveSelectedButton.Name = "saveSelectedButton";
            this.saveSelectedButton.Size = new System.Drawing.Size(132, 62);
            this.saveSelectedButton.TabIndex = 5;
            this.saveSelectedButton.Text = "Guardar Seleccionados";
            this.saveSelectedButton.UseVisualStyleBackColor = true;
            this.saveSelectedButton.Click += new System.EventHandler(this.saveSelectedButton_Click);
            // 
            // buttonDeleteSelected
            // 
            this.buttonDeleteSelected.AccessibleDescription = "Borrar los usuarios que estén seleccionados";
            this.buttonDeleteSelected.AccessibleName = "Botón borrar seleccionados";
            this.buttonDeleteSelected.Enabled = false;
            this.buttonDeleteSelected.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonDeleteSelected.Location = new System.Drawing.Point(331, 487);
            this.buttonDeleteSelected.Name = "buttonDeleteSelected";
            this.buttonDeleteSelected.Size = new System.Drawing.Size(132, 62);
            this.buttonDeleteSelected.TabIndex = 3;
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
            this.buttonModify.Location = new System.Drawing.Point(506, 487);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(132, 62);
            this.buttonModify.TabIndex = 4;
            this.buttonModify.Text = "Modificar Seleccionado";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonRevertSelected
            // 
            this.buttonRevertSelected.AccessibleDescription = "Revertir los cambios no guardados que estén seleccionados";
            this.buttonRevertSelected.AccessibleName = "Botón revertir seleccionados";
            this.buttonRevertSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.buttonRevertSelected.Enabled = false;
            this.buttonRevertSelected.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonRevertSelected.Location = new System.Drawing.Point(150, 487);
            this.buttonRevertSelected.Name = "buttonRevertSelected";
            this.buttonRevertSelected.Size = new System.Drawing.Size(132, 62);
            this.buttonRevertSelected.TabIndex = 2;
            this.buttonRevertSelected.Text = "Revertir Seleccionados";
            this.buttonRevertSelected.UseVisualStyleBackColor = true;
            this.buttonRevertSelected.Click += new System.EventHandler(this.buttonRevertSelected_Click);
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 568);
            this.Controls.Add(this.buttonRevertSelected);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.buttonDeleteSelected);
            this.Controls.Add(this.saveSelectedButton);
            this.Controls.Add(this.buttonRevertAll);
            this.Controls.Add(this.buttonSaveAll);
            this.Controls.Add(this.userDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "formPrincipal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.formPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userDataGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView userDataGridView;
        private System.Windows.Forms.Button buttonSaveAll;
        private System.Windows.Forms.Button buttonRevertAll;
        private System.Windows.Forms.Button saveSelectedButton;
        private System.Windows.Forms.Button buttonDeleteSelected;
        private System.Windows.Forms.ToolStripMenuItem imprimirToolStripMenuItem;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonRevertSelected;
    }
}

