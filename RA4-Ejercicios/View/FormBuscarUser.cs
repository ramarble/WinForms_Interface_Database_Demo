﻿using RA4_Ejercicios.Controller;
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
        List<User> UsersBackupList = new List<User>();
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
            userListBox.SetSelected(0, true);
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
            MessageBox.Show("hi! :D");
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
            UsersBackupList.Add(userToEdit);
            this.userList.Remove(userToEdit);

            //This form is the responsible for adding the new user to the list.
            FormUser f = new FormUser(this, userToEdit, true);
            this.Hide();
            f.ShowDialog();


            //In case the form exited abruptly
            if (!userList.Any(u => u.nif == userToEdit.nif))
            {
                this.userList.Add(userToEdit);
                this.UsersBackupList.Remove(userToEdit);
                MessageBox.Show("Form exited without any changes");
            }

            //Sets the pointer correctly
            UpdateListBoxPointerByNIF(nifKey);

        }

        private void UpdateListBoxPointerByNIF(int nifKey)
        {
            this.userListBox.SetSelected(userList.IndexOf(userList.Single(user => user.nif == nifKey)), true);
        }

        private User fetchUserByNIF(List<User> listToSearch, int nifKey)
        {
            return listToSearch.Find(u => u.nif == nifKey);
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            User userWithTempFlag = (User)userPropertyGrid.SelectedObject;
            User sameUserInBackup = fetchUserByNIF(UsersBackupList, userWithTempFlag.nif);
               
            this.userList.Remove(userWithTempFlag);
            this.userList.Add(sameUserInBackup);
            this.UsersBackupList.Remove(sameUserInBackup);
            this.userListBox.SetSelected(userList.IndexOf(sameUserInBackup),true);

        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (this.UsersBackupList.Count > 0)
            {
                MessageBox.Show("Por favor confirma o revierte todos los cambios antes de salir");
                e.Cancel = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            User userWithTempFlag = (User)userPropertyGrid.SelectedObject;
            User sameUserInBackup = fetchUserByNIF(UsersBackupList, userWithTempFlag.nif);

            UsersBackupList.Remove(sameUserInBackup);
            userWithTempFlag.setTempStatus(false);
            UpdateObjectView(this, e);

        }

    }
}
