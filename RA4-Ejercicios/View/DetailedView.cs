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
using U_DB_C = RA4_Ejercicios.Controller.UserDatabaseController;
using SUEC = RA4_Ejercicios.Controller.SendUserEventController;
using System.IO;

namespace RA4_Ejercicios.View
{
    public partial class DetailedView : Form
    {
        List<User> tempEditedUsers = new List<User>();
        BindingList<User> userList;

        Form owner;
        public DetailedView(BindingList<User> userList, Form sender) 
        {
            InitializeComponent();
            this.userList = userList;
            listBox1.DataSource = this.userList;
            listBox1.ValueMember = "NIF";
            listBox1.DisplayMember = "Name";
            listBox1.SelectedValueChanged += UpdateObjectView;
            listBox1.SelectedItem = listBox1.Items[1];
            listBox1.SelectionMode = SelectionMode.One;
            this.owner = sender;
            sender.Visible = false;
            buttonRevert.Enabled = false;
            buttonSave.Enabled = false;
        }

        protected override void OnClosed(EventArgs e)
        {
            owner.Visible = true;
            SUEC.UserSaved += userSent;
            base.OnClosed(e);
        }

        private void userSent(object sender, EventSendUser e)
        {
            U_DB_C.addUser(U_DB_C.getUserList(), e.getUsuario(), e.getEditMode());
        }

        private void UpdateObjectView(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = listBox1.SelectedItem;
            User u = propertyGrid1.SelectedObject as User;
            if (u.getTempStatus())
            {
                buttonRevert.Enabled = true;
            } else
            {
                buttonRevert.Enabled = false;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            List<User> lista = this.userList.Where(user => user.nif.ToString().Contains(textBox1.Text)).ToList();

            if (textBox1.Text != "")
            {
                lista.AddRange(
                this.userList.Where(
                    user => user.name.ToLower().Contains(textBox1.Text.ToLower())
                    )
                );
            }
            listBox1.DataSource = lista;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            User userToEdit = (User)propertyGrid1.SelectedObject;
            tempEditedUsers.Add(userToEdit);
            this.userList.Remove(userToEdit);
            UserForm f = new UserForm(this, userToEdit, true);
            f.ShowDialog();

            //In case the form exited abruptly
            if (!userList.Any(u => u.nif == userToEdit.nif))
            {
                this.userList.Add(userToEdit);
            }
        }
        private void removeOld(object sender, AddingNewEventArgs e)
        {
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            User userEdited = (User)propertyGrid1.SelectedObject;
            this.userList.Add(tempEditedUsers.Find(u => u.nif == userEdited.nif));
            tempEditedUsers.Remove(userEdited);
            this.userList.Remove(userEdited);
        }
    }
}
