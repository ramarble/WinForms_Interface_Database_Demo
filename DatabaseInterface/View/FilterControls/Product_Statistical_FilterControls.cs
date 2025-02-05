// Ignore Spelling: Programmatically

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Model;
using Microsoft.Reporting.WinForms;

namespace DatabaseInterfaceDemo.View.FilterControls
{
    public class Product_Statistical_FilterControls : FiltersBase
    {
        private CheckedListBox CategoryFilterCheckedBoxes;

        public override ReportForm FormOrigin { get; set; }
        public override ReportViewer ReportView { get; set; }
        public override List<Control> Controls { get; set; }
        public override Button ButtonUpdateFilters { get; set; }

        public Product_Statistical_FilterControls(ReportForm form, ReportViewer reportViewer) 
        {
            FakeConstructor(form, reportViewer);
            CategoryFilterCheckedBoxes.Items.AddRange(Enum.GetNames(typeof(Category)));

        }

        /// <inheritdoc/>
        public override void AddControlsToList()
        {
            Controls.Add(CategoryFilterCheckedBoxes);
            Controls.Add(ButtonUpdateFilters);
        }


        /// <inheritdoc/>
        public override void UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnCategoryFilter(ReportForm.InitialList);

            ReportView.LocalReport.DataSources.Remove(ReportForm.ReportData);
            ReportForm.ReportData = new ReportDataSource("Producto_DataSet", ReportForm.ListCurrentlyInUse);
            ReportView.LocalReport.DataSources.Add(ReportForm.ReportData);
            ReportView.RefreshReport();
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

        /// <inheritdoc/>
        public override void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {
            FormUtils.PlaceControlBottomRightCorner(FormOrigin, ButtonUpdateFilters);
            FormUtils.PlaceControlBottomLeftCorner(FormOrigin, CategoryFilterCheckedBoxes);
        }
        /// <inheritdoc/>
        public override void InitializeComponents()
        {
            this.CategoryFilterCheckedBoxes = new CheckedListBox();

            // 
            // CategoryFilterCheckedBoxes
            // 
            this.CategoryFilterCheckedBoxes.FormattingEnabled = true;
            this.CategoryFilterCheckedBoxes.Location = new System.Drawing.Point(3, 3);
            this.CategoryFilterCheckedBoxes.Name = "CategoryFilterCheckedBoxes";
            this.CategoryFilterCheckedBoxes.Size = new System.Drawing.Size(120, 49);
            this.CategoryFilterCheckedBoxes.TabIndex = 10;

            base.InitializeComponents();
        }
    }
}
