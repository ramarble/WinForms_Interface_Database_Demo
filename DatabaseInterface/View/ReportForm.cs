using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DatabaseInterface.Model;

namespace DatabaseInterface.View
{
    public partial class ReportForm : Form
    {
        public ReportForm(List<object> list)
        {
            InitializeComponent();
            objectList = list;
        }

        List<object> objectList;

        private void ReportForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportPath = "../../View/Report1.rdlc";
            ReportDataSource r = new ReportDataSource("DataSet1", objectList);
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
                //THIS WON'T WORK FOR NOW
                this.reportViewer1.LocalReport.DataSources.Clear();
                //var newUserList = objectList.Where(it => it.nif.ToString().Contains(maskedTextBox1.Text.ToString()));
                //this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", newUserList));
                //this.reportViewer1.RefreshReport();
            }
        }
    }
}
