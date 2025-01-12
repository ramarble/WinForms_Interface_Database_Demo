using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using RA4_Ejercicios.Model;

namespace RA4_Ejercicios.View
{
    public partial class ReportForm : Form
    {
        public ReportForm(List<User> list)
        {
            InitializeComponent();
            userList = list;
        }

        List<User> userList;

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "../../View/Report1.rdlc";
            ReportDataSource r = new ReportDataSource("DataSet1", userList);
            this.reportViewer1.LocalReport.DataSources.Add(r);
            this.reportViewer1.RefreshReport();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.ToString() == "")
            {
                ReportForm_Load(null, null);
            }
            else
            {
                this.reportViewer1.LocalReport.DataSources.Clear();
                var newUserList = userList.Where(it => it.nif.ToString().Contains(maskedTextBox1.Text.ToString()));
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", newUserList));
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
