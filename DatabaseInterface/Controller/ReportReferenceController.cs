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

        //This should be initialized?
        static readonly Dictionary<string, string> l10n = LangClass.LangDictionary;

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

        public static FiltersBase InstanceFiltersBase(ReportReference reportReference, ReportForm form, ReportViewer reportViewer)
        {
            //FiltersBase constructor: (ReportForm form, ReportViewer reportView, string dataSourceName)
            return (FiltersBase)Activator.CreateInstance(reportReference.FilterControl, form, reportViewer, reportReference.DataSetName);
        }

        public static ReportReference GetReportReferenceByReportName(string item)
        {
            return ReportReferences.FirstOrDefault(
                it => it.ReportLocalizationName.Equals(item));
        }

    }
}
