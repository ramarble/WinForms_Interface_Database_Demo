using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseInterfaceDemo.View;
using static DatabaseInterfaceDemo.Controller.FormUtils;

namespace DatabaseInterfaceDemo.Model.ReportReferenceTuple
{
    static class ReportReference
    {

        private static string BASEPATH = "../../View/Reports/";

        public static List<Tuple<EnumReportList, Type, string>> ReportReferenceTuple()
        {
            List<Tuple<EnumReportList, Type, string>> returnList = new List<Tuple<EnumReportList, Type, string>>();
            returnList.Add(Tuple.Create(
                EnumReportList.Products_General_FilterUp,
                typeof(Product_ListAll_Up_FilterControls),
                BASEPATH + "Report_Product_ListAll.rdlc"));
            returnList.Add(Tuple.Create(
                EnumReportList.Products_Stats,
                typeof(Product_Statistical_FilterControls),
                BASEPATH + "Report_Product_Statistical.rdlc"));
            returnList.Add(Tuple.Create(
                EnumReportList.Products_General_FilterDown,
                typeof(Product_ListAll_Down_FilterControls),
                BASEPATH + "Report_Product_ListAll.rdlc"));

            return returnList;
        }
    }
}
