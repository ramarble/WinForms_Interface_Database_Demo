using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using DatabaseInterfaceDemo.Model;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.CodeDom;

namespace DatabaseInterfaceDemo.View
{
    public partial class ReportForm : Form
    {

        static ReportDataSource r;
        static ReportDataSource r2;
        static BindingList<object> ListCurrentlyInUse;
        static BindingList<object> InitialList;
        static int PADDING_LEFT = 12;
        static int PADDING_RIGHT = 42;
        static int PADDING_BOTTOM = 42;
        static int PADDING_TOP = 12;
        static int PADDING_BUTTONS = 112;
        public ReportForm(BindingList<object> list)
        {
            InitializeComponent();

            InitialList = list;
            ListCurrentlyInUse = list;
            CategoryFilterCheckedBoxes.Items.AddRange(Enum.GetNames(typeof(Category)));

            nudStock.Controls.RemoveAt(0);
            nudPrice.Controls.RemoveAt(0);

            ProgramaticallyPlaceObjects(null, null);
            InitializeReportViewer();
            this.ResizeEnd += ProgramaticallyPlaceObjects;
        }

        private void InitializeReportViewer()
        {
            this.reportViewer1.LocalReport.ReportPath = "../../View/Report1.rdlc";


            r = new ReportDataSource("Producto_DataSet", ListCurrentlyInUse);
            this.reportViewer1.LocalReport.DataSources.Add(r);
            this.reportViewer1.RefreshReport();
        }

        private void ProgramaticallyPlaceObjects(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            reportViewer1.Location = new Point(PADDING_LEFT, PADDING_TOP);
            reportViewer1.Size = new Size(this.Size.Width - PADDING_RIGHT, this.Size.Height - PADDING_BUTTONS);

            CategoryFilterCheckedBoxes.Location = new Point(
                PADDING_LEFT, 
                Size.Height - PADDING_BOTTOM - CategoryFilterCheckedBoxes.Size.Height);

            nudStock.Location = new Point(
                PADDING_LEFT + CategoryFilterCheckedBoxes.Location.X + CategoryFilterCheckedBoxes.Width,
                Size.Height - PADDING_BOTTOM - nudStock.Size.Height);

            labelStock.Location = new Point(
                nudStock.Location.X,
                Size.Height - PADDING_BOTTOM - labelStock.Size.Height - nudStock.Size.Height);
            
            
            nudPrice.Location = new Point(
                PADDING_LEFT + nudStock.Location.X + nudStock.Width, 
                Size.Height - PADDING_BOTTOM - nudPrice.Size.Height);

            labelPrice.Location = new Point(
                nudPrice.Location.X,
                Size.Height - PADDING_BOTTOM - labelPrice.Size.Height - nudPrice.Size.Height);

            buttonUpdateFilters.Location = new Point(
                Size.Width - buttonUpdateFilters.Width - PADDING_RIGHT,
                Size.Height - PADDING_BOTTOM - buttonUpdateFilters.Height);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Remove(r);
            ListCurrentlyInUse = UpdateListBasedOnCategoryFilter(InitialList);
            ListCurrentlyInUse = UpdateListBasedOnPriceFilter(ListCurrentlyInUse);
            ListCurrentlyInUse = UpdateListBasedOnStockFilter(ListCurrentlyInUse);


            r = new ReportDataSource("Producto_DataSet", ListCurrentlyInUse);


            this.reportViewer1.LocalReport.DataSources.Add(r);
            this.reportViewer1.RefreshReport();
        }


        private BindingList<object> UpdateListBasedOnCategoryFilter(BindingList<object> listWorkedOn)
        {
            if (CategoryFilterCheckedBoxes.CheckedItems.Count > 0)
            {
                List<object> slice = new List<object>();
                foreach (var c in CategoryFilterCheckedBoxes.CheckedItems)
                {
                    slice.AddRange(listWorkedOn.Where(it => (it as Producto).Category == (Category)Enum.Parse(typeof(Category), c.ToString())));
                }
                return new BindingList<object>(slice);
            }
            else return listWorkedOn;
        }

        private BindingList<object> UpdateListBasedOnStockFilter(BindingList<object> listWorkedOn)
        {

            if (nudStock.Value > 0)
            {
                List<object> slice = new List<object>();
                slice.AddRange(listWorkedOn.Where(it => (it as Producto).Stock > nudStock.Value));

                return new BindingList<object>(slice);
            }
            else return listWorkedOn;

        }

        private BindingList<object> UpdateListBasedOnPriceFilter(BindingList<object> listWorkedOn)
        {
            if (nudPrice.Value > 0)
            {
                List<object> slice = new List<object>();
                slice.AddRange(listWorkedOn.Where(it => nudPrice.Value < (it as Producto).PricePerUnit));


                return new BindingList<object>(slice);
            }
            else return listWorkedOn;
        }

    }
}
