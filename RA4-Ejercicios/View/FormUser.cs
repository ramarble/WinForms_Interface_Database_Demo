using RA4_Ejercicios.Controller;
using U_DB_C = RA4_Ejercicios.Controller.UserDatabaseController;
using SUEC = RA4_Ejercicios.Controller.SendUserEventController;
using RA4_Ejercicios.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA4_Ejercicios.View
{
    public partial class FormUser : Form
    {
        Form parent;
        Boolean editMode;

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
            tbNombre.Text = u.name;
            tbApe1.Text = u.surname1;
            tbApe2.Text = u.surname2;
            numSalary.Text = u.salary.ToString();
            tbNIF.Text = u.nif.ToString();
            dateTimePicker1.Value = u.birthdate;

        }

        private List<TextBoxBase> listOfTextBoxesInForm(Form sender)
        {
            List<TextBoxBase> ListOfTextBoxBases = new List<TextBoxBase>();
            foreach (Object o in sender.Controls)
            {
                if (o is TextBoxBase)
                {
                    ListOfTextBoxBases.Add((o as TextBoxBase));
                }
                if (o is NumericUpDown)
                {
                    ListOfTextBoxBases.Add((getTextBoxFromNumericUpDown(o as NumericUpDown));
                }
            }
            return ListOfTextBoxBases;
        }

        private Boolean isAnyTextBoxEmptyInForm(Form sender)
        {
            return listOfTextBoxesInForm(sender).Any(x => x.Text.ToString() == "");
        }

        private void SaveUserAsTemp(object sender, EventArgs e)
        {
            if (isAnyTextBoxEmptyInForm(this))
            {
                MessageBox.Show("Por favor rellena todos los campos");
                DialogResult = DialogResult.None;

            } else if (U_DB_C.isNIFPresentInList(U_DB_C.getUserList(), Int32.Parse(tbNIF.Text.ToString()))){
                MessageBox.Show("Ya hay un usuario con ese NIF presente.");
                DialogResult = DialogResult.None;
            } else 
            {
                SUEC.UserSavedTrigger(this, new EventSendUser(
                    true,
                    tbNombre.Text.ToString(),
                    tbApe1.Text.ToString(),
                    tbApe2.Text.ToString(),
                    decimal.Parse(numSalary.Text.ToString(),NumberStyles.Any),
                    dateTimePicker1.Value,
                    Int32.Parse(tbNIF.Text.ToString()), editMode));

            }
        }

        private void UserAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.parent.Show();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (TextBoxBase t in listOfTextBoxesInForm(this))
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
            this.Close();
        }

        private void numSalary_Enter(object sender, EventArgs e)
        {
            if (numSalary.Text.ToString() != "" )
            {
                numSalary.Select(0, numSalary.Text.Length);
            }
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl is TextBoxBase)
            {
                cutText(this.ActiveControl as TextBoxBase);

            } else if (this.ActiveControl is NumericUpDown)
            {
                cutText(getTextBoxFromNumericUpDown(this.ActiveControl as NumericUpDown));
            }
        }
        private void cutText(TextBoxBase tbb)
        {
            if (tbb.SelectedText != "")
            {
                tbb.Cut();
            }
        }

        private TextBox getTextBoxFromNumericUpDown(NumericUpDown nud)
        {
            return nud.Controls.OfType<TextBox>().FirstOrDefault() as TextBox;
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveControl is TextBoxBase)
            {
                TextBoxBase c = this.ActiveControl as TextBoxBase;
                c.Paste();
            } else if (this.ActiveControl is NumericUpDown)
            {
                getTextBoxFromNumericUpDown(this.ActiveControl as NumericUpDown).Paste();
            }
        }
    }
}
