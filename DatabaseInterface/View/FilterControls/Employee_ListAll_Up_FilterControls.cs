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
    public class Employee_ListAll_Down_FilterControls : IFiltersBase
    {

        private NumericUpDown nudDaysWorked;
        private Label labelDaysWorked;
        private Label labelSalary;
        private NumericUpDown nudSalary;
        private Button ButtonUpdateFilters;

        public List<Control> Controls { get; set; }

        public ReportForm FormOrigin { get; set; }
        public ReportViewer ReportView { get; set; }

        public Employee_ListAll_Down_FilterControls(ReportForm form, ReportViewer reportViewer)
        {
            InitializeComponents();

            FormOrigin = form;
            ReportView = reportViewer;

            nudSalary.Controls.RemoveAt(0);
            nudDaysWorked.Controls.RemoveAt(0);

            Controls = AddControlsToList();
            AddControlsToForm(Controls);

            ButtonUpdateFilters.Click += UpdateFilters_Click;

            ProgrammaticallyPlaceFilterControls(null, null);
        }

        public List<Control> AddControlsToList()
        {
            List<Control> controls = new List<Control>();

            controls.Add(nudDaysWorked);
            controls.Add(labelDaysWorked);
            controls.Add(labelSalary);
            controls.Add(nudSalary);
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
            FormUtils.PlaceControlBottomLeftCorner(FormOrigin, nudSalary);
            FormUtils.PlaceControlBottomRightOf(nudDaysWorked, nudSalary);
            FormUtils.PlaceControlOnTopOf(labelSalary, nudSalary);
            FormUtils.PlaceControlOnTopOf(labelDaysWorked, nudDaysWorked);
        }

        public void UpdateFilters_Click(object sender, EventArgs e)
        {

            ReportForm.ListCurrentlyInUse = UpdateListBasedOnDaysWorkedFilter(ReportForm.ListCurrentlyInUse);
            ReportForm.ListCurrentlyInUse = UpdateListBasedOnSalaryFilter(ReportForm.ListCurrentlyInUse);


            ReportView.LocalReport.DataSources.Remove(ReportForm.ReportData);
            ReportForm.ReportData = new ReportDataSource("Empleado_DataSet", ReportForm.ListCurrentlyInUse);
            ReportView.LocalReport.DataSources.Add(ReportForm.ReportData);
            ReportView.RefreshReport();
        }

        private BindingList<object> UpdateListBasedOnSalaryFilter(BindingList<object> listWorkedOn)
        {
            if (nudSalary.Value > 0)
            {
                List<object> slice = new List<object>();
                slice.AddRange(listWorkedOn.Where(it => (it as Empleado).Salary < nudSalary.Value));

                return new BindingList<object>(slice);
            }
            else return listWorkedOn;
        }

        private BindingList<object> UpdateListBasedOnDaysWorkedFilter(BindingList<object> listWorkedOn)
        {
            if (nudDaysWorked.Value > 0)
            {
                List<object> slice = new List<object>();
                slice.AddRange(listWorkedOn.Where(it => (it as Empleado).DaysWorked < nudDaysWorked.Value));

                return new BindingList<object>(slice);
            }
            else return listWorkedOn;
        }

        /// <summary>
        ///
        /// </summary>
        public void InitializeComponents()
        {

            this.nudDaysWorked = new NumericUpDown();
            this.labelDaysWorked = new Label();
            this.labelSalary = new Label();
            this.nudSalary = new NumericUpDown();
            ((ISupportInitialize)(this.nudDaysWorked)).BeginInit();
            ((ISupportInitialize)(this.nudSalary)).BeginInit();

            // 
            // nudDaysWorked
            // 
            this.nudDaysWorked.DecimalPlaces = 0;
            this.nudDaysWorked.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDaysWorked.Location = new System.Drawing.Point(281, 27);
            this.nudDaysWorked.Name = "nudDaysWorked";
            this.nudDaysWorked.Size = new System.Drawing.Size(124, 26);
            this.nudDaysWorked.TabIndex = 14;
            // 
            // labelDaysWorked
            // 
            this.labelDaysWorked.AutoSize = true;
            this.labelDaysWorked.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDaysWorked.Location = new System.Drawing.Point(278, 3);
            this.labelDaysWorked.Name = "labelDaysWorked";
            this.labelDaysWorked.Size = new System.Drawing.Size(127, 20);
            this.labelDaysWorked.TabIndex = 13;
            this.labelDaysWorked.Text = "Días trabajados menos que";
            // 
            // labelSalary
            // 
            this.labelSalary.AutoSize = true;
            this.labelSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSalary.Location = new System.Drawing.Point(129, 3);
            this.labelSalary.Name = "labelSalary";
            this.labelSalary.Size = new System.Drawing.Size(124, 20);
            this.labelSalary.TabIndex = 12;
            this.labelSalary.Text = "Salario inferior a";
            // 
            // nudSalary
            // 
            this.nudSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSalary.Location = new System.Drawing.Point(129, 27);
            this.nudSalary.Name = "nudSalary";
            this.nudSalary.Size = new System.Drawing.Size(124, 26);
            this.nudSalary.TabIndex = 11;
            this.nudSalary.Maximum = 5000;
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

            ((ISupportInitialize)(this.nudDaysWorked)).EndInit();
            ((ISupportInitialize)(this.nudSalary)).EndInit();
        }

    }
}
