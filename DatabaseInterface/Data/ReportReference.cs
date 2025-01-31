using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseInterfaceDemo.View;
using DatabaseInterfaceDemo.View.FilterControls;
using static DatabaseInterfaceDemo.Controller.FormUtils;

namespace DatabaseInterfaceDemo.Model.ReportReferenceTuple
{
    static class ReportReference
    {

        private static string BASEPATH = "../../View/Reports/";

        public static List<Tuple<ProductReportList, Type, string>> ProductReportReferenceTuple()
        {
            List<Tuple<ProductReportList, Type, string>> returnList = new List<Tuple<ProductReportList, Type, string>>();
            returnList.Add(Tuple.Create(
                ProductReportList.Products_General_FilterUp,
                typeof(Product_ListAll_Up_FilterControls),
                BASEPATH + "Report_Product_ListAll.rdlc"));
            returnList.Add(Tuple.Create(
                ProductReportList.Products_Stats,
                typeof(Product_Statistical_FilterControls),
                BASEPATH + "Report_Product_Statistical.rdlc"));
            returnList.Add(Tuple.Create(
                ProductReportList.Products_General_FilterDown,
                typeof(Product_ListAll_Down_FilterControls),
                BASEPATH + "Report_Product_ListAll.rdlc"));

            return returnList;
        }

        public static List<Tuple<EmployeeReportList, Type, string>> EmployeeReportReferenceTuple()
        {
            List<Tuple<EmployeeReportList, Type, string>> returnList = new List<Tuple<EmployeeReportList, Type, string>>();
            returnList.Add(Tuple.Create(
                EmployeeReportList.Employee_General_FilterUp,
                typeof(Employee_ListAll_Up_FilterControls),
                BASEPATH + "Report_Employee_ListAll.rdlc"));
            returnList.Add(Tuple.Create(
                EmployeeReportList.Employee_SalaryStats,
                typeof(Filterless),
                BASEPATH + "Report_Employee_SalaryStats.rdlc"));
            returnList.Add(Tuple.Create(
                EmployeeReportList.Employee_General_FilterDown,
                typeof(Employee_ListAll_Down_FilterControls),
                BASEPATH + "Report_Employee_ListAll.rdlc"));
            returnList.Add(Tuple.Create(
                EmployeeReportList.Employee_DaysWorkedStats,
                typeof(Filterless),
                BASEPATH + "Report_Employee_DaysWorkedStats.rdlc"));
            returnList.Add(Tuple.Create(
                EmployeeReportList.Employee_ByAge,
                typeof(Filterless),
                BASEPATH + "Report_Employee_ByAge.rdlc"));


            return returnList;
        }
    }
}
