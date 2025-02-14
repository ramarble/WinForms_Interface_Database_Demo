using System;

namespace DatabaseInterfaceDemo.Model
{
    internal class ReportReference
    {
        public string ReportLocalizationName { get; set; }
        public Type FilterControl { get; set; }
        public Type BaseType { get; set; }
        public string Path { get; set; }
        public string DataSetName { get; set; }

        public ReportReference(string reportLocalizationName, Type FiltersBaseChild, Type baseType, string path, string dataSetName)
        {
            ReportLocalizationName = reportLocalizationName;
            FilterControl = FiltersBaseChild;
            BaseType = baseType;
            Path = path;
            DataSetName = dataSetName;
        }
    }
}
