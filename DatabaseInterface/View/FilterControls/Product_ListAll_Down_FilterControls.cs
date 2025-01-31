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
    public class Product_ListAll_Down_FilterControls : IFiltersBase
    {

        private NumericUpDown nudPrice;
        private Label labelPrice;
        private Label labelStock;
        private NumericUpDown nudStock;
        private CheckedListBox CategoryFilterCheckedBoxes;
        private Button ButtonUpdateFilters;

        public List<Control> Controls { get; set; }

        public ReportForm FormOrigin { get; set; }
        public ReportViewer ReportView { get; set; }

        public Product_ListAll_Down_FilterControls(ReportForm form, ReportViewer reportViewer)
        {
            InitializeComponents();

            FormOrigin = form;
            ReportView = reportViewer;

            CategoryFilterCheckedBoxes.Items.AddRange(Enum.GetNames(typeof(Category)));
            nudStock.Controls.RemoveAt(0);
            nudPrice.Controls.RemoveAt(0);

            Controls = AddControlsToList();
            AddControlsToForm(Controls);

            ButtonUpdateFilters.Click += UpdateFilters_Click;

            ProgrammaticallyPlaceFilterControls(null, null);
        }

        public List<Control> AddControlsToList()
        {
            List<Control> controls = new List<Control>();

            controls.Add(nudPrice);
            controls.Add(labelPrice);
            controls.Add(labelStock);
            controls.Add(nudStock);
            controls.Add(CategoryFilterCheckedBoxes);
            controls.Add(ButtonUpdateFilters);

            return controls;
        }

        public void AddControlsToForm(List<Control> list)
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

        public void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {
            FormUtils.PlaceControlBottomRightCorner(FormOrigin, ButtonUpdateFilters);
            FormUtils.PlaceControlBottomLeftCorner(FormOrigin, CategoryFilterCheckedBoxes);
            FormUtils.PlaceControlBottomRightOf(nudStock, CategoryFilterCheckedBoxes);
            FormUtils.PlaceControlBottomRightOf(nudPrice, nudStock);
            FormUtils.PlaceControlOnTopOf(labelStock, nudStock);
            FormUtils.PlaceControlOnTopOf(labelPrice, nudPrice);
        }

        public void UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnCategoryFilter(ReportForm.InitialList);
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnPriceFilter(ReportForm.ListCurrentlyInUse);
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnStockFilter(ReportForm.ListCurrentlyInUse);


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

        private BindingList<object> UpdateListBasedOnStockFilter(BindingList<object> listWorkedOn)
        {
            if (nudStock.Value > 0)
            {
                List<object> slice = new List<object>();
                slice.AddRange(listWorkedOn.Where(it => (it as Producto).Stock < nudStock.Value));

                return new BindingList<object>(slice);
            }
            else return listWorkedOn;
        }

        private BindingList<object> UpdateListBasedOnPriceFilter(BindingList<object> listWorkedOn)
        {
            if (nudPrice.Value > 0)
            {
                List<object> slice = new List<object>();
                slice.AddRange(listWorkedOn.Where(it => nudPrice.Value > (it as Producto).PricePerUnit));

                return new BindingList<object>(slice);
            }
            else return listWorkedOn;
        }

        /// <summary>
        ///
        /// </summary>
        public void InitializeComponents()
        {

            this.nudPrice = new NumericUpDown();
            this.labelPrice = new Label();
            this.labelStock = new Label();
            this.nudStock = new NumericUpDown();
            this.CategoryFilterCheckedBoxes = new CheckedListBox();
            ((ISupportInitialize)(this.nudPrice)).BeginInit();
            ((ISupportInitialize)(this.nudStock)).BeginInit();

            // 
            // nudPrice
            // 
            this.nudPrice.DecimalPlaces = 2;
            this.nudPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPrice.Location = new System.Drawing.Point(281, 27);
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(124, 26);
            this.nudPrice.TabIndex = 14;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(278, 3);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(127, 20);
            this.labelPrice.TabIndex = 13;
            this.labelPrice.Text = "Precio inferior a";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStock.Location = new System.Drawing.Point(129, 3);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(124, 20);
            this.labelStock.TabIndex = 12;
            this.labelStock.Text = "Stock inferior a";
            // 
            // nudStock
            // 
            this.nudStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudStock.Location = new System.Drawing.Point(129, 27);
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(124, 26);
            this.nudStock.TabIndex = 11;
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

            ((ISupportInitialize)(this.nudPrice)).EndInit();
            ((ISupportInitialize)(this.nudStock)).EndInit();
        }

    }
}
