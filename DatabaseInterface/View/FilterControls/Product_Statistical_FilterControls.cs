using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Model;
using Microsoft.Reporting.WinForms;

namespace DatabaseInterfaceDemo.View
{
    public class Product_Statistical_FilterControls : IFiltersBase
    {
        private CheckedListBox CategoryFilterCheckedBoxes;
        private Button ButtonUpdateFilters;

        ReportForm IFiltersBase.FormOrigin { get; set; }
        ReportViewer IFiltersBase.ReportView { get; set; }
        public Product_Statistical_FilterControls(ReportForm form, ReportViewer reportViewer) 
        {
            ((IFiltersBase) this).InitializeComponents();

            ((IFiltersBase)this).FormOrigin = form;
            ((IFiltersBase)this).ReportView = reportViewer;


            ((IFiltersBase)this).FormOrigin.Controls.Add(CategoryFilterCheckedBoxes);
            ((IFiltersBase)this).FormOrigin.Controls.Add(ButtonUpdateFilters);
            ButtonUpdateFilters.Click += ((IFiltersBase)this).UpdateFilters_Click;

            ((IFiltersBase)this).ProgrammaticallyPlaceFilterControls(null, null);
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

        void IFiltersBase.ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {
            FormUtils.PlaceControlBottomRightCorner(((IFiltersBase)this).FormOrigin, ButtonUpdateFilters);
            FormUtils.PlaceControlBottomLeftCorner(((IFiltersBase)this).FormOrigin, CategoryFilterCheckedBoxes);
        }

        void IFiltersBase.UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnCategoryFilter(ReportForm.InitialList);

            ((IFiltersBase)this).ReportView.LocalReport.DataSources.Remove(ReportForm.ReportData);
            ReportForm.ReportData = new ReportDataSource("Producto_DataSet", ReportForm.ListCurrentlyInUse);
            ((IFiltersBase)this).ReportView.LocalReport.DataSources.Add(ReportForm.ReportData);
            ((IFiltersBase)this).ReportView.RefreshReport();
        }

        void IFiltersBase.InitializeComponents()
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
            // 
            // buttonUpdateFilters
            // 
            this.ButtonUpdateFilters = new Button();
            this.ButtonUpdateFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonUpdateFilters.Name = "buttonUpdateFilters";
            this.ButtonUpdateFilters.Size = new System.Drawing.Size(192, 44);
            this.ButtonUpdateFilters.TabIndex = 9;
            this.ButtonUpdateFilters.Text = "Filtrar por categoría";
            this.ButtonUpdateFilters.UseVisualStyleBackColor = true;
        }
    }
}
