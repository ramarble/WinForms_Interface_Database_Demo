using Microsoft.Reporting.WinForms;

namespace DatabaseInterfaceDemo.View.FilterControls
{
    internal class Filterless : FiltersBase
    {

        public Filterless(ReportForm form, ReportViewer reportViewer, string dataSourceType): base(form, reportViewer, dataSourceType)
        {
            Initialize(form, reportViewer);
        }

    }
}
