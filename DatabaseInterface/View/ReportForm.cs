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
using DatabaseInterfaceDemo.View.FilterControls;

namespace DatabaseInterfaceDemo.View
{
    /// <summary>
    /// Form that loads a RDLC report on a ReportViewer based on the type of
    /// Database loaded.
    /// </summary>
    public partial class ReportForm : Form
    {   
        /// <summary>
        /// ReportDataSource managed by <see cref="DBType"/>
        /// </summary>
        public static ReportDataSource ReportData { get; set; }

        /// <summary>
        /// List displayed as DataSource for <see cref="reportViewer"/>
        /// </summary>
        public static BindingList<object> ListCurrentlyInUse { get; set; }

        /// <summary>
        /// Reference of the list shown in <see cref="reportViewer"/> in its initial, unmodified state.
        /// </summary>
        public static BindingList<object> InitialList { get; set; }

        /// <summary>
        /// Controls class added in runtime to interface with the <see cref="ListCurrentlyInUse"/> shown in <see cref="reportViewer"/>
        /// </summary>
        public static FiltersBase FilterControls;

        /// <summary>
        /// Type that dictates which values will be present at runtime.
        /// </summary>
        public static Type DBType;

        /// <summary>
        /// Form that loads a RDLC report on a <typeparamref name="ReportViewer"/> based on the type of
        /// Database loaded <paramref name="DBType"/>.
        /// </summary>
        /// <param name="list">List containing the database</param>
        /// <param name="DBType">Type of database loaded</param>
        public ReportForm(BindingList<object> list, Type DBType)
        {
            InitializeComponent();
            buttonLoadData.Click += ButtonLoadData_Click;

            ReportForm.DBType = DBType;

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
            if (FilterControls != null)
            {
                ResizeEnd -= FilterControls.ProgrammaticallyPlaceFilterControls;
                FilterControls.RemoveControlsFromForm(FilterControls.Controls);
            }
            
            FilterControls = InstanceFormFilters(ComboBox_ReportSelect.SelectedItem);
            
            ResizeEnd += FilterControls.ProgrammaticallyPlaceFilterControls;
            
            InitializeReportViewer();
        }

        /// <summary>
        /// Called on <see cref="ReportForm.ButtonLoadData_Click(object, EventArgs)"/>. 
        /// Parses the item chosen under <see cref="ComboBox_ReportSelect"/> as an object of type <see cref="FiltersBase"/> from the reference tuples found in <see cref="FilterReportReference"/>.
        /// The Activator creates an instance of said FiltersBase with parameters (this, ReportViewer)
        /// </summary>
        /// <param name="selectedReportForm"></param>
        /// <returns>Parsed <see cref="FiltersBase"/> from <paramref name="selectedReportForm"/></returns>
        private FiltersBase InstanceFormFilters(object selectedReportForm)
        {

            switch (DBType.Name)
            {
                case nameof(Empleado):
                    {
                        return (FiltersBase)Activator.CreateInstance(
                            (FilterReportReference.EmployeeReportReferenceTuple().FirstOrDefault(
                                it => it.Item1 == (EmployeeReportList)Enum.Parse(typeof(EmployeeReportList), selectedReportForm.ToString())).Item2),
                                this, reportViewer, "Empleado_DataSet");
                    }
                case nameof(Producto):
                    { 
                        return (FiltersBase)Activator.CreateInstance(
                            (FilterReportReference.ProductReportReferenceTuple().FirstOrDefault(
                                it => it.Item1 == (ProductReportList) Enum.Parse(typeof(ProductReportList), selectedReportForm.ToString())).Item2),
                                this, reportViewer, "Producto_DataSet");
                    }
                }
            throw new Exception("Unmanaged code path");

        }

        /// <summary>
        /// Initializes the <typeparamref name="ReportViewer"/> based on the <typeparamref name="Type"/> referenced in the Tuple <see cref="FilterReportReference"/>
        /// </summary>
        private void InitializeReportViewer()
        {
            if (ReportData != null)
            {
                reportViewer.LocalReport.DataSources.Remove(ReportData);
            }

            reportViewer.LocalReport.ReportPath = GetSelectedReportPathFromComboBox(ComboBox_ReportSelect.SelectedItem);

            ReportData = GetReportDataSourceFromTypeHandled(InitialList);
            reportViewer.LocalReport.DataSources.Add(ReportData);
            reportViewer.RefreshReport();
        }


        /// <summary>
        /// Returns the Path of the relevant RDLC from the chosen <paramref name="ComboBox_SelectedItem"/> referenced in <see cref="FilterReportReference"/>
        /// </summary>
        /// <param name="ComboBox_SelectedItem"></param>
        /// <returns></returns>
        private string GetSelectedReportPathFromComboBox(object ComboBox_SelectedItem)
        {
            switch (DBType.Name)
            {
                case nameof(Empleado):
                    {
                        return FilterReportReference.EmployeeReportReferenceTuple().FirstOrDefault(
                            it => it.Item1 == (EmployeeReportList)Enum.Parse(typeof(EmployeeReportList), ComboBox_ReportSelect.SelectedItem.ToString())).Item3;
                    }
                case nameof(Producto):
                    {
                        return FilterReportReference.ProductReportReferenceTuple().FirstOrDefault(
                            it => it.Item1 == (ProductReportList)Enum.Parse(typeof(ProductReportList), ComboBox_ReportSelect.SelectedItem.ToString())).Item3;
                    }
            }
            throw new Exception("Unmanaged code path");
        }

        /// <summary>
        /// Populates <see cref="ComboBox_ReportSelect"/> based on the value in <see cref="ReportForm.DBType"/>
        /// </summary>
        private void InitializeComboBox()
        {
            ComboBox_ReportSelect.SelectedValueChanged += ComboBox_ReportSelect_SelectedValueChanged;
            switch (DBType.Name)
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

        /// <summary>
        /// Returns a new <typeparamref name="ReportDataSource"/> based on the type found in <see cref="DBType"/>
        /// </summary>
        /// <param name="InitialList"></param>
        /// <returns></returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        private ReportDataSource GetReportDataSourceFromTypeHandled(BindingList<object> InitialList)
        {
            switch (DBType.Name)
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

        /// <summary>
        /// Method fired when <see cref="ComboBox_ReportSelect"/> returns a valid value which enables <see cref="buttonLoadData"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_ReportSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ComboBox_ReportSelect.SelectedItem != null)
            {
                buttonLoadData.Enabled = true;
            } else
            {
                buttonLoadData.Enabled = false;
            }
        }

        /// <summary>
        /// Programmatically places the Controls in the form, overriding the designer file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgrammaticallyPlaceControls(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.Manual;
            CustomDesigner.PlaceControlTopLeft(ComboBox_ReportSelect);
            CustomDesigner.PlaceControlBelow(reportViewer, ComboBox_ReportSelect);
            CustomDesigner.PlaceControlTopRightOf(buttonLoadData, ComboBox_ReportSelect);
            CustomDesigner.PlaceControlBottomRightOf(labelLoadData, buttonLoadData);
            reportViewer.Size = new Size(Size.Width - (int)CustomDesigner.PADDING.RIGHT, 
            Size.Height - (int)CustomDesigner.PADDING.BUTTONS - (int) CustomDesigner.PADDING.BOTTOM - ComboBox_ReportSelect.Height);
        }


    }
}
