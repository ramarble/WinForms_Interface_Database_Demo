using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Data;
using DatabaseInterfaceDemo.Model;

namespace DatabaseInterfaceDemo.View.ObjectCreationForms
{

    public partial class FormCreateEmployee : BaseFormCreateObject
    {
        private FormCreateEmployee() : base()
        {
            InitializeComponent();
        }
        //wtf was I cooking here 
        Empleado objectBeingModified = new Empleado(true, "debug", "debug", "debug", 123.0M, DateTime.Today, 1234556);

        protected override void OnClosed(EventArgs e)
        {
            this.parent.Show();
            base.OnClosed(e);
        }

        /*public FormCreateEmployee(Form sender, object ob, Boolean editMode, ObjectDataBaseController<object> db)
        {
            //UserFormInitialize(sender);
            
             * userReference = ob;
            tbNombre.Text = ob.name;
            tbApe1.Text = ob.surname1;
            tbApe2.Text = ob.surname2;
            numSalary.Text = ob.salary.ToString();
            tbNIF.Text = ob.nif.ToString();
            dtpFechaNacimiento.Value = ob.birthdate;
          
        }
          */

        public FormCreateEmployee(Form sender, bool editMode, ObjectDataBaseController<object> db) : base(sender, editMode, db)
        {
            InitializeComponent();

            InitializePrimaryKeyTextBox(tbNIF);
            LateLoadBaseFormDesign();

        }

        public FormCreateEmployee(Form sender, object ob, bool editMode, ObjectDataBaseController<object> db) : base(sender, ob, editMode, db)
        {
            InitializeComponent();

            InitializePrimaryKeyTextBox(tbNIF);
            LateLoadBaseFormDesign();

        }

        private void SaveUserAsTemp(object sender, EventArgs e)
        {
            int usernif;
            if (Utils.IsAnyTextBoxEmptyInForm(this))
            {
                LocalizationText.WARN_FillAllData();
                this.DialogResult = DialogResult.None; //Why the frick is this how it has to work
                HighlightEmptyTextBoxes();

            }
            else
            {
                usernif = Int32.Parse(tbNIF.Text.ToString().Replace(" ", ""));
                Empleado u = new Empleado(
                    objectBeingModified.GetTempStatus(),
                    tbNombre.Text.ToString(),
                    tbApe1.Text.ToString(),
                    tbApe2.Text.ToString(),
                    decimal.Parse(numSalary.Text.ToString(), NumberStyles.Any),
                    dtpFechaNacimiento.Value,
                    usernif);
                if (u.Equals(objectBeingModified))
                {
                    db.SetTempStatus(u, objectBeingModified.TempStatus);
                    db.GetBackupList().Remove(objectBeingModified);
                }
                else
                {
                    db.SetTempStatus(u, true);
                };
                db.AddObjectToList(db.GetBindingList(), u, editMode);
            }

        }
    }
}
