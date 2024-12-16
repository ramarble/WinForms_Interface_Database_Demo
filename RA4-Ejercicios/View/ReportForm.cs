using Microsoft.Reporting.WinForms;
using RA4_Ejercicios.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA4_Ejercicios.View
{
    public partial class ReportForm : Form
    {
        List<User> userList;
        public ReportForm(List<User> list)
        {
            InitializeComponent();
            userList = list;
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "../../View/Report1.rdlc";
            ReportDataSource r = new ReportDataSource("DataSet1", userList);
            this.reportViewer1.LocalReport.DataSources.Add(r);
            this.reportViewer1.RefreshReport();

        }
    }
}
