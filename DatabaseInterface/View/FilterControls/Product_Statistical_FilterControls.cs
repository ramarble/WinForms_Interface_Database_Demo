// Ignore Spelling: Programmatically

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Model;
using Microsoft.Reporting.WinForms;

namespace DatabaseInterfaceDemo.View.FilterControls
{

    /// <summary>
    /// Set of Filters for Product data that show total grouped statistics
    /// </summary>
    public class Product_Statistical_FilterControls : FiltersBase
    {
        private CheckedListBox CategoryFilterCheckedBoxes = new CheckedListBox();


        /// <summary>
        /// Set of Filters for Product data that show total grouped statistics
        /// </summary>
        public Product_Statistical_FilterControls(ReportForm form, ReportViewer reportViewer, string dataSourceType) : base(form, reportViewer, dataSourceType) 
        {
            Initialize(CategoryFilterCheckedBoxes);
            CategoryFilterCheckedBoxes.Items.AddRange(Enum.GetNames(typeof(Category)));
        }

        /// <inheritdoc/>
        public override void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {
            base.ProgrammaticallyPlaceFilterControls(sender, e);
            CustomDesigner.PlaceControlBottomLeftCorner(FormOrigin, CategoryFilterCheckedBoxes);
        }

        /// <inheritdoc/>
        public override void UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnCategoryFilter(ReportForm.InitialList);
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
        public override void StyleControls()
        {
            CategoryFilterCheckedBoxes.FormattingEnabled = true;
            CategoryFilterCheckedBoxes.Size = new System.Drawing.Size(120, 49);
        }
    }
}
