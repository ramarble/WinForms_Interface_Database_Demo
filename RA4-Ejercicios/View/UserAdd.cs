using RA4_Ejercicios.Controller;
using RA4_Ejercicios.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA4_Ejercicios.View
{
    public partial class UserAdd : Form
    {
        Form sender;
        public UserAdd(Form sender)
        {
            this.sender = sender;
            this.KeyPreview = true;
            InitializeComponent();
        }

        private List<TextBox> listOfTextBoxesInForm(Form sender)
        {
            List<TextBox> ListOfTextInTextBoxes = new List<TextBox>();
            foreach (Object o in sender.Controls)
            {
                if (o is TextBox)
                {
                    ListOfTextInTextBoxes.Add((o as TextBox));
                }
            }
            return ListOfTextInTextBoxes;
        }

        private Boolean isAnyTextBoxEmptyInForm(Form sender)
        {
            return listOfTextBoxesInForm(sender).Any(x => x.Text.ToString() == "");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (isAnyTextBoxEmptyInForm(this))
            {
                MessageBox.Show("Por favor rellena todos los campos");
                /*
                    STUPID ASS WORKAROUND BECAUSE ACCEPTING THE MESSAGEBOX
                    SETS DIALOGRESULT GLOBALLY TO OK
                    CASCADING CLOSE EVERYTHING BELOW IT
                */
                DialogResult = DialogResult.None;
            }   else
            {
                SendUserEventController.UserSavedTrigger(this, new EventSendUser(
                    tbNombre.Text.ToString(),
                    tbApe1.Text.ToString(),
                    tbApe2.Text.ToString(),
                    dateTimePicker1.Value,
                    Int32.Parse(tbNIF.Text.ToString())));
            }
        }

        private void UserAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Unnecessary in the current implementation
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
