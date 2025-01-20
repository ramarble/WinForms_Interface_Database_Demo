namespace DatabaseInterface.View
{
    partial class FormBuscarUser
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
            this.userListBox = new System.Windows.Forms.ListBox();
            this.filterFindUserTextBox = new System.Windows.Forms.TextBox();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.userPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.labelInfo = new System.Windows.Forms.Label();
            this.tooltipTextBox = new System.Windows.Forms.ToolTip(this.components);
            this.buttonRevertAll = new System.Windows.Forms.Button();
            this.buttonSaveAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userListBox
            // 
            this.userListBox.Font = new System.Drawing.Font("Arial", 12F);
            this.userListBox.FormattingEnabled = true;
            this.userListBox.ItemHeight = 18;
            this.userListBox.Location = new System.Drawing.Point(25, 61);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(153, 364);
            this.userListBox.TabIndex = 2;
            // 
            // filterFindUserTextBox
            // 
            this.filterFindUserTextBox.Location = new System.Drawing.Point(25, 30);
            this.filterFindUserTextBox.Name = "filterFindUserTextBox";
            this.filterFindUserTextBox.Size = new System.Drawing.Size(153, 20);
            this.filterFindUserTextBox.TabIndex = 1;
            this.filterFindUserTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DynamicSearchBarUpdate);
            // 
            // buttonModify
            // 
            this.buttonModify.AccessibleDescription = "Botón para modificar el usuario seleccionado";
            this.buttonModify.AccessibleName = "Botón Modificar";
            this.buttonModify.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonModify.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonModify.Location = new System.Drawing.Point(711, 389);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(88, 36);
            this.buttonModify.TabIndex = 5;
            this.buttonModify.Text = "Modificar";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonRevert
            // 
            this.buttonRevert.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonRevert.Location = new System.Drawing.Point(202, 389);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(88, 36);
            this.buttonRevert.TabIndex = 3;
            this.buttonRevert.Text = "Revertir";
            this.buttonRevert.UseVisualStyleBackColor = true;
            this.buttonRevert.Click += new System.EventHandler(this.buttonRevert_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.AccessibleDescription = "Botón para guardar el usuario seleccionado";
            this.buttonSave.AccessibleName = "Botón Guardar";
            this.buttonSave.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonSave.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonSave.Location = new System.Drawing.Point(805, 389);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 36);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // userPropertyGrid
            // 
            this.userPropertyGrid.CommandsDisabledLinkColor = System.Drawing.Color.Black;
            this.userPropertyGrid.DisabledItemForeColor = System.Drawing.SystemColors.ControlText;
            this.userPropertyGrid.Font = new System.Drawing.Font("Arial", 12F);
            this.userPropertyGrid.HelpVisible = false;
            this.userPropertyGrid.Location = new System.Drawing.Point(202, 61);
            this.userPropertyGrid.Name = "userPropertyGrid";
            this.userPropertyGrid.Size = new System.Drawing.Size(824, 322);
            this.userPropertyGrid.TabIndex = 2;
            this.userPropertyGrid.ToolbarVisible = false;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Arial", 12F);
            this.labelInfo.Location = new System.Drawing.Point(199, 32);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(827, 18);
            this.labelInfo.TabIndex = 6;
            this.labelInfo.Text = "Puedes encontrar un usuario por su NIF o nombre. (Esto sería un tooltip si no qui" +
    "siese que fuera imperativo que se lea)";
            // 
            // buttonRevertAll
            // 
            this.buttonRevertAll.Enabled = false;
            this.buttonRevertAll.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonRevertAll.Location = new System.Drawing.Point(296, 389);
            this.buttonRevertAll.Name = "buttonRevertAll";
            this.buttonRevertAll.Size = new System.Drawing.Size(127, 36);
            this.buttonRevertAll.TabIndex = 4;
            this.buttonRevertAll.Text = "Revertir TODO";
            this.buttonRevertAll.UseVisualStyleBackColor = true;
            this.buttonRevertAll.Click += new System.EventHandler(this.buttonRevertAll_Click);
            // 
            // buttonSaveAll
            // 
            this.buttonSaveAll.AccessibleDescription = "Botón para guardar todos los cambios no guardados";
            this.buttonSaveAll.AccessibleName = "Botón guardar todo";
            this.buttonSaveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.buttonSaveAll.Enabled = false;
            this.buttonSaveAll.Font = new System.Drawing.Font("Arial", 12F);
            this.buttonSaveAll.Location = new System.Drawing.Point(899, 389);
            this.buttonSaveAll.Name = "buttonSaveAll";
            this.buttonSaveAll.Size = new System.Drawing.Size(127, 36);
            this.buttonSaveAll.TabIndex = 7;
            this.buttonSaveAll.Text = "Guardar TODO";
            this.buttonSaveAll.UseVisualStyleBackColor = true;
            this.buttonSaveAll.Click += new System.EventHandler(this.buttonSaveAll_Click);
            // 
            // FormBuscarUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 450);
            this.Controls.Add(this.buttonSaveAll);
            this.Controls.Add(this.buttonRevertAll);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonRevert);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.userPropertyGrid);
            this.Controls.Add(this.filterFindUserTextBox);
            this.Controls.Add(this.userListBox);
            this.Name = "FormBuscarUser";
            this.Text = "Encuentra un usuario para ser modificado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.FormBuscarUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.TextBox filterFindUserTextBox;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonRevert;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.PropertyGrid userPropertyGrid;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ToolTip tooltipTextBox;
        private System.Windows.Forms.Button buttonRevertAll;
        private System.Windows.Forms.Button buttonSaveAll;
    }
}