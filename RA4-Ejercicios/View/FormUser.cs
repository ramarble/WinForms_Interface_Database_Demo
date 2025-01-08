using RA4_Ejercicios.Controller;
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
            List<TextBoxBase> ListOfTextInTextBoxes = new List<TextBoxBase>();
            foreach (Object o in sender.Controls)
            {
                if (o is TextBoxBase)
                {
                    ListOfTextInTextBoxes.Add((o as TextBoxBase));
                }
            }
            return ListOfTextInTextBoxes;
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

            }   else
            {
                SendUserEventController.UserSavedTrigger(this, new EventSendUser(
                    true,
                    tbNombre.Text.ToString(),
                    tbApe1.Text.ToString(),
                    tbApe2.Text.ToString(),
                    decimal.Parse(numSalary.Text.ToString(),NumberStyles.Any),
                    dateTimePicker1.Value,
                    Int32.Parse(tbNIF.Text.ToString()), editMode));

                this.Close();
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
    }
}
