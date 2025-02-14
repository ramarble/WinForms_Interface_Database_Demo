using DatabaseInterfaceDemo.Lang;
using DatabaseInterfaceDemo.Model;
using DatabaseInterfaceDemo.View;
using DatabaseInterfaceDemo.View.FilterControls;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseInterfaceDemo.Controller
{
    class ReportReferenceController

    {
        private static string BASEPATH = "../../View/Reports/";
        private static string PRODUCTO_DATASET = "Producto_DataSet";
        private static string EMPLEADO_DATASET = "Empleado_DataSet";

        static readonly Dictionary<string, string> l10n = LangClass.LangDictionary;
        /// <summary>
        /// Initialization of a list of ReportReferences
        /// </summary>
        public static List<ReportReference> ReportReferences = new List<ReportReference>
        {
            new ReportReference(l10n["Products_General_FilterUp"], typeof(Product_ListAll_Up_FilterControls), typeof(Producto), BASEPATH + "Report_Product_ListAll.rdlc", PRODUCTO_DATASET),
            new ReportReference(l10n["Products_Stats"], typeof(Product_Statistical_FilterControls), typeof(Producto),  BASEPATH + "Report_Product_Statistical.rdlc", PRODUCTO_DATASET),
            new ReportReference(l10n["Products_General_FilterDown"], typeof(Product_ListAll_Down_FilterControls), typeof(Producto), BASEPATH + "Report_Product_ListAll.rdlc", PRODUCTO_DATASET),
            new ReportReference(l10n["Products_TotalValue"], typeof(Product_Statistical_FilterControls), typeof(Producto), BASEPATH + "Report_Product_TotalValue.rdlc", PRODUCTO_DATASET),
            new ReportReference(l10n["Employee_General_FilterUp"], typeof(Employee_ListAll_Up_FilterControls), typeof(Empleado), BASEPATH + "Report_Employee_ListAll.rdlc", EMPLEADO_DATASET),
            new ReportReference(l10n["Employee_General_FilterDown"], typeof(Employee_ListAll_Down_FilterControls), typeof(Empleado), BASEPATH + "Report_Employee_ListAll.rdlc", EMPLEADO_DATASET),
            new ReportReference(l10n["Employee_SalaryStats"], typeof(Filterless), typeof(Empleado),  BASEPATH + "Report_Employee_SalaryStats.rdlc", EMPLEADO_DATASET),
            new ReportReference(l10n["Employee_DaysWorkedStats"], typeof(Filterless), typeof(Empleado), BASEPATH + "Report_Employee_DaysWorkedStats.rdlc", EMPLEADO_DATASET),
            new ReportReference(l10n["Employee_ByAge"], typeof(Filterless), typeof(Empleado), BASEPATH + "Report_Employee_ByAge.rdlc", EMPLEADO_DATASET)
        };

        /// <summary>
        /// Creates an Instance of type FiltersBase based on the information found in the parameter reportReference
        /// </summary>
        /// <param name="reportReference">Class containing the data from which the FiltersBase class will be returned</param>
        /// <param name="form">ReportForm in which the data will be updated</param>
        /// <param name="reportViewer">ReportViewer in which the data will be updated</param>
        /// <returns>Instance of <see cref="FiltersBase"/></returns>
        public static FiltersBase InstanceFiltersBase(ReportReference reportReference, ReportForm form, ReportViewer reportViewer)
        {
            //FiltersBase constructor: (ReportForm form, ReportViewer reportView, string dataSourceName)
            return (FiltersBase)Activator.CreateInstance(reportReference.FiltersBaseClass, form, reportViewer, reportReference.DataSetName);
        }

        public static ReportReference GetReportReferenceByReportName(string item)
        {
            return ReportReferences.FirstOrDefault(
                it => it.ReportLocalizedName.Equals(item));
        }

    }
}
