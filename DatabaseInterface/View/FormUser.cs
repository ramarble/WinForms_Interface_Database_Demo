using System;
using System.Globalization;
using System.Windows.Forms;
using RA4_Ejercicios.Controller;
using RA4_Ejercicios.Model;
using SUEC = RA4_Ejercicios.Controller.SendUserEventController;
using U_DB_C = RA4_Ejercicios.Controller.UserDatabaseController;

namespace RA4_Ejercicios.View
{
    public partial class FormUser : Form
    {
        Form parent;
        Boolean editMode;
        User userReference = new User(true, "debug", "debug", "debug", 123.0M, DateTime.Today, 1234556);

        private void UserForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

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
        public FormUser(Form sender, Boolean editMode)
        {

            this.parent = sender;
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

        public FormUser(Form sender, User u, Boolean editMode)
        {
            this.parent = sender;
            //Constructor used by Edit mode
            this.Text = "Modifica un usuario";
            this.editMode = editMode;
            InitializeComponent();
            //UserFormInitialize(sender);
            userReference = u;
            tbNombre.Text = u.name;
            tbApe1.Text = u.surname1;
            tbApe2.Text = u.surname2;
            numSalary.Text = u.salary.ToString();
            tbNIF.Text = u.nif.ToString();
            dtpFechaNacimiento.Value = u.birthdate;

        }

        private void SaveUserAsTemp(object sender, EventArgs e)
        {
            int usernif;
            if (Utils.isAnyTextBoxEmptyInForm(this))
            {
                MessageBox.Show("Por favor rellena todos los campos");
                DialogResult = DialogResult.None;

            }
            else if (U_DB_C.isNIFPresentInList(U_DB_C.getUserList(), usernif = Int32.Parse(tbNIF.Text.ToString().Replace(" ", ""))))
            {
                MessageBox.Show("Ya hay un usuario con ese NIF presente.");
                DialogResult = DialogResult.None;
            }
            else
            {
                User u = new User(userReference.getTempStatus(), tbNombre.Text.ToString(),
                    tbApe1.Text.ToString(),
                    tbApe2.Text.ToString(),
                    decimal.Parse(numSalary.Text.ToString(), NumberStyles.Any),
                    dtpFechaNacimiento.Value,
                    usernif);
                if (u.Equals(userReference))
                {
                    u.setTempStatus(false);
                    U_DB_C.getUsersBackupList().Remove(userReference);
                }
                else
                {
                    u.setTempStatus(true);
                };
                SUEC.UserSavedTrigger(this, new EventSendUser(
                    u, editMode));

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
            if (DialogBoxes.ExitWithoutSaving() == DialogResult.Yes)
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
    }
}
