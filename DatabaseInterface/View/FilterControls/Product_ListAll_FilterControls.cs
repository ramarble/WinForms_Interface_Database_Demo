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
    public class Product_ListAll_FilterControls : IFiltersBase
    {

        private NumericUpDown nudPrice;
        private Label labelPrice;
        private Label labelStock;
        private NumericUpDown nudStock;
        private CheckedListBox CategoryFilterCheckedBoxes;
        private Button ButtonUpdateFilters;

        ReportForm IFiltersBase.FormOrigin { get; set; }
        ReportViewer IFiltersBase.ReportView { get; set; }

        public Product_ListAll_FilterControls(ReportForm form, ReportViewer reportViewer)
        {
            ((IFiltersBase) this).InitializeComponents();

            ((IFiltersBase)this).FormOrigin = form;
            ((IFiltersBase)this).ReportView = reportViewer;

            CategoryFilterCheckedBoxes.Items.AddRange(Enum.GetNames(typeof(Category)));
            nudStock.Controls.RemoveAt(0);
            nudPrice.Controls.RemoveAt(0);

            ((IFiltersBase)this).FormOrigin.Controls.Add(nudPrice);
            ((IFiltersBase)this).FormOrigin.Controls.Add(labelPrice);
            ((IFiltersBase)this).FormOrigin.Controls.Add(labelStock);
            ((IFiltersBase)this).FormOrigin.Controls.Add(nudStock);
            ((IFiltersBase)this).FormOrigin.Controls.Add(CategoryFilterCheckedBoxes);
            ((IFiltersBase)this).FormOrigin.Controls.Add(ButtonUpdateFilters);
            ButtonUpdateFilters.Click += ((IFiltersBase)this).UpdateFilters_Click;

            ((IFiltersBase)this).ProgrammaticallyPlaceFilterControls(null, null);
        }

        void IFiltersBase.ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {
            FormUtils.PlaceControlBottomRightCorner(((IFiltersBase)this).FormOrigin, ButtonUpdateFilters);
            FormUtils.PlaceControlBottomLeftCorner(((IFiltersBase)this).FormOrigin, CategoryFilterCheckedBoxes);
            FormUtils.PlaceControlBottomRightOf(nudStock, CategoryFilterCheckedBoxes);
            FormUtils.PlaceControlBottomRightOf(nudPrice, nudStock);
            FormUtils.PlaceControlOnTopOf(labelStock, nudStock);
            FormUtils.PlaceControlOnTopOf(labelPrice, nudPrice);
        }

        void IFiltersBase.UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnCategoryFilter(ReportForm.InitialList);
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnPriceFilter(ReportForm.ListCurrentlyInUse);
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnStockFilter(ReportForm.ListCurrentlyInUse);


            ((IFiltersBase)this).ReportView.LocalReport.DataSources.Remove(ReportForm.ReportData);
            ReportForm.ReportData = new ReportDataSource("Producto_DataSet", ReportForm.ListCurrentlyInUse);
            ((IFiltersBase)this).ReportView.LocalReport.DataSources.Add(ReportForm.ReportData);
            ((IFiltersBase)this).ReportView.RefreshReport();
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

        /// <summary>
        ///
        /// </summary>
        void IFiltersBase.InitializeComponents()
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
            this.labelPrice.Text = "Precio superior a";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStock.Location = new System.Drawing.Point(129, 3);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(124, 20);
            this.labelStock.TabIndex = 12;
            this.labelStock.Text = "Stock superior a";
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
