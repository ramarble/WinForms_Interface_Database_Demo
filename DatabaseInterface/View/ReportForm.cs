using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.ComponentModel;
using System.Drawing;
using DatabaseInterfaceDemo.Model;
using DatabaseInterfaceDemo.Model.ReportReferenceTuple;
using System.Linq;
using static DatabaseInterfaceDemo.Controller.FormUtils;
using DatabaseInterfaceDemo.Controller;

namespace DatabaseInterfaceDemo.View
{
    public partial class ReportForm : Form
    {   

        public static ReportDataSource ReportData { get; set; }
        public static BindingList<object> ListCurrentlyInUse { get; set; }
        public static BindingList<object> InitialList { get; set; }
        public static IFiltersBase FormTypeFilters;
        public static Type TypeHandled;

        public ReportForm(BindingList<object> list, Type DBType)
        {
            InitializeComponent();
            buttonLoadData.Click += ButtonLoadData_Click;

            TypeHandled = DBType;

            InitialList = list;
            ListCurrentlyInUse = list;

            ProgrammaticallyPlaceControls(null, null);

            InitializeComboBox();

            ResizeEnd += ProgrammaticallyPlaceControls;
        }

        /// <summary>
        /// On button press, deletes the existing data if it exists and initializes the new Report data and corresponding buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoadData_Click(object sender, EventArgs e)
        {
            //If you keep pressing the button, free memory collapse!
            //thank you GC
            if (FormTypeFilters != null)
            {
                ResizeEnd -= FormTypeFilters.ProgrammaticallyPlaceFilterControls;
                FormTypeFilters.RemoveControlsFromForm(FormTypeFilters.Controls);
            }
            
            FormTypeFilters = InitializeControlsFor(ComboBox_ReportSelect.SelectedItem, TypeHandled);
            
            ResizeEnd += FormTypeFilters.ProgrammaticallyPlaceFilterControls;
            
            InitializeReportViewer(TypeHandled);
        }

        //HEEEEELP
        //I WROTE THIS MYSELF
        //WHAT DOES IT DO
        /// <summary>
        /// Initializes an object derived from IFiltersBase based on the content from filterFormList which in this case will be derived from the item selected from the ComboBox
        /// The Activator creates an instance with parameters (this, ReportViewer)
        /// </summary>
        /// <param name="filterFormList"></param>
        /// <returns></returns>
        private IFiltersBase InitializeControlsFor(object filterFormList, Type TypeHandled)
        {

            switch (TypeHandled.Name)
            {
                case nameof(Empleado):
                    {
                        return (IFiltersBase)Activator.CreateInstance(
                            (ReportReference.EmployeeReportReferenceTuple().FirstOrDefault(
                                it => it.Item1 == (EmployeeReportList)Enum.Parse(typeof(EmployeeReportList), filterFormList.ToString())).Item2),
                                this, ReportViewer);
                    }
                case nameof(Producto):
                    { 
                        return (IFiltersBase)Activator.CreateInstance(
                            (ReportReference.ProductReportReferenceTuple().FirstOrDefault(
                                it => it.Item1 == (ProductReportList) Enum.Parse(typeof(ProductReportList), filterFormList.ToString())).Item2),
                                this, ReportViewer);
                    }
                }
            throw new Exception("frick off");

        }

        /// <summary>
        /// Initializes the ReportViewer based on the data found in the ComboBox that holds the types of Reports available
        /// </summary>
        private void InitializeReportViewer(Type TypeHandled)
        {
            if (ReportData != null)
            {
                ReportViewer.LocalReport.DataSources.Remove(ReportData);
            }

            ReportViewer.LocalReport.ReportPath = GetSelectedReportPathFromComboBox(ComboBox_ReportSelect.SelectedItem, TypeHandled);

            ReportData = GetReportDataSourceFromTypeHandled(TypeHandled, InitialList);
            ReportViewer.LocalReport.DataSources.Add(ReportData);
            ReportViewer.RefreshReport();
        }


        /// <summary>
        /// help
        /// </summary>
        /// <param name="ComboBox_SelectedItem"></param>
        /// <returns></returns>
        private string GetSelectedReportPathFromComboBox(object ComboBox_SelectedItem, Type TypeHandled)
        {
            switch (TypeHandled.Name)
            {
                case nameof(Empleado):
                    {
                        return ReportReference.EmployeeReportReferenceTuple().FirstOrDefault(
                            it => it.Item1 == (EmployeeReportList)Enum.Parse(typeof(EmployeeReportList), ComboBox_ReportSelect.SelectedItem.ToString())).Item3;
                    }
                case nameof(Producto):
                    {
                        return ReportReference.ProductReportReferenceTuple().FirstOrDefault(
                            it => it.Item1 == (ProductReportList)Enum.Parse(typeof(ProductReportList), ComboBox_ReportSelect.SelectedItem.ToString())).Item3;
                    }
            }
            throw new Exception("Shouldn't ever get here");
        }

        private void InitializeComboBox()
        {
            ComboBox_ReportSelect.SelectedValueChanged += ComboBox_FormSelect_SelectedValueChanged;
            switch (TypeHandled.Name)
            {
                case nameof(Empleado):
                    {
                        ComboBox_ReportSelect.Items.Clear();
                        ComboBox_ReportSelect.Items.AddRange(Enum.GetNames(typeof(EmployeeReportList)));
                        break;
                    }
                case nameof(Producto):
                    {
                        ComboBox_ReportSelect.Items.Clear();
                        ComboBox_ReportSelect.Items.AddRange(Enum.GetNames(typeof(ProductReportList)));
                        break;
                    }
            }
        }

        private ReportDataSource GetReportDataSourceFromTypeHandled(Type type, BindingList<object> InitialList)
        {
            switch (TypeHandled.Name)
            {
                case nameof(Empleado):
                    {
                        return new ReportDataSource("Empleado_DataSet", InitialList);
                    }
                case nameof(Producto):
                    {
                        return new ReportDataSource("Producto_DataSet", InitialList);
                    }
            }
            throw new InvalidEnumArgumentException("Wrong datasource, somehow");

        }

        private void ComboBox_FormSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboBox_ReportSelect.SelectedItem != null)
            {
                buttonLoadData.Enabled = true;
            } else
            {
                buttonLoadData.Enabled = false;
            }
        }

        private void ProgrammaticallyPlaceControls(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            FormUtils.PlaceControlTopLeft(ComboBox_ReportSelect);
            FormUtils.PlaceControlBelow(ReportViewer, ComboBox_ReportSelect);
            FormUtils.PlaceControlTopRightOf(buttonLoadData, ComboBox_ReportSelect);
            ReportViewer.Size = new Size(this.Size.Width - (int)FormUtils.PADDING.RIGHT, this.Size.Height - (int)FormUtils.PADDING.BUTTONS - (int) FormUtils.PADDING.BOTTOM - ComboBox_ReportSelect.Height);
        }


    }
}
