using System;

namespace DatabaseInterfaceDemo.Model
{
    /// <summary>
    /// Container class for linking information of relevant data for a Report and its corresponding filters
    /// </summary>
    internal class ReportReference
    {
        /// <summary>
        /// Value obtained from the selected ComboBox which matches the value found in <see cref="DatabaseInterfaceDemo.Controller"/> 
        /// </summary>
        public string ReportLocalizedName { get; set; }
        /// <summary>
        /// Reference to the class of Type FiltersBase
        /// </summary>
        public Type FiltersBaseClass { get; set; } 
        /// <summary>
        /// Type of the underlying Database/BindingList
        /// </summary>
        public Type BaseType { get; set; }
        /// <summary>
        /// Path where the RDLC file is found
        /// </summary>
        public string Path { get; set; }
        public string DataSetName { get; set; }

        public ReportReference(string reportLocalizationName, Type FiltersBaseChild, Type baseType, string path, string dataSetName)
        {
            ReportLocalizedName = reportLocalizationName;
            FiltersBaseClass = FiltersBaseChild;
            BaseType = baseType;
            Path = path;
            DataSetName = dataSetName;
        }
    }
}
