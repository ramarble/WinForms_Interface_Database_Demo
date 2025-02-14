﻿using System;
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
    /// Set of Filters for Employee data above a user defined threshold
    /// </summary>
    public class Employee_ListAll_Up_FilterControls : FiltersBase
    {

        private NumericUpDown nudDaysWorked = new NumericUpDown();
        private Label labelDaysWorked = new Label();
        private Label labelSalary = new Label();
        private NumericUpDown nudSalary = new NumericUpDown();

        /// <summary>
        /// Set of Filters for Employee data above a user defined threshold
        /// </summary>
        public Employee_ListAll_Up_FilterControls(ReportForm form, ReportViewer reportViewer, string dataSourceType): 
            base(form, reportViewer, dataSourceType)
        {
            Initialize(nudDaysWorked, labelDaysWorked, labelSalary, nudSalary);
            nudSalary.Controls.RemoveAt(0);
            nudDaysWorked.Controls.RemoveAt(0);
        }

        /// <inheritdoc/>
        public override void ProgrammaticallyPlaceFilterControls(object sender, EventArgs e)
        {
            base.ProgrammaticallyPlaceFilterControls(sender, e);
            CustomDesigner.PlaceControlBottomLeftCorner(FormOrigin, nudSalary);
            CustomDesigner.PlaceControlBottomRightOf(nudDaysWorked, nudSalary);
            CustomDesigner.PlaceControlOnTopOf(labelSalary, nudSalary);
            CustomDesigner.PlaceControlOnTopOf(labelDaysWorked, nudDaysWorked);
        }

        /// <inheritdoc/>
        public override void UpdateFilters_Click(object sender, EventArgs e)
        {
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnDaysWorkedFilter(ReportForm.InitialList);
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnSalaryFilter(ReportForm.ListCurrentlyInUse);
            base.UpdateFilters_Click(sender, e);
        }

        private BindingList<object> UpdateListBasedOnSalaryFilter(BindingList<object> listWorkedOn)
        {
            if (nudSalary.Value > 0)
            {
                List<object> slice = new List<object>();
                slice.AddRange(listWorkedOn.Where(it => (it as Empleado).Salary > nudSalary.Value));

                return new BindingList<object>(slice);
            }
            else return listWorkedOn;
        }

        private BindingList<object> UpdateListBasedOnDaysWorkedFilter(BindingList<object> listWorkedOn)
        {
            if (nudDaysWorked.Value > 0)
            {
                List<object> slice = new List<object>();
                slice.AddRange(listWorkedOn.Where(it => (it as Empleado).DaysWorked > nudDaysWorked.Value));

                return new BindingList<object>(slice);
            }
            else return listWorkedOn;
        }

        ///<inheritdoc/>
        public override void StyleControls()
        {
            base.StyleControls();
            ((ISupportInitialize)(this.nudDaysWorked)).BeginInit();
            ((ISupportInitialize)(this.nudSalary)).BeginInit();

            // 
            // nudDaysWorked
            // 
            nudDaysWorked.DecimalPlaces = 0;
            nudDaysWorked.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nudDaysWorked.Size = new System.Drawing.Size(124, 26);
            nudDaysWorked.Maximum = 10000;
            // 
            // labelDaysWorked
            // 
            labelDaysWorked.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelDaysWorked.Size = new System.Drawing.Size(127, 20);
            labelDaysWorked.Text = "Días trabajados más que";
            // 
            // labelSalary
            // 
            labelSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelSalary.Size = new System.Drawing.Size(124, 20);
            labelSalary.Text = "Salario superior a";
            // 
            // nudSalary
            // 
            nudSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nudSalary.Size = new System.Drawing.Size(124, 26);
            nudSalary.Maximum = 5000;


            ((ISupportInitialize)(nudDaysWorked)).EndInit();
            ((ISupportInitialize)(nudSalary)).EndInit();
        }

    }
}
