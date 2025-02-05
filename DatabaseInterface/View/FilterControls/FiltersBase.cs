// Ignore Spelling: Programmatically

using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseInterfaceDemo.View.FilterControls
{
    public abstract class FiltersBase
    {
        abstract public ReportForm FormOrigin { get; set; }
        abstract public ReportViewer ReportView { get; set; }
        abstract public List<Control> Controls { get; set; }
        abstract public Button ButtonUpdateFilters { get; set; }

        public virtual void AddControlsToForm(List<Control> Controls)
        {
            foreach (Control control in Controls)
            {
                FormOrigin.Controls.Add(control);
            }
        }

        public abstract void AddControlsToList();

        public virtual void InitializeComponents()
        {
            // 
            // buttonUpdateFilters
            // 
            this.ButtonUpdateFilters = new Button();
            this.ButtonUpdateFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUpdateFilters.Name = "buttonUpdateFilters";
            this.ButtonUpdateFilters.Size = new System.Drawing.Size(192, 44);
            this.ButtonUpdateFilters.TabIndex = 9;
            this.ButtonUpdateFilters.Text = "Filtrar por categoría";
            this.ButtonUpdateFilters.UseVisualStyleBackColor = true;
        }


        public abstract void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e);

        public virtual void RemoveControlsFromForm(List<Control> Controls)
        {
            foreach (Control control in Controls)
            {
                FormOrigin.Controls.Remove(control);
            }
        }

        public virtual void UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportView.LocalReport.DataSources.Remove(ReportForm.ReportData);
            ReportForm.ReportData = new ReportDataSource("Producto_DataSet", ReportForm.ListCurrentlyInUse);
            ReportView.LocalReport.DataSources.Add(ReportForm.ReportData);
            ReportView.RefreshReport();
        }

        public virtual void FakeConstructor(ReportForm form, ReportViewer reportViewer)
        {
            this.Controls = new List<Control>();
            this.InitializeComponents();
            this.FormOrigin = form;
            this.ReportView = reportViewer;
            this.AddControlsToList();
            this.AddControlsToForm(Controls);
            this.ButtonUpdateFilters.Click += UpdateFilters_Click;
            this.ProgrammaticallyPlaceFilterControls(null, null);
        }
    }
}
