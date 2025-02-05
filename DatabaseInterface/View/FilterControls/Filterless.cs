using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace DatabaseInterfaceDemo.View.FilterControls
{
    internal class Filterless : IFiltersBase
    {
        public ReportForm FormOrigin { get; set; }
        public ReportViewer ReportView { get; set; }
        public List<Control> Controls { get; set; }

        public Filterless(ReportForm form, ReportViewer reportViewer)
        {

            FormOrigin = form;
            ReportView = reportViewer;
        }

        public void AddControlsToForm(List<Control> Controls)
        {

        }

        public void AddControlsToList()
        {
        }

        public void InitializeComponents()
        {

        }

        public void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {

        }

        public void RemoveControlsFromForm(List<Control> Controls)
        {
        }

        public void UpdateFilters_Click(object sender, EventArgs e)
        {
        }
    }
}
