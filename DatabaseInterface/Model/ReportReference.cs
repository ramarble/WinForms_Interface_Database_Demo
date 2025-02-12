using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DatabaseInterfaceDemo.Controller.FormUtils;
using DatabaseInterfaceDemo.View.FilterControls;

namespace DatabaseInterfaceDemo.Model
{
    internal class ReportReference
    {
        public string ReportName { get; set; }
        public Type FilterControl { get; set; }
        public Type BaseType { get; set; }
        public string Path { get; set; }
        public string DataSetName { get; set; }

        public ReportReference(string report, Type filterControl, Type baseType, string path, string dataSetName)
        {
            ReportName = report;
            FilterControl = filterControl;
            BaseType = baseType;
            Path = path;
            DataSetName = dataSetName;
        }
    }
}
