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
        object objectBeingModified = (Empleado)Activator.CreateInstance(typeof(Empleado));

        public FormCreateEmployee(Form sender, bool editMode, ObjectDataBaseController<object> db) : base(sender, editMode, db)
        {
            InitializeComponent();
            DB.SetTempStatus(objectBeingModified, true);
            InitializePrimaryKeyTextBox(tbNIF);
            LateLoadBaseFormDesign();

        }

        public FormCreateEmployee(Form sender, object ob, bool editMode, ObjectDataBaseController<object> db) : base(sender, ob, editMode, db)
        {
            InitializeComponent();

            InitializePrimaryKeyTextBox(tbNIF);
            objectBeingModified = (Empleado)ob;
            LateLoadBaseFormDesign();
            LoadValuesFromObject(ob);

        }

        private void LoadValuesFromObject(object obj)
        {
            var ob = obj as Empleado;
            tbNombre.Text = ob.Name;
            tbApe1.Text = ob.Surname1;
            tbApe2.Text = ob.Surname2;
            numSalary.Text = ob.Salary.ToString();
            tbNIF.Text = ob.NIF.ToString();
            dtpFechaNacimiento.Value = ob.Birthdate;

        }

        public override void SaveUserAsTemp(object sender, EventArgs e)
        {
            int usernif;
            if (FormUtils.IsAnyTextBoxEmptyInForm(this))
            {
                LocalizationText.WARN_FillAllData();
                this.DialogResult = DialogResult.None; //Why the frick is this how it has to work
                HighlightEmptyTextBoxes();

            }
            else
            {
                usernif = Int32.Parse(tbNIF.Text.ToString().Replace(" ", ""));
                Empleado u = new Empleado(
                    DB.GetTempStatus(objectBeingModified),
                    tbNombre.Text.ToString(),
                    tbApe1.Text.ToString(),
                    tbApe2.Text.ToString(),
                    decimal.Parse(numSalary.Text.ToString(), NumberStyles.Any),
                    dtpFechaNacimiento.Value,
                    usernif);

                if (DB.AddObjectToList(DB.GetBindingList(), u, EditMode))
                {
                    LocalizationText.INFO_ObjectAddedToList();
                    ClearAllTextBoxes(null,null);

                    //These 3 lines of code are holding the weight of the entire program
                    if (EditMode)
                    {
                        DB.SetTempStatus(u, true);
                        this.Close();
                    }
                };
            }

        }
    }
}
