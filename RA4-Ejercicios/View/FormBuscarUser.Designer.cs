namespace RA4_Ejercicios.View
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
            this.SuspendLayout();
            // 
            // userListBox
            // 
            this.userListBox.FormattingEnabled = true;
            this.userListBox.Location = new System.Drawing.Point(25, 61);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(120, 368);
            this.userListBox.TabIndex = 0;
            // 
            // filterFindUserTextBox
            // 
            this.filterFindUserTextBox.Location = new System.Drawing.Point(25, 30);
            this.filterFindUserTextBox.Name = "filterFindUserTextBox";
            this.filterFindUserTextBox.Size = new System.Drawing.Size(120, 20);
            this.filterFindUserTextBox.TabIndex = 1;
            this.filterFindUserTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(202, 406);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(75, 23);
            this.buttonModify.TabIndex = 3;
            this.buttonModify.Text = "Modify";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonRevert
            // 
            this.buttonRevert.Location = new System.Drawing.Point(622, 406);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(75, 23);
            this.buttonRevert.TabIndex = 4;
            this.buttonRevert.Text = "Revert";
            this.buttonRevert.UseVisualStyleBackColor = true;
            this.buttonRevert.Click += new System.EventHandler(this.buttonRevert_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(713, 406);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // userPropertyGrid
            // 
            this.userPropertyGrid.CommandsDisabledLinkColor = System.Drawing.Color.Black;
            this.userPropertyGrid.DisabledItemForeColor = System.Drawing.SystemColors.ControlText;
            this.userPropertyGrid.HelpVisible = false;
            this.userPropertyGrid.Location = new System.Drawing.Point(202, 61);
            this.userPropertyGrid.Name = "userPropertyGrid";
            this.userPropertyGrid.Size = new System.Drawing.Size(586, 322);
            this.userPropertyGrid.TabIndex = 2;
            this.userPropertyGrid.ToolbarVisible = false;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(199, 33);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(565, 13);
            this.labelInfo.TabIndex = 6;
            this.labelInfo.Text = "Puedes encontrar un usuario por su NIF o nombre. (Esto sería un tooltip si no qui" +
    "siese que fuera imperativo que se lea)";
            // 
            // FormBuscarUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}