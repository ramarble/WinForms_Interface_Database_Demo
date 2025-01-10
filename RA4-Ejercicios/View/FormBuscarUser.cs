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
            userListBox.ValueMember = "";
            userListBox.DisplayMember = "Name";
            userListBox.SelectedValueChanged += UpdateObjectView;
            
            if (this.userList.Count > 0)
            {
                userListBox.SetSelected(0, true);
            } else
            {
                buttonModify.Enabled = false;
            }

            userListBox.SelectionMode = SelectionMode.One;
            userListBox.DataSourceChanged += DataUpdated;
            buttonRevert.Enabled = false;
            buttonSave.Enabled = false;
            userPropertyGrid.PropertySort = PropertySort.NoSort;
            userPropertyGrid.Enabled = false;
            tooltipTextBox.SetToolTip(this.filterFindUserTextBox, "Puedes encontrar un usuario por su NIF o nombre. (también lo he puesto aquí.))");
        }

        private void DataUpdated(object sender, EventArgs e) 
        {
            //MessageBox.Show("hi! :D");
        }

        protected override void OnClosed(EventArgs e)
        {
            owner.Visible = true;
            //idk??
            //SUEC.UserSaved += userSent;
            base.OnClosed(e);
        }

        //idk????
        private void userSent(object sender, EventSendUser e)
        {
            U_DB_C.addUserToList(U_DB_C.getUserList(), e.getUsuario(), e.getEditMode());
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
                buttonSave.Enabled = true;
            } else
            {
                buttonRevert.Enabled = false;
                buttonSave.Enabled = false;
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
            int nifKey = userToEdit.nif;
            U_DB_C.modifyUser(userToEdit, this.userList, this);
            //Sets the pointer correctly
            UpdateListBoxPointerByNIF(nifKey);

        }

        private void UpdateListBoxPointerByNIF(int nifKey)
        {
            this.userListBox.SetSelected(userList.IndexOf(userList.Single(user => user.nif == nifKey)), true);
        }


        private void buttonRevert_Click(object sender, EventArgs e)
        {
            User userWithTempFlag = (User)userPropertyGrid.SelectedObject;
            U_DB_C.revertSingleUser(userWithTempFlag, this.userList);
            this.userListBox.SetSelected(userList.IndexOf(userList.First(it => it.nif == userWithTempFlag.nif)), true);
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (U_DB_C.getUsersBackupList().Count > 0)
            {
                MessageBox.Show("Por favor confirma o revierte todos los cambios antes de salir");
                e.Cancel = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            User userWithTempFlag = (User)userPropertyGrid.SelectedObject;
            U_DB_C.saveUser(userWithTempFlag);
            UpdateObjectView(this, e);

        }

    }
}
