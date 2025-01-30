using System;

using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using Microsoft.Reporting.WinForms;

namespace DatabaseInterfaceDemo.View
{
    public enum FilterFormList
    {
        Products,
        idkyet
    }
    public class FilterControlsBase
    {
        public ReportForm Form;
        public ReportViewer ReportView;

        /// <summary>
        /// Empty constructor
        /// </summary>
        /// <param name="form"></param>
        /// <param name="reportView"></param>
        public FilterControlsBase(ReportForm form, ReportViewer reportView){}

        /// <summary>
        /// This will get called in the OnResize event for the form, which means every programmatically placed control should be updated here.
        /// </summary>
        public virtual void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e){}

        ///<summary>
        /// Update ReportForm.ListCurrentlyInUse. Start using InitialList.
        /// This is the only method which, when called, has a base implementation that is reusable
        /// </summary>
        public virtual void UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportView.LocalReport.DataSources.Remove(ReportForm.ReportData);
            ReportForm.ReportData = new ReportDataSource("Producto_DataSet", ReportForm.ListCurrentlyInUse);
            ReportView.LocalReport.DataSources.Add(ReportForm.ReportData);
            ReportView.RefreshReport();
        }

        /// <summary>
        /// Add and edit Controls here just like in a Designer file.
        /// </summary>
        public virtual void InitializeComponent(){}

    }



}
