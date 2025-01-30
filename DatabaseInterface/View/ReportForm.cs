using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.ComponentModel;
using System.Drawing;
using DatabaseInterfaceDemo.Controller;
using static DatabaseInterfaceDemo.View.FilterControlsBase;

namespace DatabaseInterfaceDemo.View
{
    public partial class ReportForm : Form
    {   

        public static ReportDataSource ReportData { get; set; }
        public static BindingList<object> ListCurrentlyInUse { get; set; }
        public static BindingList<object> InitialList { get; set; }
        public static FilterControlsBase FormTypeFilters;


        public ReportForm(BindingList<object> list, FilterFormList FormType)
        {
            InitializeComponent();

            InitialList = list;
            ListCurrentlyInUse = list;

            ProgrammaticallyResizeWindow(null, null);

            FormTypeFilters = LateInitializeControls(FormType);
            InitializeReportViewer();

            this.ResizeEnd += ProgrammaticallyResizeWindow;
            this.ResizeEnd += FormTypeFilters.ProgrammaticallyPlaceFilterControls;
        }

        private FilterControlsBase LateInitializeControls(FilterFormList filterFormList)
        {
            switch (filterFormList)
            {
                case FilterFormList.Products:
                {
                    return new ProductFiltersControls(this, ReportViewer);
                }

            }
            return null;
        }

        private void InitializeReportViewer()
        {
            this.ReportViewer.LocalReport.ReportPath = "../../View/Report1.rdlc";

            ReportData = new ReportDataSource("Producto_DataSet", ListCurrentlyInUse);
            this.ReportViewer.LocalReport.DataSources.Add(ReportData);
            this.ReportViewer.RefreshReport();
        }

        private void ProgrammaticallyResizeWindow(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            ReportViewer.Location = new Point((int) FormUtils.PADDING.LEFT, (int) FormUtils.PADDING.TOP);
            ReportViewer.Size = new Size(this.Size.Width - (int) FormUtils.PADDING.RIGHT, this.Size.Height - (int) FormUtils.PADDING.BUTTONS);

        }

    }
}
