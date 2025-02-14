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
    /// <summary>
    /// Set of Filters for Product data below a user defined threshold
    /// </summary>
    public class Product_ListAll_Up_FilterControls : FiltersBase
    {

        private readonly NumericUpDown nudPrice = new NumericUpDown();
        private readonly Label labelPrice = new Label();
        private readonly Label labelStock = new Label();
        private readonly NumericUpDown nudStock = new NumericUpDown();
        private readonly CheckedListBox CategoryFilterCheckedBoxes = new CheckedListBox();

        /// <summary>
        /// Set of Filters for Product data below a user defined threshold
        /// </summary>
        public Product_ListAll_Up_FilterControls(ReportForm form, ReportViewer reportView, string dataSourceName) : base(form, reportView, dataSourceName)
        {
            Initialize(nudPrice, labelPrice, labelStock, nudStock, CategoryFilterCheckedBoxes);
            CategoryFilterCheckedBoxes.Items.AddRange(Enum.GetNames(typeof(Category)));
            nudStock.Controls.RemoveAt(0);
            nudPrice.Controls.RemoveAt(0);

        }

        /// <inheritdoc/>
        public override void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {
            base.ProgrammaticallyPlaceFilterControls(sender, e);
            CustomDesigner.PlaceControlBottomLeftCorner(FormOrigin, CategoryFilterCheckedBoxes);
            CustomDesigner.PlaceControlBottomRightOf(nudStock, CategoryFilterCheckedBoxes);
            CustomDesigner.PlaceControlBottomRightOf(nudPrice, nudStock);
            CustomDesigner.PlaceControlOnTopOf(labelStock, nudStock);
            CustomDesigner.PlaceControlOnTopOf(labelPrice, nudPrice);
        }

        /// <inheritdoc/>
        public override void UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnCategoryFilter(ReportForm.InitialList);
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnPriceFilter(ReportForm.ListCurrentlyInUse);
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnStockFilter(ReportForm.ListCurrentlyInUse);
            base.UpdateFilters_Click(sender, e);
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
                slice.AddRange(listWorkedOn.Where(it => (it as Producto).PricePerUnit > nudPrice.Value));

                return new BindingList<object>(slice);
            }
            else return listWorkedOn;
        }

        /// <inheritdoc/>
        public override void StyleControls()
        {

            ((ISupportInitialize)(nudPrice)).BeginInit();
            ((ISupportInitialize)(nudStock)).BeginInit();

            nudPrice.DecimalPlaces = 2;
            nudPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nudPrice.Size = new System.Drawing.Size(124, 26);

            labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPrice.Size = new System.Drawing.Size(127, 20);
            labelPrice.Text = "Precio superior a";

            labelStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelStock.Size = new System.Drawing.Size(124, 20);
            labelStock.Text = "Stock superior a";

            nudStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nudStock.Size = new System.Drawing.Size(124, 26);

            CategoryFilterCheckedBoxes.FormattingEnabled = true;
            CategoryFilterCheckedBoxes.Size = new System.Drawing.Size(120, 49);

            ((ISupportInitialize)(nudPrice)).EndInit();
            ((ISupportInitialize)(nudStock)).EndInit();
        }

    }
}
