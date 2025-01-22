using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DatabaseInterfaceDemo.View;
using DatabaseInterface.Controller;
using DatabaseInterface.Model;

namespace DatabaseInterface.View
{
    public partial class FormUser : Form
    {
        Form parent;
        Boolean editMode;
        ObjectDataBaseController<object> db;

        //wtf was I cooking here 
        Empleado objectBeingModified = new Empleado(true, "debug", "debug", "debug", 123.0M, DateTime.Today, 1234556);
        private void UserForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            loadListenersForTextBoxes();
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

        public FormUser(Form sender, Boolean editMode, ObjectDataBaseController<object> db)
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

        public FormUser(Form sender, object ob, Boolean editMode, ObjectDataBaseController<object> db)
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

        private void loadListenersForTextBoxes()
        {
            foreach(TextBoxBase t in Utils.listOfTextBoxesInForm(this))
            {
                t.ContextMenuStrip = contextMenuStrip1;
                t.Enter += resetColorToDefault;
            }
        }

        private void resetColorToDefault(object sender, EventArgs e)
        {
            (sender as TextBoxBase).BackColor = System.Drawing.Color.White;
        }

        private void highlightEmptyTextBoxes()
        {
            foreach (TextBoxBase t in Utils.listOfTextBoxesInForm(this))
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
                highlightEmptyTextBoxes();

            } else
            {
                usernif = Int32.Parse(tbNIF.Text.ToString().Replace(" ", ""));
                Empleado u = new Empleado(
                    objectBeingModified.getTempStatus(), 
                    tbNombre.Text.ToString(),
                    tbApe1.Text.ToString(),
                    tbApe2.Text.ToString(),
                    decimal.Parse(numSalary.Text.ToString(), NumberStyles.Any),
                    dtpFechaNacimiento.Value,
                    usernif);
                if (u.Equals(objectBeingModified))
                {
                    db.setTempStatus(u,objectBeingModified.tempStatus);
                    db.getBackupList().Remove(objectBeingModified);
                }
                else
                {
                    db.setTempStatus(u, true);
                };
                db.addObjectToList(db.getBindingList(), u, editMode);
            }

        }

        private void UserAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parent.Show();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (TextBoxBase t in Utils.listOfTextBoxesInForm(this))
            {

                if (!t.ReadOnly)
                {
                    t.Text = "";
                }

            }
            this.DialogResult = DialogResult.None;

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (LocalizationText.ExitWithoutSaving() == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void numSalary_Enter(object sender, EventArgs e)
        {
            if (numSalary.Text.ToString() != "")
            {
                numSalary.Select(0, numSalary.Text.Length);
            }
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.cutText(Utils.TextBoxBaseFromControl(this.ActiveControl));
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.TextBoxBaseFromControl(this.ActiveControl).Paste();
        }

        private void onClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void cortarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utils.cutText(Utils.TextBoxBaseFromControl(this.ActiveControl));
        }

        private void pegarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utils.TextBoxBaseFromControl(this.ActiveControl).Paste();

        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.TextBoxBaseFromControl(this.ActiveControl).Copy();
        }

        private void copiarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Utils.TextBoxBaseFromControl(this.ActiveControl).Copy();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form acercaDe = new AcercaDe();
            acercaDe.ShowDialog();
        }
    }
}
