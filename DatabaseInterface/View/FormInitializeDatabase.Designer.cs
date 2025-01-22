namespace DatabaseInterfaceDemo.View
{
    partial class FormInitializeDatabase
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
            this.warnLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // warnLabel
            // 
            this.warnLabel.AutoSize = true;
            this.warnLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warnLabel.Location = new System.Drawing.Point(133, 55);
            this.warnLabel.Name = "warnLabel";
            this.warnLabel.Size = new System.Drawing.Size(99, 25);
            this.warnLabel.TabIndex = 0;
            this.warnLabel.Text = "warnLabel";
            // 
            // FormInitializeDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 241);
            this.Controls.Add(this.warnLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInitializeDatabase";
            this.Text = "FormInitializeDatabase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label warnLabel;
    }
}