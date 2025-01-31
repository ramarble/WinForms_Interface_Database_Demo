using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.ComponentModel;
using System.Drawing;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Model;

namespace DatabaseInterfaceDemo.View
{
    public partial class ReportForm : Form
    {   

        public static ReportDataSource ReportData { get; set; }
        public static BindingList<object> ListCurrentlyInUse { get; set; }
        public static BindingList<object> InitialList { get; set; }
        public static IFiltersBase FormTypeFilters;
        public static Type TypeHandled;


        public ReportForm(BindingList<object> list, Type DBType, FilterFormList FormType)
        {
            InitializeComponent();

            TypeHandled = DBType;

            InitialList = list;
            ListCurrentlyInUse = list;

            ProgrammaticallyPlaceControls(null, null);

            FormTypeFilters = InitializeControlsFor(FormType);
            
            InitializeReportViewer();

            this.ResizeEnd += ProgrammaticallyPlaceControls;
            this.ResizeEnd += FormTypeFilters.ProgrammaticallyPlaceFilterControls;
        }

        private IFiltersBase InitializeControlsFor(FilterFormList filterFormList)
        {
            switch (filterFormList)
            {
                case FilterFormList.Products_General:
                {
                    return new Product_ListAll_FilterControls(this, ReportViewer);
                }
                case FilterFormList.Products_Stats: {
                    return new Product_Statistical_FilterControls(this, ReportViewer);
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

        private void InitializeComboBox()
        {
            switch (TypeHandled.Name)
            {
                case nameof(Empleado):
                    {
                        MessageBox.Show("Not Done yet");
                        break;
                    }
                case nameof(Producto):
                    {
                        ComboBox_FormSelect.Items.Clear();
                        ComboBox_FormSelect.Items.AddRange(Enum.GetNames(typeof(FilterFormList)));
                        break;
                    }

            }
        }

        private void ProgrammaticallyPlaceControls(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            FormUtils.PlaceControlTopLeft(ComboBox_FormSelect);
            FormUtils.PlaceControlBelow(ReportViewer, ComboBox_FormSelect);
            ReportViewer.Size = new Size(this.Size.Width - (int)FormUtils.PADDING.RIGHT, this.Size.Height - (int)FormUtils.PADDING.BUTTONS - (int) FormUtils.PADDING.BOTTOM - ComboBox_FormSelect.Height);
        }


    }
}
