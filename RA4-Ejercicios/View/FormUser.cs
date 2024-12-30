using RA4_Ejercicios.Controller;
using RA4_Ejercicios.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA4_Ejercicios.View
{
    public partial class FormUser : Form
    {
        Form sender;
        Boolean editMode;

        private void UserForm_Load(object sender, EventArgs e)
        {
            this.sender = (Form) sender;
            this.KeyPreview = true;
            this.sender.Visible = false;

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
            //Constructor used by ADD NEW mode
            this.editMode = editMode;
            InitializeComponent();
            //UserFormInitialize(sender);
        }

        protected override void OnClosed(EventArgs e)
        {
            this.sender.Visible = true;
            base.OnClosed(e);
        }

        public FormUser(Form sender, User u, Boolean editMode)
        {
            //Constructor used by Edit mode
            this.Text = "Modifica un usuario";
            this.editMode = editMode;
            InitializeComponent();
            //UserFormInitialize(sender);
            tbNombre.Text = u.name;
            tbApe1.Text = u.surname1;
            tbApe2.Text = u.surname2;
            tbAltura.Text = u.height.ToString();
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
                /*
                 * idk :standing_man:
                 */
                MessageBox.Show("Por favor rellena todos los campos");
                DialogResult = DialogResult.None;

            }   else
            {
                SendUserEventController.UserSavedTrigger(this, new EventSendUser(
                    true,
                    tbNombre.Text.ToString(),
                    tbApe1.Text.ToString(),
                    tbApe2.Text.ToString(),
                    float.Parse(tbAltura.Text.ToString()),
                    dateTimePicker1.Value,
                    Int32.Parse(tbNIF.Text.ToString()), editMode));

                this.Close();
            }
        }

        private void UserAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.sender.Show();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (TextBox t in listOfTextBoxesInForm(this))
            {
                t.Text = "";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
