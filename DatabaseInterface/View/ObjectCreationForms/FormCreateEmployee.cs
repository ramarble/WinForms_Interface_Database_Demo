using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using DatabaseInterfaceDemo.Controller;
using DatabaseInterfaceDemo.Data;
using DatabaseInterfaceDemo.Model;

namespace DatabaseInterfaceDemo.View.ObjectCreationForms
{

    public partial class FormCreateEmployee : Form
    {
        static readonly Dictionary<string, string> LOC_STRINGS = LocalizationText.localizedStrings;

        Form parent;
        Boolean editMode;
        ObjectDataBaseController<object> db;

        //wtf was I cooking here 
        Empleado objectBeingModified = new Empleado(true, "debug", "debug", "debug", 123.0M, DateTime.Today, 1234556);
        private void UserForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            LoadListenersForTextBoxes();
            //For edit mode you're editing an existing user, and can't change its primary key
            if (editMode)
            {
                tbNIF.ReadOnly = true;
            }
            else
            {
                tbNIF.ReadOnly = false;
            }
        }

        public FormCreateEmployee(Form sender, Boolean editMode, ObjectDataBaseController<object> db)
        {

            this.parent = sender;
            this.db = db;
            //Constructor used by ADD NEW mode
            this.editMode = editMode;
            InitializeComponent();
            //UserFormInitialize(sender);
        }

        protected override void OnClosed(EventArgs e)
        {
            this.parent.Show();
            base.OnClosed(e);
        }

        public FormCreateEmployee(Form sender, object ob, Boolean editMode, ObjectDataBaseController<object> db)
        {
            this.parent = sender;
            this.db = db;
            //Constructor used by Edit mode
            this.Text = "Modifica un usuario";
            this.editMode = editMode;
            InitializeComponent();
            //UserFormInitialize(sender);
            /*
             * userReference = ob;
            tbNombre.Text = ob.name;
            tbApe1.Text = ob.surname1;
            tbApe2.Text = ob.surname2;
            numSalary.Text = ob.salary.ToString();
            tbNIF.Text = ob.nif.ToString();
            dtpFechaNacimiento.Value = ob.birthdate;
            */
        }

        private void LoadListenersForTextBoxes()
        {
            foreach (TextBoxBase t in Utils.ListOfTextBoxesInForm(this))
            {
                t.ContextMenuStrip = contextMenuStrip1;
                t.Enter += ResetColorToDefault;
            }
        }

        private void ResetColorToDefault(object sender, EventArgs e)
        {
            (sender as TextBoxBase).BackColor = System.Drawing.Color.White;
        }

        private void HighlightEmptyTextBoxes()
        {
            foreach (TextBoxBase t in Utils.ListOfTextBoxesInForm(this))
            {
                if (String.IsNullOrWhiteSpace(t.Text.ToString()))
                {
                    t.BackColor = System.Drawing.Color.Beige;
                }
            }
        }

        private void SaveUserAsTemp(object sender, EventArgs e)
        {
            int usernif;
            if (Utils.isAnyTextBoxEmptyInForm(this))
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

        private void UserAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parent.Show();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            foreach (TextBoxBase t in Utils.ListOfTextBoxesInForm(this))
            {

                if (!t.ReadOnly)
                {
                    t.Text = "";
                }

            }
            this.DialogResult = DialogResult.None;

        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (LocalizationText.WARN_ExitWithoutSaving() == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void NumSalary_Enter(object sender, EventArgs e)
        {
            if (numSalary.Text.ToString() != "")
            {
                numSalary.Select(0, numSalary.Text.Length);
            }
        }

        private void CortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.CutText(Utils.TextBoxBaseFromControl(this.ActiveControl));
        }

        private void PegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.TextBoxBaseFromControl(this.ActiveControl).Paste();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void CortarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utils.CutText(Utils.TextBoxBaseFromControl(this.ActiveControl));
        }

        private void PegarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utils.TextBoxBaseFromControl(this.ActiveControl).Paste();

        }

        private void CopiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.TextBoxBaseFromControl(this.ActiveControl).Copy();
        }

        private void CopiarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utils.TextBoxBaseFromControl(this.ActiveControl).Copy();
        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form acercaDe = new AcercaDe();
            acercaDe.ShowDialog();
        }
    }
}
