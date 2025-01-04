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
    public partial class FormBuscarUser : Form
    {
        //tempEditedUsers will store the users that
        //have been edited in the case they need to be fetched back
        List<User> tempEditedUsers = new List<User>();
        BindingList<User> userList;

        Form owner;
        public FormBuscarUser(BindingList<User> userList, Form sender) 
        {
            InitializeComponent();
            this.userList = userList;
            this.owner = sender;
            sender.Visible = false;
        }

        private void FormBuscarUser_Load(object sender, EventArgs e)
        {
            userListBox.DataSource = this.userList;
            userListBox.ValueMember = "NIF";
            userListBox.DisplayMember = "Name";
            userListBox.SelectedValueChanged += UpdateObjectView;
            userListBox.SelectedItem = userListBox.Items[0];
            userListBox.SelectionMode = SelectionMode.One;
            buttonRevert.Enabled = false;
            buttonSave.Enabled = false;
            userPropertyGrid.PropertySort = PropertySort.NoSort;
            userPropertyGrid.Enabled = false;
            tooltipTextBox.SetToolTip(this.filterFindUserTextBox, "Puedes encontrar un usuario por su NIF o nombre. (también lo he puesto aquí.))");
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


        //This updates the buttons whenever you change the object being viewed
        //So if a user is temp it can be reverted
        private void UpdateObjectView(object sender, EventArgs e)
        {
            userPropertyGrid.SelectedObject = userListBox.SelectedItem;
            if (userPropertyGrid.SelectedObject == null)
            {
                return;
            }
            User u = userPropertyGrid.SelectedObject as User;
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
            List<User> lista = this.userList.Where(user => user.nif.ToString().Contains(filterFindUserTextBox.Text)).ToList();

            if (filterFindUserTextBox.Text != "")
            {
                lista.AddRange(
                this.userList.Where(
                    user => user.name.ToLower().Contains(filterFindUserTextBox.Text.ToLower())
                    )
                );
            }
            userListBox.DataSource = lista;
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            User userToEdit = (User)userPropertyGrid.SelectedObject;
            tempEditedUsers.Add(userToEdit);
            this.userList.Remove(userToEdit);
            FormUser f = new FormUser(this, userToEdit, true);
            f.ShowDialog();

            //In case the form exited abruptly
            if (!userList.Any(u => u.nif == userToEdit.nif))
            {
                this.userList.Add(userToEdit);
            }
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            User userEdited = (User)userPropertyGrid.SelectedObject;
            this.userList.Add(tempEditedUsers.Find(u => u.nif == userEdited.nif));
            tempEditedUsers.Remove(userEdited);
            this.userList.Remove(userEdited);
            userListBox.ClearSelected();
        }


    }
}
