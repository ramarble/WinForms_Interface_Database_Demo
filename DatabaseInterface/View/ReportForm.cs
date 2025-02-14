using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.ComponentModel;
using System.Drawing;
using DatabaseInterfaceDemo.Model;
using System.Linq;
using static DatabaseInterfaceDemo.Controller.FormUtils;
using static DatabaseInterfaceDemo.Controller.ReportReferenceController;
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

            ReportReference reportReference = GetReportReferenceByReportName(ComboBox_ReportSelect.SelectedItem.ToString());
            
            FilterControls = InstanceFiltersBase(reportReference, this, reportViewer);
            
            ResizeEnd += FilterControls.ProgrammaticallyPlaceFilterControls;
            
            InitializeReportViewer(reportReference);
        }

        /// <summary>
        /// Initializes the <typeparamref name="ReportViewer"/> based on the <typeparamref name="Type"/> referenced in the Tuple <see cref="ReportReferences"/>
        /// </summary>
        private void InitializeReportViewer(ReportReference reportReference)
        {
            if (ReportData != null)
            {
                reportViewer.LocalReport.DataSources.Remove(ReportData);
            }

            reportViewer.LocalReport.ReportPath = reportReference.Path;

            ReportData = new ReportDataSource(reportReference.DataSetName, InitialList);
            reportViewer.LocalReport.DataSources.Add(ReportData);
            reportViewer.RefreshReport();
        }



        /// <summary>
        /// Populates <see cref="ComboBox_ReportSelect"/> based on the value in <see cref="ReportForm.DBType"/>
        /// </summary>
        private void InitializeComboBox()
        {
            ComboBox_ReportSelect.SelectedValueChanged += ComboBox_ReportSelect_SelectedValueChanged;
            foreach (var it in ReportReferences)
            {
                //only load the relevant entries
                if (it.BaseType == DBType)
                {
                    ComboBox_ReportSelect.Items.Add(it.ReportLocalizationName);
                }
            }
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
