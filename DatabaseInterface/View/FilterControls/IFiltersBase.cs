using System;

using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;

namespace DatabaseInterfaceDemo.View.FilterControls
{

    /// <summary>
    /// This will implement a ReportForm and ReportViewer which will be called or instantiated in the constructor that takes this interface.
    /// </summary>
    public interface IFiltersBase
    {
        ReportForm FormOrigin { get; set; }
        ReportViewer ReportView { get; set; }
        List<Control> Controls { get; set; }

        /// <summary>
        /// This will get called in the OnResize event for the form, which means every programmatically placed control should be updated here.
        /// </summary>
        void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e);

        ///<summary>
        /// Update ReportForm.ListCurrentlyInUse. Start using InitialList.
        /// This is the only method which, when called, has a base implementation that is reusable
        /// </summary>
        void UpdateFilters_Click(object sender, EventArgs e);

        /// <summary>
        /// Add and edit Controls here just like in a Designer file.
        /// </summary>
        void InitializeComponents();

        /// <summary>
        /// Add Controls to List<Control> Controls
        /// </summary>
        void AddControlsToList();

        /// <summary>
        /// Add List<Control> Controls to the Form
        /// </summary>
        /// <param name="Controls"></param>
        void AddControlsToForm(List<Control> Controls);

        /// <summary>
        /// Called to remove all the components from the source control
        /// </summary>
        void RemoveControlsFromForm(List<Control> Controls);
    }



}
