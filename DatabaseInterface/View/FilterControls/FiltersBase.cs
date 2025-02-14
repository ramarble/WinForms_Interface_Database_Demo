using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseInterfaceDemo.View.FilterControls
{
    /// <summary>
    /// Base class that implements methods to add buttons to interface with a ReportDataSource in a ReportViewer
    /// </summary>
    public abstract class FiltersBase
    {
        /// <summary>
        /// Name for the ReportDataSource added in the ReportViewer
        /// </summary>
        public string DataSourceName { get; set; }
        /// <summary>
        /// Origin form in which the controls will be added
        /// </summary>
        public ReportForm FormOrigin { get; set; }
        /// <summary>
        /// ReportView that will be updated by the controls being added
        /// </summary>
        public ReportViewer ReportView { get; set; }
        /// <summary>
        /// List of Controls that will be added to the ReportForm.
        /// </summary>
        public List<Control> Controls { get; set; }

        /// <summary>
        /// Button provided by default in FiltersBase
        /// </summary>
        public Button ButtonUpdateFilters { get; set; }

        /// <summary>
        /// Parent class that initializes the base structure for the styling and interfacing of a specific ReportViewer
        /// </summary>
        /// <param name="form">The origin form in which to add the Controls</param>
        /// <param name="reportView">the ReportViewer Control to update with the Controls</param>
        /// <param name="dataSourceName">Name for the ReportDataSource added in the ReportViewer</param>
        internal FiltersBase(ReportForm form, ReportViewer reportView, string dataSourceName)
        {
            Controls = new List<Control>();
            DataSourceName = dataSourceName;
            FormOrigin = form;
            ReportView = reportView;
        }

        /// <summary>
        /// Method that must be called on constructor for children of <see cref="FiltersBase"/> that initializes the base functionality of the class
        /// </summary>
        /// <param name="form"></param>
        /// <param name="reportViewer"></param>
        /// <param name="controlsFromChild">The controls initialized in the child instance that will be added to the form</param>
        public void Initialize(params Control[] controlsFromChild)
        {

            //This method might be overridden
            
            StyleControls();

            //Only add the button if there's other controls being added
            if (controlsFromChild.Length > 0)
            {
                AddControlsToList(ButtonUpdateFilters);
            }

            AddControlsToList(controlsFromChild);
            
            AddControlsToForm(Controls);
            //This method might be overridden
            ButtonUpdateFilters.Click += UpdateFilters_Click;
            //This method might be overridden
            ProgrammaticallyPlaceFilterControls(null, null);
        }

        /// <summary>
        /// Final method that adds all the List&lt;Control&gt;
        ///<see cref="Controls"/>from the list called by <see cref="AddControlsToList">AddControlsToList</see>
        /// </summary>
        /// <param name="Controls"></param>
        public void AddControlsToForm(List<Control> Controls)
        {
            foreach (Control control in Controls)
            {
                FormOrigin.Controls.Add(control);
            }
        }

        /// <summary>
        /// Base implementation for adding Controls to List.
        /// </summary>
        public void AddControlsToList(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                Controls.Add(control);
            }
        }

        /// <summary>
        /// Base implementation for styling Controls programmatically for <see cref="FiltersBase"/>.
        /// Reference from Designer.cs files. This method should call its base implementation when overridden if it wants the base implementation of the button.
        /// </summary>
        public virtual void StyleControls()
        {
            ButtonUpdateFilters = new Button();
            ButtonUpdateFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ButtonUpdateFilters.Size = new System.Drawing.Size(192, 44);
            ButtonUpdateFilters.Text = "Filtrar por categoría";
            ButtonUpdateFilters.UseVisualStyleBackColor = true;
        }

        /// <summary>
        /// Base implementation for placing the Controls in a form by a list of methods found in <see cref="FormUtils"/>.
        /// This method is called on Window resize. This method should call its base implementation when overridden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {
            CustomDesigner.PlaceControlBottomRightCorner(FormOrigin, ButtonUpdateFilters);
        }

        /// <summary>
        /// Final method called when the ReportViewer source is changed.
        /// </summary>
        /// <param name="Controls"></param>
        /// <seealso cref="ReportForm.ButtonLoadData_Click(object, EventArgs)"/>
        public void RemoveControlsFromForm(List<Control> Controls)
        {
            foreach (Control control in Controls)
            {
                FormOrigin.Controls.Remove(control);
            }
        }

        /// <summary>
        /// Method fired when <see cref="ButtonUpdateFilters"/> is pressed.
        /// The base method updates and refreshes the report based on the 
        /// BindingList found in <see cref="ReportForm.ListCurrentlyInUse"></see>.
        /// The first update should call <see cref="ReportForm.InitialList"/>
        /// This method should call its base implementation when overridden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportView.LocalReport.DataSources.Remove(ReportForm.ReportData);
            ReportForm.ReportData = new ReportDataSource(DataSourceName, ReportForm.ListCurrentlyInUse);
            ReportView.LocalReport.DataSources.Add(ReportForm.ReportData);
            ReportView.RefreshReport();
        }
    }
}
