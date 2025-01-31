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

        public ReportForm FormOrigin { get; set; }
        public ReportViewer ReportView { get; set; }
        public List<Control> Controls { get; set; }

        public Product_Statistical_FilterControls(ReportForm form, ReportViewer reportViewer) 
        {
            InitializeComponents();

            FormOrigin = form;
            ReportView = reportViewer;


            CategoryFilterCheckedBoxes.Items.AddRange(Enum.GetNames(typeof(Category)));

            Controls = AddControlsToList();
            AddControlsToForm(Controls);



            ButtonUpdateFilters.Click += UpdateFilters_Click;

            ProgrammaticallyPlaceFilterControls(null, null);
        }


        public List<Control> AddControlsToList()
        {
            List<Control> controls = new List<Control>();
            controls.Add(CategoryFilterCheckedBoxes);
            controls.Add(ButtonUpdateFilters);
            return controls;
        }


        public void AddControlsToForm(List<Control> Controls)
        {
            foreach (Control control in Controls)
            {
                FormOrigin.Controls.Add(control);
            }
        }

        public void RemoveControlsFromForm(List<Control> Controls)
        {
            foreach (Control control in Controls)
            {
                FormOrigin.Controls.Remove(control);
            }
        }


        public void UpdateFilters_Click(object sender, EventArgs e)
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

        public void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {
            FormUtils.PlaceControlBottomRightCorner(FormOrigin, ButtonUpdateFilters);
            FormUtils.PlaceControlBottomLeftCorner(FormOrigin, CategoryFilterCheckedBoxes);
        }


        public void InitializeComponents()
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
