using System;

using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using Microsoft.Reporting.WinForms;

namespace DatabaseInterfaceDemo.View
{
    public class FilterControlsBase
    {
        public ReportForm Form;
        public ReportViewer ReportView;
        public Button ButtonUpdateFilters;


        public enum FilterFormList
        {
            Products,
            idkyet
        }

        public FilterControlsBase(ReportForm form, ReportViewer reportView)
        {
            InitializeComponent();

            this.Form = form;
            this.ReportView = reportView;

        }

        /// <summary>
        /// Add base.ProgrmamaticallyPlaceFilterControls() to initialize the button
        /// </summary>
        public virtual void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {
            FormUtils.PlaceControlAtBottomMostRight(Form, ButtonUpdateFilters);
        }

        ///<summary>
        /// Update ReportForm.ListCurrentlyInUse. Start using InitialList.
        /// </summary>
        public virtual void UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportView.LocalReport.DataSources.Remove(ReportForm.ReportData);
            ReportForm.ReportData = new ReportDataSource("Producto_DataSet", ReportForm.ListCurrentlyInUse);
            ReportView.LocalReport.DataSources.Add(ReportForm.ReportData);
            ReportView.RefreshReport();
        }

        /// <summary>
        /// Add base.InitializeComponent() to initialize the button
        /// </summary>
        public virtual void InitializeComponent()
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


    }



}
